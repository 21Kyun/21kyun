using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Missile : MonoBehaviour
{
    // 1 = MultiMissile | 2 = NuclierMissile
    public int SkillNum;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall" || other.gameObject.tag == "Floor" || other.gameObject.tag == "Enemy")
        {
            if (SkillNum == 1)
            {
                MultiMissile MTM = (MultiMissile)FindObjectOfType(typeof(MultiMissile));
                RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, MTM.MissileRate, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
                foreach (RaycastHit hitObj in rayHits)
                {
                    hitObj.transform.GetComponent<Enemy>().HitByMis(transform.position, MTM.damage);
                }
            }
            else if (SkillNum == 2)
            {
                NuclearMissile NCM = (NuclearMissile)FindObjectOfType(typeof(NuclearMissile));
                RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, NCM.MissileRate, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
                foreach (RaycastHit hitObj in rayHits)
                {
                    hitObj.transform.GetComponent<Enemy>().HitByMis(transform.position, NCM.damage);
                }
            }
            Destroy(gameObject);
        }
    }
}
