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
        Projectile,//����ü
        NomalDamage,//�Ϲ� ������
        DotDamage,//��Ʈ������
        rangeDamage//���� ������

    }

    public void EquipSkill(int Slot_Num)
    {
        Debug.Log("Start");
        SkillWinUI SkillCheak = (SkillWinUI)FindObjectOfType(typeof(SkillWinUI));

        //����ü ����
        if (SkillCheak.MainSkillSlot.Equip_Skill.subSkillType.Contains(Skill.SkillType.Projectile))
        {
            //����ü 2��
            projectileDoble projectileDoble = SkillCheak.MainSkillSlot.Equip_Skill._SubSkill[Slot_Num].SubSkillPrefab.GetComponent<projectileDoble>();
            if (projectileDoble != null && projectileDoble.name == "projectile doble")
            {
                float X2 = SkillCheak.MainSkillSlot.Equip_Skill._SubSkill[Slot_Num].SubSkillPrefab.GetComponent<projectileDoble>().X2;
                SkillCheak.MainSkillSlot.Equip_Skill.ProjectileMultiful = X2;
                //Debug.Log("��ų �̸��� projectileDoble");
            }

        }
        Debug.Log("Slot_Num" + Slot_Num);
        //�ڵ� Ÿ��
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
        //����ü 2��
        projectileDoble projectileDoble = InstansData.SubSkillPrefab.GetComponent<projectileDoble>();
        if (projectileDoble != null && projectileDoble.name == "projectile doble")
        {
            SkillCheak.MainSkillSlot.Equip_Skill.ProjectileMultiful = 1;
            Debug.Log("����ü ����  = " + SkillCheak.MainSkillSlot.Equip_Skill.ProjectileMultiful);

        }

        // �ڵ� Ÿ��
        AutoTaget TacRaider = InstansData.SubSkillPrefab.GetComponent<AutoTaget>();
        if (TacRaider != null && TacRaider.name == "AutoTaget")
        {
            SkillCheak.MainSkillSlot.Equip_Skill.AutoTagetStat = false;
        }
    }

}
