using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Player : MonoBehaviour
{


    public Camera camera;
    public bool isMove;
    public Vector3 destination;
    public float maxHealth;
    public float curHealth;
    public Vector3 Mpos;


    public float ClassicBulletRate;

    bool IsDamage;
    bool isFireReady;
    bool EnemySumRedy;
    bool DelayCheck;
    public bool ActionController;
    public bool IsUseSkill;
    public bool IsSkillUI;

    public float[] SkillCoolTime = new float[8];

    public float QSkillCoolDown;
    public float WSkillCoolDown;
    public float ESkillCoolDown;
    public float RSkillCoolDown;

    public bool SkillChange;
    bool QSkillCoolDownReady;
    bool WSkillCoolDownReady;
    bool ESkillCoolDownReady;
    bool RSkillCoolDownReady;

    private bool CButton;
    public bool RCButton;
    public bool ShButton;
    public bool CDown;
    public bool EDown;
    public bool QDown;
    public bool WDown;
    public bool KDown;



    public Transform bulletPos;
    public GameObject bullet;
    public Transform MissilePos;
    public Transform MissilePos2;
    public Transform nuclerMissilePos;
    public GameObject MissileGO;

    public GameObject SubEnemy;
    public GameObject SubEnemyReady;
    public GameObject SkillUI;


    float fireDelay;
    float delay;

    public Animator anim;
    public Rigidbody rigid;
    public NavMeshAgent agent;


    public SubSkill ProjectileDoble;
    public SubSkill TacRaider;

    public DragSlot _dragSlot;

    [SerializeField]
    private SkillWinUI TheSkillWin;
    [SerializeField]
    private GameObject QskillPrefab;


    public List<Skill> _MainSkill;

    //public GameObject QSkill;
    //public GameObject WSkill;
    //public GameObject ESkill;
    //public GameObject RSkill;
    //public GameObject ASkill;
    //public GameObject SSkill;
    //public GameObject DSkill;
    //public GameObject FSkill;



    private void Awake()
    {
        camera = Camera.main;
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //SW = GetComponent<>();
        agent.updateRotation = false;
    }



    void Start()
    {
    }

    void Update()
    {
        RaycastHit hitPos;
        Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hitPos);
        Mpos = hitPos.point;

        if (RCButton && !CButton && !EnemySumRedy && !IsUseSkill && !ActionController)
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }

        }


        LookMoveDirection();

        GetInput();
        Attack();
        EnemySum();
        PlayerUseSkill();
        ActionControl();
        GetSkill();



        //SkillWindow();
    }

    public void ActionControl()
    {
        if (SkillWinUI.SkillInventorActivated)
        {
            ActionController = true;
        }

        else
        {
            ActionController = false;
        }

    }



    private void SetDestination(Vector3 dest)
    {
        agent.SetDestination(dest);
        destination = dest;
        isMove = true;
        anim.SetBool("IsWalk", true);
        agent.speed = 15f;

    }




    private void LookMoveDirection()
    {
        // 로테이트 축 하나 고정하는 법 -> 값을 가지고 와서 포지션 값에 따로 대입
        if (isMove && !IsUseSkill)
        {

            if (agent.velocity.magnitude == 0f)
            {
                isMove = false;
                anim.SetBool("IsWalk", false);
                return;
            }

            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;



            transform.forward = dir;
            //transform.position += dir.normalized * Time.deltaTime * 15f;
            var Forward = gameObject.transform.eulerAngles;
            transform.eulerAngles = new Vector3(0, Forward.y, 0);



            Debug.Log(Input.mousePosition);
            //Debug.Log(destination.ToString());
            //Debug.Log(transform.position.ToString());
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy Attack")
        {
            if (!IsDamage)
            {
                Attacktag enemyattack = other.GetComponent<Attacktag>();
                curHealth -= enemyattack.damage;
                Vector3 reactVec = transform.position - other.transform.position;
                StartCoroutine(OnDamage(reactVec));

                Debug.Log("CurHealth" + curHealth);

                Debug.Log("damage" + enemyattack.damage);
            }

        }
    }

    IEnumerator OnDamage(Vector3 reactVec)
    {
        IsDamage = true;

        yield return null;

        IsDamage = false;


        if (curHealth <= 0)
        {


            gameObject.layer = 9;
            gameObject.tag = "PlayerDeath";
            anim.enabled = false;


            reactVec = reactVec.normalized;
            reactVec += Vector3.up * 4f;
            reactVec += Vector3.back * 2f;


            rigid.freezeRotation = false;
            agent.enabled = false;

            rigid.AddForce(reactVec * 5, ForceMode.Impulse);
            rigid.AddTorque(reactVec * 5, ForceMode.Impulse);


            Destroy(gameObject, 10);

        }
    }

    void GetInput()
    {
        RCButton = Input.GetMouseButton(1);
        CButton = Input.GetButton("Fire1");
        CDown = Input.GetButtonDown("Fire1");
        ShButton = Input.GetButton("left shift");
        EDown = Input.GetButtonDown("e");
        QDown = Input.GetButtonDown("q");
        WDown = Input.GetButtonDown("w");
        //KDown = Input.GetButtonDown("k");
    }


    void Attack()
    {
        fireDelay += Time.deltaTime;
        isFireReady = ClassicBulletRate < fireDelay;

        if (CButton && !EnemySumRedy && !IsUseSkill && !ActionController)
        {
            //Debug.Log("Click + Ememy sum");

            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Vector3 AttacVec = hit.point - transform.position;
                AttacVec.y = 0;
                transform.LookAt(transform.position + AttacVec);
            }

            if (isFireReady)
            {
                isMove = false;
                anim.SetBool("IsWalk", false);
                agent.speed = 0f;
                StartCoroutine(ClassicAttack(hit.point - bulletPos.position));
                fireDelay = 0;
                //Debug.Log("Click");
                //Debug.Log(hit.point - bulletPos.position);
            }

        }
    }

    void GetSkill()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Debug.Log("스킬 획득");
            TheSkillWin.AcqireSkill(ProjectileDoble);
            TheSkillWin.AcqireSkill(TacRaider);
        }
    }

    IEnumerator ClassicAttack(Vector3 hit)
    {
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = hit.normalized * 70;
        yield return null;
    }

    void PlayerUseSkill()
    {
        //Missile missile = (Missile)FindObjectOfType(typeof(Missile));
        //MultiMissile missile = MissileGO.GetComponent<MultiMissile>();
        //float SkillCoolTime = GetComponent<MultiMissile>().MMSkillCoolDown;
        //MultiMissile Skillscript = _MainSkill[0].SkillPrefab.GetComponent<MultiMissile>();


        if (SkillChange == true)
        {
            for (int i = 0; i < 8; i++)
            {
                Debug.Log(i);
                if (_MainSkill[i] != null)
                {
                    SkillCoolTime[i] = _MainSkill[i].SkillCoolDown;
                }
                SkillChange = false;
            }

        }


        QSkillCoolDown += Time.deltaTime;
        QSkillCoolDownReady = SkillCoolTime[0] < QSkillCoolDown;

        WSkillCoolDown += Time.deltaTime;
        WSkillCoolDownReady = SkillCoolTime[1] < WSkillCoolDown;

        if (QDown && !EnemySumRedy && !IsUseSkill && QSkillCoolDownReady && !ActionController)
        {
            //Debug.Log("QDown");
            //Debug.Log("Player Mpos = " + Mpos);
            StartCoroutine(UseQskill(Mpos));
            
        }


        if (WDown && !EnemySumRedy && !IsUseSkill && WSkillCoolDownReady && !ActionController)
        {
            Debug.Log("WDown");
            Debug.Log("Player Mpos = " + Mpos);
            StartCoroutine(UseWskill(Mpos));
            
        }
    }

    IEnumerator UseQskill(Vector3 Mpos)
    {
        if (_MainSkill[0] != null)
        {
            isMove = false;
            anim.SetBool("IsWalk", false);
            IsUseSkill = true;
            agent.speed = 0f;
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Vector3 AttacVec = hit.point - transform.position;
                AttacVec.y = 0;
                transform.LookAt(transform.position + AttacVec);
            }
            var newQskill = Instantiate(_MainSkill[0].SkillPrefab, Mpos, MissilePos.rotation);
            //Debug.Log("Instanse ScriptableObj = " + _MainSkill[0]);
            //Debug.Log(newQskill);
            //Destroy(newQskill);
            QSkillCoolDown = 0;
            yield return null;
        }
        
    }

    IEnumerator UseWskill(Vector3 Mpos)
    {
        if (_MainSkill[1] != null)
        {
            isMove = false;
            anim.SetBool("IsWalk", false);
            IsUseSkill = true;
            agent.speed = 0f;
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Vector3 AttacVec = hit.point - transform.position;
                AttacVec.y = 0;
                transform.LookAt(transform.position + AttacVec);
            }
            var newWskill = Instantiate(_MainSkill[1].SkillPrefab, Mpos, MissilePos.rotation);
            Debug.Log("Instanse ScriptableObj = " + _MainSkill[1]);
            Debug.Log(newWskill);
            //Destroy(newQskill);
            WSkillCoolDown = 0;
            yield return null;
        }
        
    }


    void EnemySum()
    {
        //RaycastHit hit;
        //Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit);


        if (ShButton && EDown && !EnemySumRedy && !ActionController)
        {
            EnemySumRedy = true;
            GameObject intantEnemyReady = Instantiate(SubEnemyReady, Mpos, bulletPos.rotation);

            StartCoroutine(LoofMousePos(Mpos, intantEnemyReady));





            //Debug.Log("Shift + E");
            return;
        }
        if (CDown && EnemySumRedy)
        {
            GameObject intantEnemy = Instantiate(SubEnemy, Mpos, bulletPos.rotation);

        }
        if (EnemySumRedy && Input.GetMouseButtonUp(1))
        {
            EnemySumRedy = false;
            Debug.Log("Mouse UP");
        }


    }

    IEnumerator Delay(float DelayTime)
    {
        yield return new WaitForSeconds(DelayTime);
        DelayCheck = false;
    }

    IEnumerator LoofMousePos(Vector3 mousePos, GameObject intantEnemyReady)
    {


        while (EnemySumRedy)
        {
            RaycastHit hit;
            Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit);


            intantEnemyReady.transform.position = hit.point;

            Debug.Log("mousePos" + mousePos);
            yield return new WaitForSeconds(0.01f);
        }

        if (!EnemySumRedy)
        {
            Destroy(intantEnemyReady);
        }


    }

    //void SkillWindow()
    //{
    //    if (KDown)
    //    {
    //        if (!IsSkillUI)
    //        {
    //            IsSkillUI = true;
    //            SkillUI.SetActive(true);
    //        }
    //        else 
    //        { 
    //            IsSkillUI = false;
    //            SkillUI.SetActive(false);
    //        }

    //    }
    //}
}
