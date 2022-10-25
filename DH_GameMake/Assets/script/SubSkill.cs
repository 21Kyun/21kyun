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
        Projectile,//투사체
        NomalDamage,//일반 데미지
        DotDamage,//도트데미지
        rangeDamage//범위 데미지

    }


}
