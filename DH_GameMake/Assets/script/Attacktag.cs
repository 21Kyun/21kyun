using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacktag : MonoBehaviour
{
    public enum Type { Melee,Range};
    public Type type;
    public float damage;
    public float rate;
    //public BoxCollider meleeArea;
}
