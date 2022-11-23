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


    bool NMSkillCoolDownReady;


    public float NMSkillCoolDown;

    private void Awake()
    {
        Debug.Log("multiMissile Start");
        UseMultiMissile();
    }

    public IEnumerator NclMisPos(Vector3 hitPos)
    {
        Player player = (Player)FindObjectOfType(typeof(Player));

        GameObject intantMissile = Instantiate(MissileGO, player.nuclerMissilePos.position, player.nuclerMissilePos.rotation); // 미사일 생성
        Rigidbody MissileRigid = intantMissile.GetComponent<Rigidbody>();
        CapsuleCollider MissileColl = intantMissile.GetComponent<CapsuleCollider>();

        Vector3 MisRang = hitPos;

        intantMissile.transform.forward = MisRang - intantMissile.transform.position;
        MissileRigid.velocity = intantMissile.transform.forward * 70;

        yield return null;
    }

    void UseMultiMissile()
    {
        Debug.Log("Test Line");
        Player player = (Player)FindObjectOfType(typeof(Player));
        StartCoroutine(NclMisPos(transform.position));
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
