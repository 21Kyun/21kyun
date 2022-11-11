using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSKillButten : MonoBehaviour
{
    public MainSkillSlot mainSkillSlot;
    public Image SkillImg;
    public void OnClick()
    {
        Color color = mainSkillSlot.MainSkillImg.color;
        color.a = 1;
        mainSkillSlot.MainSkillImg.color = color;
        mainSkillSlot.MainSkillImg.sprite = SkillImg.sprite;
    }
}
