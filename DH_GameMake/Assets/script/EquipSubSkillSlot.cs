using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipSubSkillSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    public SubSkill Equip_subskill;
    public Skill Equip_Skill;
    public Image Equip_SubSkill_Slot_img;
    public Image Equip_SubSkill_img;
    public Image MaskImg;

    public DragSlot drag_slot;


    //public bool DragOnInv = false;


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Equip_subskill != null)
        {
            //Debug.Log(eventData);
            //Debug.Log(Input.mousePosition);
            Debug.Log("OnBeginDrag");
            DragSlot.instance.Equip_dragSlot = this;
            DragSlot.instance.DragSetImage(Equip_SubSkill_img);
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Equip_subskill != null)
        {
            Debug.Log("OnDrag");
            Debug.Log("eventData = " + eventData);
            //Debug.Log(Input.mousePosition);
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.Equip_dragSlot != null)
        {
            ChangeSlot();
        }
        if (DragSlot.instance.dragSlot != null)
        {
            AddSkill(DragSlot.instance.dragSlot.subskill);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.SetColor(0);
        if (/*드래그 슬롯이 장착슬롯과 충돌 할 때*/ DragSlot.instance.DragOnInv == true)
        {
            if (DragSlot.instance.SlotOn == true)
            {
                Debug.Log("SlotOn");
                AddSkill(DragSlot.instance.Instans);
            }
            else
            {
                DragSlot.instance.Equip_dragSlot.ClearSlot();
            }
            DragSlot.instance.Equip_dragSlot = null;
        }
        else
        {
            DragSlot.instance.Equip_dragSlot = null;
        }
        Debug.Log("OnEndDrag_E");
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }


    //컬러셋팅
    private void SetColor(float _alpha)
    {
        Color color = Equip_SubSkill_img.color;
        Color Mclolr = MaskImg.color;
        color.a = _alpha;
        Mclolr.a = _alpha;
        Equip_SubSkill_img.color = color;
        Equip_SubSkill_Slot_img.color = color;
        MaskImg.color = Mclolr;
    }


    //슬롯바꾸기
    public void ChangeSlot()
    {
        SubSkill E_SubSkill = Equip_subskill;

        AddSkill(DragSlot.instance.Equip_dragSlot.Equip_subskill);

        if (E_SubSkill != null)
        {
            DragSlot.instance.Equip_dragSlot.AddSkill(E_SubSkill);
        }
        else
        {
            DragSlot.instance.Equip_dragSlot.ClearSlot();
        }


    }


    //스킬 추가
    public void AddSkill(SubSkill _subskill)
    {
        Equip_subskill = _subskill;
        Equip_SubSkill_img.sprite = Equip_subskill.SubSkillImg;
        SetColor(1);
        //MainSkillSlot _Skill = (MainSkillSlot)FindObjectOfType(typeof(MainSkillSlot));
        //Skill skill = (Skill)FindObjectOfType(typeof(Skill));
        //Debug.Log("_Skill.Equip_Skill._SubSkill = " + skill._SubSkill[0]);
        //Debug.Log("Equip_subskill = " + Equip_subskill);
        //_Skill.Equip_Skill._SubSkill.Add(Equip_subskill);
    }

    //스킬 삭제
    public void ClearSlot()
    {
        Equip_subskill = null;
        Equip_SubSkill_img.sprite = null;
        SetColor(0);
    }
}
