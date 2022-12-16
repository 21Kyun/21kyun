using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SubSkillSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{


    public SubSkill subskill;
    private EquipSubSkillSlot _EquipSubSkillSlot;
    public Image SubSlotImg;
    public Image SubSkillImg;


    //public bool DragOnEquip = false;

    public DragSlot drag_slot;

    [SerializeField]
    private SkillWinUI TheSkillWin;

    
    // Start is called before the first frame update
    void Start()
    {
    }
    

    //클릭
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {

            if (subskill != null)
            {
                Debug.Log("OnClick");
                //TheSkillWin.EquipSkill(subskill);
            }
        }
    }


    //드래그 시작
    public void OnBeginDrag(PointerEventData eventData)
    {

        if (subskill != null)
        {
            //Debug.Log(eventData);
            //Debug.Log(Input.mousePosition);
            //Debug.Log("OnBeginDrag");
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(SubSkillImg);
            DragSlot.instance.transform.position = eventData.position;
        }

    }


    //드래그
    public void OnDrag(PointerEventData eventData)
    {
        if (subskill != null)
        {
            //Debug.Log("OnDrag");
            //Debug.Log("eventData = " + eventData);
            //Debug.Log(Input.mousePosition);
            DragSlot.instance.transform.position = eventData.position;
        }
    }


    //드롭
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (DragSlot.instance.dragSlot != null)
        {
            ChangeSlot();
        }
        if(DragSlot.instance.Equip_dragSlot != null)
        {
            AddSkill(DragSlot.instance.Equip_dragSlot.Equip_subskill);
            SkillWinUI SWUI = (SkillWinUI)FindObjectOfType(typeof(SkillWinUI));
            SWUI.MainSkillSlot.Equip_Skill._SubSkill[DragSlot.instance.Equip_Slot_Num] = null;
            //Debug.Log("SWUI = " + SWUI.EquipSubSkillSolt[0].Equip_Skill._SubSkill[0].SubSkillName);
        }
    }

    //드래그 종료
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        DragSlot.instance.SetColor(0);
        //DragSlot.instance.dragSlot = null;
        if (DragSlot.instance.DragOnEquip == true)
        {
            if (DragSlot.instance.SlotOn == true)
            {
                //Debug.Log("SlotOn");
                AddSkill(DragSlot.instance.Instans);
            }
            else
            {
                DragSlot.instance.dragSlot.ClearSlot();
            }
            //Debug.Log("ClearSlot");
            DragSlot.instance.dragSlot = null;
        }
        else
        {
            DragSlot.instance.dragSlot = null;
        }
        Debug.Log("OnEndDrag");
    }


    //이미지 투명도 조절
    private void SetColor(float _alpha)
    {
        Color color = SubSkillImg.color;
        color.a = _alpha;
        SubSkillImg.color = color;
        SubSlotImg.color = color;
    }

    //서브스킬 추가
    public void AddSkill(SubSkill _subskill)
    {
        subskill = _subskill;
        SubSkillImg.sprite = subskill.SubSkillImg;
        SetColor(1);
    }


    //스킬 지우기
    public void ClearSlot()
    {
        subskill = null;
        SubSkillImg.sprite = null;
        SetColor(0);
    }

    //슬롯 바꾸기
    public void ChangeSlot()
    {
        SubSkill _SubSkill = subskill;

        AddSkill(DragSlot.instance.dragSlot.subskill);

        if (_SubSkill != null)
        {
            //Debug.Log("_SubSkill != null");
            DragSlot.instance.dragSlot.AddSkill(_SubSkill);
        }
        else
        {
            //Debug.Log("Clear");
            DragSlot.instance.dragSlot.ClearSlot();
        }
    }
}
