using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoYangChepter1 : MonoBehaviour
{
    public bool GYChap1;
    public int NowSeane = 0;


    public GameObject GYStory;
    public TextMeshProUGUI[] GoYangChap1;
    public GameObject TextBox;
    // Start is called before the first frame update
    void Start()
    {
        GYChap1 = true;
        GoYangChap1 = TextBox.GetComponentsInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && GYChap1 == true)
        {
            StartCoroutine(NextTalk());
        }
        if (Input.anyKeyDown && GYChap1 == false)
        {
            StartCoroutine(EndStory());
        }
    }

    IEnumerator NextTalk()
    {
        if (NowSeane == 0)
        {
            GoYangChap1[NowSeane].GetComponent<TextMeshProUGUI>().enabled = true;
            NowSeane++;
            yield break;
        }

        if (NowSeane < GoYangChap1.Length + 1)
        {
            Debug.Log("GoYangChap1[NowSeane] = " + NowSeane);
            GoYangChap1[NowSeane-1].GetComponent<TextMeshProUGUI>().enabled = false;
        }


        if (NowSeane < GoYangChap1.Length)
        {
            Debug.Log("GoYangChap1[NowSeane] = " + NowSeane + " / " + GoYangChap1.Length);
            GoYangChap1[NowSeane].GetComponent<TextMeshProUGUI>().enabled = true;
        }

        NowSeane++;

        if (NowSeane == GoYangChap1.Length + 1)
        {
            yield return new WaitForSeconds(0.1f);
            GYChap1 = false;
            Debug.Log("GYChap1 = " + GYChap1);
        }
        yield return null;
    }

    IEnumerator EndStory()
    {
        GameManiger GM = (GameManiger)FindObjectOfType(typeof(GameManiger));
        GM.GamePlay.active = true;
        GM.Story.active = false;
        GYStory.active = false;
        yield return null;
    }
}
