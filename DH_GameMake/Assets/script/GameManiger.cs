using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManiger : MonoBehaviour
{
    //[SerializeField]
    public AutoTaget autoTaget;

    [SerializeField] GameObject Player;
    [SerializeField] LayerMask Layer;
    [SerializeField] float Radius;
    [SerializeField] public Collider[] Col;

    public List<Skill> SkillReset = new List<Skill>();
    //public List<Skill> SkillSave = new List<Skill>();
    public Skill SkillSave;

    public List<GameObject> EnemyPos;
    GameObject Raider;


    void Start()
    {
        
        InvokeRepeating("searchEnemy", 0, 0.1f);
        for (int i = 0; i < 5; i++)
        {
            if (SkillReset[i] != null)
            {
                SkillReset[i].ProjectileMultiful = 1;
                SkillReset[i].AutoTagetStat = false;
                SkillReset[i]._SubSkill.Clear();
            }
            for (int Count = 0; Count < 5; Count++)
            {
                if (SkillReset[i] != null)
                {
                    SkillReset[i]._SubSkill.Add(null);
                }
               
            }
        }
    }

    void Update()
    {
        if (Col.Length != 0)
        {
            AutoTaget _autoTaget = autoTaget;
            Debug.Log(_autoTaget);
            _autoTaget.TacticalRaider();
            Debug.Log(_autoTaget.EnemyPos[0]);
        }
    }
        

    public void searchEnemy()
    {
        Col = Physics.OverlapSphere(Player.transform.position, Radius, Layer);
        //InvokeRepeating("TackticalRaider", 0, 0.2f);
    }

   
}
