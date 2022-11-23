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
        Color color = mainSkillSlot.Equip_Skill_img.color;
        color.a = 1;
        mainSkillSlot.Equip_Skill_img.color = color;
        mainSkillSlot.Equip_Skill_img.sprite = SkillImg.sprite;
        mainSkillSlot.Equip_Skill = SkillName;
        EquipSubSkillSlot _ESS = (EquipSubSkillSlot)FindObjectOfType(typeof(EquipSubSkillSlot));
        _ESS.Equip_Skill = SkillName;
    }
}
