using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;
    public Transform target;
    //public bool isChase;
    public BoxCollider AttackArea;
    public bool isAttack;

    Rigidbody rigid;
    BoxCollider BoxCollider;
    NavMeshAgent nav;
    Animator anim;
    Material mat;
    

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        BoxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;

        target = GameObject.Find("Real_IronMan Remodeling").transform;


        nav.speed = 0f;



        //Invoke("ChaseStart", 2);
    }

    void ChaseStart()
    {
        //isChase = true;
        anim.SetBool("IsWalk", true);
        nav.speed = 10f;
    }

    void ChaseStop()
    {
        //isChase = false;
        anim.SetBool("IsWalk", false);
        nav.speed = 0f;
    }

    void Update()
    {
        nav.SetDestination(target.position);

        if (nav.remainingDistance != 0f && nav.remainingDistance < 20f && nav.remainingDistance > 3f && !isAttack && target.tag != "PlayerDeath")
        {
            ChaseStart();
            //nav.isStopped = !isChase;
            return;
        } 
        else if(nav.remainingDistance <= 3f || nav.remainingDistance > 20f)
        {
            ChaseStop();
            return;
        }

    }

    private void FixedUpdate()
    {
        Targetting();
    }


    void Targetting()
    {
        float targetRadius = 1.5f;
        float targetRange = 3f;

        RaycastHit[] rayHits =
            Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));

        if(rayHits.Length > 0 && !isAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttack = true;
        anim.SetBool("IsAttack", true);

        //nav.speed = 0f;

        yield return new WaitForSeconds(0.2f);
        AttackArea.enabled = true;

        yield return new WaitForSeconds(1.5f);
        AttackArea.enabled = false;

        isAttack = false;
        anim.SetBool("IsAttack", false);
    }



    //void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Bullet")
    //    {
    //        Bullet Bullet = other.GetComponent<Bullet>();
    //        curHealth -= Bullet.damage;
    //        Vector3 reactVec = transform.position - other.transform.position;
    //        StartCoroutine(OnDamage(reactVec));
    //        Destroy(other.gameObject);

    //        Debug.Log("Range :" + curHealth);
    //        //Debug.Log(mat.color);
    //    }
    //}


    public void HitByMis(Vector3 explosPos,float damage)
    {
        curHealth -= damage;
        Vector3 reactVec = transform.position - explosPos;
        StartCoroutine(OnDamage(reactVec));
    }

    IEnumerator OnDamage(Vector3 reactVec)
    {

        yield return null;

        if(curHealth <= 0)
        {
            
            mat.color = Color.gray;            
            gameObject.layer = 9;
            anim.enabled = false;
            

            reactVec = reactVec.normalized;
            reactVec += Vector3.up * 3f;
                                    
            rigid.freezeRotation = false;
            nav.enabled = false;

            rigid.AddForce(reactVec * 5, ForceMode.Impulse);
            rigid.AddTorque(reactVec * 5, ForceMode.Impulse);


            Destroy(gameObject, 10);
        }
    }


}
