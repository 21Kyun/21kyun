using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainSkillSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Skill Equip_Skill;
    public Image Equip_Skill_img;
    public Image MainSkillSlotImg;
    public Image MaskImg;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Equip_Skill != null)
        {
            //Debug.Log(eventData);
            //Debug.Log(Input.mousePosition);
            Debug.Log("OnBeginDrag");
            DragSlot.instance.Main_Dragslot = this;
            DragSlot.instance.DragSetImage(Equip_Skill_img);
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Equip_Skill != null)
        {
            Debug.Log("OnDrag");
            Debug.Log("eventData = " + eventData);
            //Debug.Log(Input.mousePosition);
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //if (DragSlot.instance.Main_Dragslot != null)
        //{
        //    //ChangeSlot();
        //}
        //if (DragSlot.instance.Main_Dragslot != null)
        //{
        //    AddSkill(DragSlot.instance.Main_Dragslot.Equip_Skill);
        //}
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.SetColor(0);
        if (/*µå·¡±× ½½·ÔÀÌ ÀåÂø½½·Ô°ú Ãæµ¹ ÇÒ ¶§*/ DragSlot.instance.DragOnHudSlot == true)
        {
            DragSlot.instance.Main_Dragslot = null;

        }
        else
        {
            DragSlot.instance.Main_Dragslot = null;
        }
        Debug.Log("OnEndDrag_E");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void AddSkill(Skill _Skill)
    {
        Equip_Skill = _Skill;
        Equip_Skill_img.sprite = Equip_Skill.SkillImg;
        SetColor(1);
    }

    private void SetColor(float _alpha)
    {
        Color color = Equip_Skill_img.color;
        Color Mclolr = MaskImg.color;
        color.a = _alpha;
        Mclolr.a = _alpha;
        Equip_Skill_img.color = color;
        //Equip_SubSkill_Slot_img.color = color;
        MaskImg.color = Mclolr;
    }

    
}
