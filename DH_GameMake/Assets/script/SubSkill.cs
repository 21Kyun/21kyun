using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill" , menuName = "New Skill/SubSkill")]
public class SubSkill : ScriptableObject
{
    public string SubSkillName;
    public SubSkillType subSkillType;
    public Sprite SubSkillImg;

    public GameObject SubSkillPrefab;
    public enum SubSkillType
    {
        Projectile,//����ü
        NomalDamage,//�Ϲ� ������
        DotDamage,//��Ʈ������
        rangeDamage//���� ������

    }


}
