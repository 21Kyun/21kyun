using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSKillButten : MonoBehaviour
{
    public MainSkillSlot mainSkillSlot;
    public Image SkillImg;
    public Skill SkillName;
    public void OnClick()
    {

        //���� ��ų ���Կ� ��ų ����
        Color color = mainSkillSlot.Equip_Skill_img.color;
        color.a = 1;
        mainSkillSlot.Equip_Skill_img.color = color;
        mainSkillSlot.Equip_Skill_img.sprite = SkillImg.sprite;
        mainSkillSlot.Equip_Skill = SkillName;
        SkillWinUI SWUI = (SkillWinUI)FindObjectOfType(typeof(SkillWinUI));

        //���� �Ŵ����� ���� ���� �� �ҷ�����
        GameManiger GM = (GameManiger)FindObjectOfType(typeof(GameManiger));
        GM.SkillSave = SkillName;
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("��ų ���� ��ġ = " + SWUI.EquipSubSkillSolt[i]);
            Debug.Log("��ų Ȯ�� = " + GM.SkillSave._SubSkill[i]);
            if (GM.SkillSave._SubSkill[i] != null)
            {
                SWUI.EquipSubSkillSolt[i].AddSkill(GM.SkillSave._SubSkill[i]);
                
            }
            else
            {
                SWUI.EquipSubSkillSolt[i].ClearSlot();
            }
           
        }
        
    }
}
