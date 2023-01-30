using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "New Skill/Skill")]
public class Skill : ScriptableObject
{
    public SkillName _SkillName;
    public List<SkillType> subSkillType;
    public Sprite SkillImg;
    public float SkillCoolDown;

    public float ProjectileMultiful;
    public bool AutoTagetStat = false;

    public GameObject SkillPrefab;

    public List<SubSkill> _SubSkill = new List<SubSkill>(5);
    public enum SkillType
    {
        Projectile,//����ü
        NomalDamage,//�Ϲ� ������
        DotDamage,//��Ʈ������
        rangeDamage,//���� ������       
    }


    public enum SkillName
    {
        MultiMissile, //���߹̻���
        nuclerMissile, //�ٹ̻���
        WPM
    }

}
