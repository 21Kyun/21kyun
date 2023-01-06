using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuclearMissile : MonoBehaviour
{
    public int damage;
    public float MissileRate;
    public bool Butten;

    public Transform nuclerMissilePos;
    public GameObject MissileGO;
    public GameObject Player;


    public float Multifuly = 1;


    bool NMSkillCoolDownReady;


    public float NMSkillCoolDown;

    private void Awake()
    {
        //Debug.Log("multiMissile Start");
        UseMultiMissile();
    }

    public IEnumerator NclMisPos(float MisCount,Vector3 hitPos)
    {
        Player player = (Player)FindObjectOfType(typeof(Player));
        GameManiger GM = (GameManiger)FindObjectOfType(typeof(GameManiger));

        float Angle = 0;
        for (int i = 0; i < MisCount; i++)
        {
            GameObject intantMissile = Instantiate(MissileGO, player.nuclerMissilePos.position, player.nuclerMissilePos.rotation); // 미사일 생성
            Rigidbody MissileRigid = intantMissile.GetComponent<Rigidbody>();
            CapsuleCollider MissileColl = intantMissile.GetComponent<CapsuleCollider>();

            


            Vector3 MisRang = hitPos;

            if (GM.SkillReset[1].AutoTagetStat == true)
            {
                if (GM.Col.Length != 0)
                {
                    AutoTaget autoTaget = GM.autoTaget;
                    autoTaget.TacticalRaider();
                    MisRang = autoTaget.EnemyPos[Random.Range(0, GM.Col.Length)];
                }
            }
           

            intantMissile.transform.forward = MisRang - intantMissile.transform.position;

            if (GM.Col.Length == 0)
            {
                //원뿔모양으로 발사
                Vector3 Y = intantMissile.transform.eulerAngles;
                Angle = Angle + Mathf.Pow(-1, i) * (10 * i);
                Y.y = Y.y + Angle;
                intantMissile.transform.eulerAngles = Y;
                //Debug.Log("Y  좌표 = " + Y);
                //Debug.Log("Angle 값 = " + Angle);
                //Debug.Log("수식값 = " + (Mathf.Pow(-1,i) * (10* i)));
            }
            MissileRigid.velocity = intantMissile.transform.forward * 70f;

            yield return null;
        }
        
    }

    void UseMultiMissile()
    {
        //Debug.Log("Test Line");

        Player player = (Player)FindObjectOfType(typeof(Player));
        GameManiger GM = (GameManiger)FindObjectOfType(typeof(GameManiger));
        Multifuly = GM.SkillReset[1].ProjectileMultiful;
        StartCoroutine(NclMisPos(1 * Multifuly, transform.position));
        player.IsUseSkill = false;
        Destroy(gameObject, 1);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall" || other.gameObject.tag == "Floor" || other.gameObject.tag == "Enemy")
        {
            RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
            foreach (RaycastHit hitObj in rayHits)
            {
                hitObj.transform.GetComponent<Enemy>().HitByMis(transform.position,damage);
            }
            Destroy(gameObject);
        }
    }
}
