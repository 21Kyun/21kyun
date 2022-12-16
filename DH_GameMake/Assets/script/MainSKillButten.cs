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

        //메인 스킬 슬롯에 스킬 장착
        Color color = mainSkillSlot.Equip_Skill_img.color;
        color.a = 1;
        mainSkillSlot.Equip_Skill_img.color = color;
        mainSkillSlot.Equip_Skill_img.sprite = SkillImg.sprite;
        mainSkillSlot.Equip_Skill = SkillName;
        SkillWinUI SWUI = (SkillWinUI)FindObjectOfType(typeof(SkillWinUI));

        //게임 매니저에 슬롯 저장 및 불러오기
        GameManiger GM = (GameManiger)FindObjectOfType(typeof(GameManiger));
        GM.SkillSave = SkillName;
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("스킬 슬롯 위치 = " + SWUI.EquipSubSkillSolt[i]);
            Debug.Log("스킬 확인 = " + GM.SkillSave._SubSkill[i]);
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
