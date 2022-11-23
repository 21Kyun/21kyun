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

    public GameObject SkillPrefab;

    public List<SubSkill> _SubSkill = new List<SubSkill>();
    public enum SkillType
    {
        Projectile,//투사체
        NomalDamage,//일반 데미지
        DotDamage,//도트데미지
        rangeDamage//범위 데미지
    }

    public enum SkillName
    {
        MultiMissile, //다중미사일
        nuclerMissile //핵미사일
    }


}
