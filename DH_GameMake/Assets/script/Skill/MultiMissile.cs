using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiMissile : MonoBehaviour
{


    public int damage;
    public float MissileRate;
    public bool Butten;

    public Transform MissilePos;
    public Transform MissilePos2;
    public GameObject MissileGO;
    public GameObject Player;


    bool QSkillCoolDownReady;


    public float SkillCoolDown;

    private void Awake()
    {
        Debug.Log("multiMissile Start");
        UseMultiMissile();
    }


    public IEnumerator MisRPos(Vector3 hitPos)
    {
        Player player = (Player)FindObjectOfType(typeof(Player));

        GameObject intantMissile = Instantiate(MissileGO, player.MissilePos.position, player.MissilePos.rotation);
        Rigidbody MissileRigid = intantMissile.GetComponent<Rigidbody>();
        CapsuleCollider MissileColl = intantMissile.GetComponent<CapsuleCollider>();
        Vector3 RanY = new Vector3(0f, 0f, 0f);
        RanY.z = RanY.z + Random.RandomRange(1f, 50f);
        intantMissile.transform.Rotate(RanY, Space.Self);
        for (Vector3 MisRot = new Vector3(5f, 0f, 0f); intantMissile.transform.eulerAngles.x >= 200f || intantMissile.transform.eulerAngles.x <= 10f;) //초기화,조건식,반복
        {
            intantMissile.transform.Rotate(MisRot, Space.Self);
            MissileRigid.velocity = intantMissile.transform.forward * 50f;

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

        GameObject intantMissile2 = Instantiate(MissileGO, player.MissilePos2.position, player.MissilePos2.rotation);
        Rigidbody MissileRigid2 = intantMissile2.GetComponent<Rigidbody>();
        CapsuleCollider MissileColl2 = intantMissile2.GetComponent<CapsuleCollider>();
        Vector3 RanY2 = new Vector3(0f, 0f, 0f);
        RanY2.z = RanY2.z + Random.RandomRange(-1f, -50f);
        intantMissile2.transform.Rotate(RanY2, Space.Self);
        for (Vector3 MisRot = new Vector3(5f, 0f, 0f); intantMissile2.transform.eulerAngles.x >= 200f || intantMissile2.transform.eulerAngles.x <= 10f;) //초기화,조건식,반복
        {
            intantMissile2.transform.Rotate(MisRot, Space.Self);
            MissileRigid2.velocity = intantMissile2.transform.forward * 50f;

            yield return null;
        }

        Vector3 MisRang = hitPos;
        MisRang.x = MisRang.x + Random.RandomRange(-5f, 5f);
        MisRang.z = MisRang.z + Random.RandomRange(-5f, 5f);

        intantMissile2.transform.forward = MisRang - intantMissile2.transform.position;
        MissileRigid2.velocity = intantMissile2.transform.forward * 70;

        yield return null;
    }

    void UseMultiMissile()
    {
        SkillWinUI SWUI = (SkillWinUI)FindObjectOfType(typeof(SkillWinUI));
        float Multifuly;

        if (SWUI.EquipSubSkillSolt[0].Equip_subskill != null) //슬롯 0번의 장착서브스킬이 null이 아닐때
        {
            //Debug.Log("SWUI.EquipSubSkillSolt[0].Equip_subskill != null");
            projectileDoble PD = SWUI.EquipSubSkillSolt[0].Equip_subskill.SubSkillPrefab.GetComponent<projectileDoble>();
            Multifuly = PD.X2;
        }
        else
        {
            Multifuly = 1;
        }
        StartCoroutine(MisSkill(5 * Multifuly, transform.position));

        IEnumerator MisSkill(float MisCont, Vector3 hitPos)
        {
            Player player = (Player)FindObjectOfType(typeof(Player));
            

            for (int Cont = 0; Cont < MisCont; Cont++)
            {
                StartCoroutine(MisRPos(hitPos));
                yield return new WaitForSeconds(0.35f / MisCont);
                StartCoroutine(MisLPos(hitPos));
                yield return new WaitForSeconds(0.35f / MisCont);
            }
            player.IsUseSkill = false;
            Destroy(gameObject, 1);
        }

        //Debug.Log("CoolDownM : " + missile.CoolDown);
        //Debug.Log("CoolDownReady : " + missile.CoolDownReady);
        //Debug.Log("CoolDownM : " + missile.damage);
        //Debug.Log("QSkill : " + QDown);
    }


}
