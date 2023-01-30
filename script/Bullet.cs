using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall" || other.gameObject.tag == "Floor" || other.gameObject.tag == "Enemy")
        {
            RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
            foreach (RaycastHit hitObj in rayHits)
            {
                hitObj.transform.GetComponent<Enemy>().HitByMis(transform.position, damage);
            }
            Destroy(gameObject);
        }
    }
}
