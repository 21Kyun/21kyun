using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTaget : MonoBehaviour
{
    //[SerializeField] GameManiger _GameManiger;

    public List<GameObject> EnemyPos;

   
    public void TacticalRaider()
    {
        
        GameManiger GM = (GameManiger)FindObjectOfType(typeof(GameManiger));

        for (int i = 0; i < GM.Col.Length; i++)
        {
            Debug.Log("Col[i].GetComponent<GameObject>() = " + GM.Col[i].gameObject);
            EnemyPos.Add(GM.Col[i].gameObject);
        }
    }
    
}
