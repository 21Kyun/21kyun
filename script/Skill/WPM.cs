using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPM : MonoBehaviour
{
    public GameObject WPM_Obj;
    public float damage;
    public float duration;
    //float delayTime = 0;

    private void Start()
    {
        useWPM();
    }


    void useWPM()
    {
        Player player = (Player)FindObjectOfType(typeof(Player));
        StartCoroutine(WPM_Pos(transform.position));
        player.IsUseSkill = false;
        Destroy(gameObject, duration);
    }

    public IEnumerator WPM_Pos(Vector3 WPMPos)
    {
        Debug.Log("transformRot = " + transform.rotation);
        GameObject WPM = Instantiate(WPM_Obj, WPMPos,new Quaternion(0,0,0,0));
        Destroy(WPM, duration);
        Debug.Log("Destroy WPM ");
        yield return null;
    }
}
