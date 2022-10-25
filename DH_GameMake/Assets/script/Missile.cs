using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Missile : MonoBehaviour
{

    public int damage;
    public float MissileRate;
    public bool Butten;


    public IEnumerator MisRPos(Vector3 hitPos)
    {
        Player player = (Player)FindObjectOfType(typeof(Player));

        GameObject intantMissile = Instantiate(player.MissileGO, player.MissilePos.position, player.MissilePos.rotation);
        Rigidbody MissileRigid = intantMissile.GetComponent<Rigidbody>();
        CapsuleCollider MissileColl = intantMissile.GetComponent<CapsuleCollider>();
        Vector3 RanY = new Vector3(0f, 0f, 0f);
        RanY.z = RanY.z + Random.RandomRange(1f, 50f);
        intantMissile.transform.Rotate(RanY, Space.Self);
        //intantMissile.transform.localRotation *= Quaternion.Euler(RanY);
        //Debug.Log("RanY.z : " + RanY);
        //Debug.Log("MissileEul.z : " + intantMissile.transform.eulerAngles.x);
        for (Vector3 MisRot = new Vector3(5f, 0f, 0f); intantMissile.transform.eulerAngles.x >= 200f || intantMissile.transform.eulerAngles.x <= 10f;) //초기화,조건식,반복
        {
            intantMissile.transform.Rotate(MisRot, Space.Self);
            MissileRigid.velocity = intantMissile.transform.forward * 50f;
            //Debug.Log("locRot : " + intantMissile.transform.eulerAngles.x);

            yield return null;
        }

        Vector3 MisRang = hitPos;
        MisRang.x = MisRang.x + Random.RandomRange(-5f, 5f);
        MisRang.z = MisRang.z + Random.RandomRange(-5f, 5f);

        intantMissile.transform.forward = MisRang - intantMissile.transform.position;
        MissileRigid.velocity = intantMissile.transform.forward * 70;

        yield return null;
    }

    public IEnumerator MisLPos(Vector3 hitPos)
    {
        Player player = (Player)FindObjectOfType(typeof(Player));

        GameObject intantMissile2 = Instantiate(player.MissileGO, player.MissilePos2.position, player.MissilePos2.rotation);
        Rigidbody MissileRigid2 = intantMissile2.GetComponent<Rigidbody>();
        CapsuleCollider MissileColl2 = intantMissile2.GetComponent<CapsuleCollider>();
        Vector3 RanY2 = new Vector3(0f, 0f, 0f);
        RanY2.z = RanY2.z + Random.RandomRange(-1f, -50f);
        intantMissile2.transform.Rotate(RanY2, Space.Self);
        //intantMissile.transform.localRotation *= Quaternion.Euler(RanY);
        for (Vector3 MisRot = new Vector3(5f, 0f, 0f); intantMissile2.transform.eulerAngles.x >= 200f || intantMissile2.transform.eulerAngles.x <= 10f;) //초기화,조건식,반복
        {
            intantMissile2.transform.Rotate(MisRot, Space.Self);
            MissileRigid2.velocity = intantMissile2.transform.forward * 50f;
            //Debug.Log("locRot : " + intantMissile2.transform.localRotation);

            yield return null;
        }

        Vector3 MisRang = hitPos;
        MisRang.x = MisRang.x + Random.RandomRange(-5f, 5f);
        MisRang.z = MisRang.z + Random.RandomRange(-5f, 5f);

        intantMissile2.transform.forward = MisRang - intantMissile2.transform.position;
        MissileRigid2.velocity = intantMissile2.transform.forward * 70;

        yield return null;
    }

    public IEnumerator NuclierMisLPos(Vector3 hitPos)
    {
        Player player = (Player)FindObjectOfType(typeof(Player));

        GameObject intantMissile2 = Instantiate(player.MissileGO, player.MissilePos2.position, player.MissilePos2.rotation);
        Rigidbody MissileRigid2 = intantMissile2.GetComponent<Rigidbody>();
        CapsuleCollider MissileColl2 = intantMissile2.GetComponent<CapsuleCollider>();
        Vector3 RanY2 = new Vector3(0f, 0f, 0f);
        RanY2.z = RanY2.z + Random.RandomRange(-1f, -50f);
        intantMissile2.transform.Rotate(RanY2, Space.Self);
        //intantMissile.transform.localRotation *= Quaternion.Euler(RanY);
        for (Vector3 MisRot = new Vector3(5f, 0f, 0f); intantMissile2.transform.eulerAngles.x >= 200f || intantMissile2.transform.eulerAngles.x <= 10f;) //초기화,조건식,반복
        {
            intantMissile2.transform.Rotate(MisRot, Space.Self);
            MissileRigid2.velocity = intantMissile2.transform.forward * 50f;
            //Debug.Log("locRot : " + intantMissile2.transform.localRotation);

            yield return null;
        }

        Vector3 MisRang = hitPos;
        MisRang.x = MisRang.x + Random.RandomRange(-5f, 5f);
        MisRang.z = MisRang.z + Random.RandomRange(-5f, 5f);

        intantMissile2.transform.forward = MisRang - intantMissile2.transform.position;
        MissileRigid2.velocity = intantMissile2.transform.forward * 70;

        yield return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall" || other.gameObject.tag == "Floor" || other.gameObject.tag == "Enemy")
        {
            RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
            foreach(RaycastHit hitObj in rayHits)
            {
                //hitObj.transform.GetComponent<Enemy>().HitByMis(transform.position);
            }
            Destroy(gameObject);
        }
    }
}
