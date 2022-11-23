using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipSkillSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    //public Player PlayerScript;

    //public bool Target;

    public Skill Equip_Skill;
    public Image Equip_Skill_img;
    public int SlotNum;

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Equip_Skill != null)
        {
            //Debug.Log(eventData);
            //Debug.Log(Input.mousePosition);
            Debug.Log("OnBeginDrag");
            DragSlot.instance.Equip_Main_DragSlot = this;
            DragSlot.instance.DragSetImage(Equip_Skill_img);
            DragSlot.instance.transform.position = eventData.position;
            DragSlot.instance.SlotNum = SlotNum;
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

        if (DragSlot.instance.Equip_Main_DragSlot != null)
        {
            ChangeSlot();
        }
        if (DragSlot.instance.Main_Dragslot != null)
        {
            Debug.Log("AddSkill");
            AddSkill(DragSlot.instance.Main_Dragslot.Equip_Skill);
        }
        Player PlayerScript = (Player)FindObjectOfType(typeof(Player));
        PlayerScript.SkillChange = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.SetColor(0);
        if (/*드래그 슬롯이 장착슬롯과 충돌 할 때*/ DragSlot.instance.DragOnHudSlot == false)
        {
            DragSlot.instance.Equip_Main_DragSlot.ClearSlot();
            DragSlot.instance.Equip_Main_DragSlot = null;
        }
        else
        {
            DragSlot.instance.Equip_Main_DragSlot = null;
        }
        Debug.Log("OnEndDrag_E");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }



    private void SetColor(float _alpha)
    {
        Color color = Equip_Skill_img.color;
        color.a = _alpha;
        Equip_Skill_img.color = color;
    }


    //슬롯바꾸기
    public void ChangeSlot()
    {
        Skill E_Skill = Equip_Skill;
        Player PlayerScript = (Player)FindObjectOfType(typeof(Player));
        AddSkill(DragSlot.instance.Equip_Main_DragSlot.Equip_Skill);

        if (E_Skill != null)
        {
            DragSlot.instance.Equip_Main_DragSlot.AddSkill(E_Skill);
        }
        else
        {
            DragSlot.instance.Equip_Main_DragSlot.ClearSlot();
            PlayerScript._MainSkill[DragSlot.instance.SlotNum] = null;
        }


    }


    //스킬 추가
    public void AddSkill(Skill _Skill)
    {
        Equip_Skill = _Skill;
        Equip_Skill_img.sprite = Equip_Skill.SkillImg;
        SetColor(1);
        Player PlayerScript = (Player)FindObjectOfType(typeof(Player));
        PlayerScript._MainSkill[SlotNum] = Equip_Skill;
    }

    //스킬 삭제
    public void ClearSlot()
    {
        Equip_Skill = null;
        Equip_Skill_img.sprite = null;
        SetColor(0);
    }
}
