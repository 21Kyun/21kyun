using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTaget : MonoBehaviour
{
    //[SerializeField] GameManiger _GameManiger;

    //public List<GameObject> EnemyPos;
    public List<Vector3> EnemyPos;

   
    public void TacticalRaider()
    {
        GameManiger GM = (GameManiger)FindObjectOfType(typeof(GameManiger));
        EnemyPos.Clear();
        for (int i = 0; i < GM.Col.Length; i++)
        {
           
            EnemyPos.Add(GM.Col[i].gameObject.transform.position);
        }
    }
    
}
