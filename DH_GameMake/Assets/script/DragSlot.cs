using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragSlot : MonoBehaviour
{

    static public DragSlot instance;

    public MainSkillSlot Main_Dragslot;
    public EquipSkillSlot Equip_Main_DragSlot;
    public SubSkillSlot dragSlot;
    public EquipSubSkillSlot Equip_dragSlot;

    public SubSkill Instans;

    public int SlotNum;

    private GraphicRaycaster hitPos;
    private PointerEventData m_ped;
    public Canvas m_canvas;

    public bool DragOnEquip = false;
    public bool DragOnInv = false;
    public bool DragOnHudSlot = false;

    public bool SlotOn = false;

    //�������̹���
    [SerializeField]
    private Image Img_SubSkill;
    [SerializeField]
    private Image Img_SubSkillSlot;

    private void Start()
    {
        hitPos = m_canvas.GetComponent<GraphicRaycaster>();
        m_ped = new PointerEventData(null);
        instance = this;
    }

    private void Update()
    {
        if (SkillWinUI.SkillInventorActivated)
        {

            m_ped.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            hitPos.Raycast(m_ped, results);
            GameObject ResultObj = results[0].gameObject;
            //Debug.Log(results[0].gameObject.tag);

            if (/*�巡�� ���԰� ���� ������ �浹 �ϸ�*/ResultObj.tag == "EquipSkillSlot")
            {
                EquipSubSkillSlot SubSkillOn = ResultObj.GetComponent<EquipSubSkillSlot>();
                if (SubSkillOn.Equip_subskill != null)
                {
                    Instans = SubSkillOn.Equip_subskill;
                    SlotOn = true;
                }
                DragOnEquip = true;
                DragOnInv = false;
            }
            else if (/*�巡�� ���԰� ���� ������ �浹 �ϸ�*/ResultObj.tag == "SubSkillSlot")
            {
                SubSkillSlot SubSkillOn = ResultObj.GetComponent<SubSkillSlot>();
                if (SubSkillOn.subskill != null)
                {
                    Instans = SubSkillOn.subskill;
                    SlotOn = true;
                }
                DragOnInv = true;
                DragOnEquip = false;
            }
            else if (/*�巡�� ���԰� ���� ������ �浹 �ϸ�*/ResultObj.tag == "HudSkillSlot")
            {
                DragOnInv = false;
                DragOnEquip = false;
                DragOnHudSlot = true;
            }
            else 
            {
                DragOnEquip = false;
                DragOnInv = false;
                DragOnHudSlot = false;
                SlotOn = false;
            }

            //Debug.Log(DragOnEquip);
            //Debug.Log(DragOnInv);
        }

    }


    //�巡�׽� �̹��� ����
    public void DragSetImage(Image _Imag_SubSkill)
    {
        Img_SubSkill.sprite = _Imag_SubSkill.sprite;
        SetColor(1);
    }


    //���� ����
    public void SetColor(float _alpha)
    {
        Color color = Img_SubSkill.color;
        color.a = _alpha;
        Img_SubSkill.color = color;
        Img_SubSkillSlot.color = color;
    }
}
