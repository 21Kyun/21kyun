using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "New Skill/Skill")]
public class Skill : ScriptableObject
{
    public SkillName _SkillName;
    public SkillType subSkillType;
    public Sprite SkillImg;
    public float SkillCoolDown;

    public GameObject SkillPrefab;


    public enum SkillType
    {
        Projectile,//����ü
        NomalDamage,//�Ϲ� ������
        DotDamage,//��Ʈ������
        rangeDamage//���� ������
    }

    public enum SkillName
    {
        MultiMissile, //���߹̻���
        nuclerMissile //�ٹ̻���
    }


}
