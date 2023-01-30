using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "New Skill/SubSkill")]
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

    public void EquipSkill(int Slot_Num)
    {
        Debug.Log("Start");
        SkillWinUI SkillCheak = (SkillWinUI)FindObjectOfType(typeof(SkillWinUI));

        //투사체 관련
        if (SkillCheak.MainSkillSlot.Equip_Skill.subSkillType.Contains(Skill.SkillType.Projectile))
        {
            //투사체 2배
            projectileDoble projectileDoble = SkillCheak.MainSkillSlot.Equip_Skill._SubSkill[Slot_Num].SubSkillPrefab.GetComponent<projectileDoble>();
            if (projectileDoble != null && projectileDoble.name == "projectile doble")
            {
                float X2 = SkillCheak.MainSkillSlot.Equip_Skill._SubSkill[Slot_Num].SubSkillPrefab.GetComponent<projectileDoble>().X2;
                SkillCheak.MainSkillSlot.Equip_Skill.ProjectileMultiful = X2;
                //Debug.Log("스킬 이름이 projectileDoble");
            }

        }
        Debug.Log("Slot_Num" + Slot_Num);
        //자동 타겟
        AutoTaget TacRaider = SkillCheak.MainSkillSlot.Equip_Skill._SubSkill[Slot_Num].SubSkillPrefab.GetComponent<AutoTaget>();
        if (TacRaider != null && TacRaider.name == "AutoTaget")
        {
            SkillCheak.MainSkillSlot.Equip_Skill.AutoTagetStat = true;
        }

    }

    public void ClearSkill(int Slot_Num, SubSkill InstansData)
    {
        SkillWinUI SkillCheak = (SkillWinUI)FindObjectOfType(typeof(SkillWinUI));
        Debug.Log("Slot_Num  = " + Slot_Num);
        //투사체 2배
        projectileDoble projectileDoble = InstansData.SubSkillPrefab.GetComponent<projectileDoble>();
        if (projectileDoble != null && projectileDoble.name == "projectile doble")
        {
            SkillCheak.MainSkillSlot.Equip_Skill.ProjectileMultiful = 1;
            Debug.Log("투사체 배율  = " + SkillCheak.MainSkillSlot.Equip_Skill.ProjectileMultiful);

        }

        // 자동 타겟
        AutoTaget TacRaider = InstansData.SubSkillPrefab.GetComponent<AutoTaget>();
        if (TacRaider != null && TacRaider.name == "AutoTaget")
        {
            SkillCheak.MainSkillSlot.Equip_Skill.AutoTagetStat = false;
        }
    }

}
