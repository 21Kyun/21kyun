using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillWinUI : MonoBehaviour
{

    public static bool SkillInventorActivated = false;

    [SerializeField]
    private GameObject go_SkillWin;
    [SerializeField]
    private GameObject go_SubSlotsParet;
    [SerializeField]
    private GameObject go_EquipSubSkillParet;
    [SerializeField]
    private GameObject go_MainSkillSlot;
    [SerializeField]
    private GameObject go_EquipMainSkillSlot1;
    [SerializeField]
    private GameObject go_EquipMainSkillSlot2;



    // ��ų ���Ե�
    public MainSkillSlot MainSkillSlot;
    public EquipSkillSlot[] EquipSkillSlot1;
    public EquipSkillSlot[] EquipSkillSlot2;
    public SubSkillSlot[] SubSlots;
    public EquipSubSkillSlot[] EquipSubSkillSolt;

    private void Start()
    {
        MainSkillSlot = go_MainSkillSlot.GetComponentInChildren<MainSkillSlot>();
        EquipSkillSlot1 = go_EquipMainSkillSlot1.GetComponentsInChildren<EquipSkillSlot>();
        EquipSkillSlot2 = go_EquipMainSkillSlot2.GetComponentsInChildren<EquipSkillSlot>();
        SubSlots = go_SubSlotsParet.GetComponentsInChildren<SubSkillSlot>();
        EquipSubSkillSolt = go_EquipSubSkillParet.GetComponentsInChildren<EquipSubSkillSlot>();

        Debug.Log("Skill Type = " + Skill.SkillType.Projectile);

        for (int i = 0; i < 5; i++)
        {
            EquipSubSkillSolt[i].This_Slot_Num = i;
        }
    }

    private void Update()
    {
        TryOpeSkillWin();
    }


    //��ųâ �¿���
    private void TryOpeSkillWin()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SkillInventorActivated = !SkillInventorActivated;

            if (SkillInventorActivated)
            {
                OpenSkillWin();
            }
            else
            {
                CloseSkillWin();
            }
        }
    }

    private void OpenSkillWin()
    {
        go_SkillWin.SetActive(true);
    }

    private void CloseSkillWin()
    {
        go_SkillWin.SetActive(false);
    }


    //��ų ȹ��� ��ųâ�� ����
    public void AcqireSkill(SubSkill _subskill)
    {
        for (int i = 0; i < SubSlots.Length; i++)
        {
            if (SubSlots[i].subskill == null)
            {
                SubSlots[i].AddSkill(_subskill);
                return;
            }

        }
    }

    public void EquipSkill(SubSkill _subskill)
    {
        for (int i = 0; i < EquipSubSkillSolt.Length; i++)
        {
            if (EquipSubSkillSolt[i].Equip_subskill == null)
            {
                EquipSubSkillSolt[i].AddSkill(_subskill);
                return;
            }

        }
    }
}
