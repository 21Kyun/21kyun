using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TItle : MonoBehaviour
{

    public bool AnyKeyPress;
    public bool TextalpaLoop;
    public bool TextalpaLoopEnd;
    public bool IsMenuOn;

    public GameObject AnyKeyText;
    public GameObject Logo;
    public GameObject Menu;
    public GameObject NewGame;
    public GameObject LoadGame;
    public GameObject Collection;
    public GameObject Exit;
    //public GameObject Setting;



    void Start()
    {
        AnyKeyPress = false;
    }


    void Update()
    {
        if (AnyKeyPress == false)
        {
            TextalpaLoop = true;
            StartCoroutine("TextAlpaLoop");
        }

        if (Input.anyKey && AnyKeyPress == false)
        {
            StopCoroutine("TextAlpaLoop");
            StartCoroutine(PressAnyKey());
            StartCoroutine(LogoMoveing());
        }

        if (TextalpaLoopEnd == true && IsMenuOn == false)
        {
            IsMenuOn = true;
            StartCoroutine(OpenMainMenu());
        }
    }

    IEnumerator PressAnyKey()
    {
        AnyKeyPress = true;

        Text AnyKeyOpa = AnyKeyText.GetComponent<Text>();
        for (float i = AnyKeyOpa.color.a; i >= -0.1f; i -= 0.01f)
        {
            AnyKeyOpa.color = new Color(AnyKeyOpa.color.r, AnyKeyOpa.color.g, AnyKeyOpa.color.b, i);
            //Debug.Log("AnyKeyOpa.color = " + AnyKeyOpa.color);
            yield return new WaitForSeconds(0.01f);
        }
        


    }

    IEnumerator TextAlpaLoop()
    {
        Text AnyKeyOpa = AnyKeyText.GetComponent<Text>();
        if (AnyKeyOpa.color.a >= 1)
        {
            for (float i = AnyKeyOpa.color.a; i > -0.1f; i -= 0.01f)
            {
                //Debug.Log("HighAlpa");
                AnyKeyOpa.color = new Color(AnyKeyOpa.color.r, AnyKeyOpa.color.g, AnyKeyOpa.color.b, i);
                //Debug.Log("AnyKeyOpa.color = " + AnyKeyOpa.color);
                if (AnyKeyOpa.color.a < 0)
                {
                    AnyKeyOpa.color = new Color(AnyKeyOpa.color.r, AnyKeyOpa.color.g, AnyKeyOpa.color.b, 0);
                    TextalpaLoop = false;
                }
                yield return new WaitForSeconds(0.005f);
            }
        }

        if (AnyKeyOpa.color.a <= 0)
        {
            for (float i = AnyKeyOpa.color.a; i < 1.1f; i += 0.01f)
            {
                //Debug.Log("LowAlpa");
                AnyKeyOpa.color = new Color(AnyKeyOpa.color.r, AnyKeyOpa.color.g, AnyKeyOpa.color.b, i);
                //Debug.Log("AnyKeyOpa.color = " + AnyKeyOpa.color);
                if (AnyKeyOpa.color.a > 1)
                {
                    AnyKeyOpa.color = new Color(AnyKeyOpa.color.r, AnyKeyOpa.color.g, AnyKeyOpa.color.b, 1);
                    TextalpaLoop = false;
                }
                yield return new WaitForSeconds(0.005f);
            }
        }

        if (AnyKeyPress == false && TextalpaLoop == false)
        {
            TextalpaLoop = true;
            StartCoroutine("TextAlpaLoop");
        }
        yield return null;
    }

    IEnumerator LogoMoveing()
    {
        RectTransform LogoPos = Logo.GetComponent<RectTransform>();
        Debug.Log("LogoPos.transform.position = " + LogoPos.position);
        float newPos = LogoPos.transform.position.y;
        for (float i = LogoPos.transform.position.y; i <= newPos + 100f; i += 1f)
        {
            LogoPos.transform.position = new Vector3(LogoPos.transform.position.x, i , LogoPos.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        TextalpaLoopEnd = true;
        yield return null;
    }

    IEnumerator OpenMainMenu()
    {
        Menu.active = true;
        RectTransform NewGamePos = NewGame.GetComponent<RectTransform>();
        float StartPos = NewGamePos.position.y;
        float FinalPos = NewGamePos.position.y;
        for (float i = StartPos + 50f; i > FinalPos; i -= 1f)
        {

            Image NewGameAlpa = NewGame.GetComponent<Image>();
            TextMeshProUGUI TextAlpa = NewGame.GetComponentInChildren<TextMeshProUGUI>();
            float NewAlpa = NewGameAlpa.color.a;
            NewAlpa += 0.02f;
            NewGameAlpa.color = new Color(NewGameAlpa.color.r, NewGameAlpa.color.g, NewGameAlpa.color.b, NewAlpa);
            TextAlpa.color = new Color(TextAlpa.color.r, TextAlpa.color.g, TextAlpa.color.b, NewAlpa);
            NewGamePos.position = new Vector3(NewGamePos.position.x, i, NewGamePos.position.z);
            yield return new WaitForSeconds(0.01f);
        }

        RectTransform LoadGamePos = LoadGame.GetComponent<RectTransform>();
        float StartPos1 = LoadGamePos.position.y;
        float FinalPos1 = LoadGamePos.position.y;
        for (float i = StartPos1 + 50f; i > FinalPos1; i -= 1f)
        {
            Image LoadGameAlpa = LoadGame.GetComponent<Image>();
            TextMeshProUGUI TextAlpa = LoadGame.GetComponentInChildren<TextMeshProUGUI>();
            float NewAlpa = LoadGameAlpa.color.a;
            NewAlpa += 0.02f;
            LoadGameAlpa.color = new Color(LoadGameAlpa.color.r, LoadGameAlpa.color.g, LoadGameAlpa.color.b, NewAlpa);
            TextAlpa.color = new Color(TextAlpa.color.r, TextAlpa.color.g, TextAlpa.color.b, NewAlpa);
            LoadGamePos.position = new Vector3(LoadGamePos.position.x, i, LoadGamePos.position.z);
            yield return new WaitForSeconds(0.01f);
        }

        RectTransform CollectionPos = Collection.GetComponent<RectTransform>();
        float StartPos2 = CollectionPos.position.y;
        float FinalPos2 = CollectionPos.position.y;
        for (float i = StartPos2 + 50f; i > FinalPos2; i -= 1f)
        {
            Image CollectionAlpa = Collection.GetComponent<Image>();
            TextMeshProUGUI TextAlpa = Collection.GetComponentInChildren<TextMeshProUGUI>();
            float NewAlpa = CollectionAlpa.color.a;
            NewAlpa += 0.02f;
            CollectionAlpa.color = new Color(CollectionAlpa.color.r, CollectionAlpa.color.g, CollectionAlpa.color.b, NewAlpa);
            TextAlpa.color = new Color(TextAlpa.color.r, TextAlpa.color.g, TextAlpa.color.b, NewAlpa);
            CollectionPos.position = new Vector3(CollectionPos.position.x, i, CollectionPos.position.z);
            yield return new WaitForSeconds(0.01f);
        }

        RectTransform ExitPos = Exit.GetComponent<RectTransform>();
        float StartPos3 = ExitPos.position.y;
        float FinalPos3 = ExitPos.position.y;
        for (float i = StartPos3 + 50f; i > FinalPos3; i -= 1f)
        {
            Image ExitAlpa = Exit.GetComponent<Image>();
            TextMeshProUGUI TextAlpa = Exit.GetComponentInChildren<TextMeshProUGUI>();
            float NewAlpa = ExitAlpa.color.a;
            NewAlpa += 0.02f;
            ExitAlpa.color = new Color(ExitAlpa.color.r, ExitAlpa.color.g, ExitAlpa.color.b, NewAlpa);
            TextAlpa.color = new Color(TextAlpa.color.r, TextAlpa.color.g, TextAlpa.color.b, NewAlpa);
            ExitPos.position = new Vector3(ExitPos.position.x, i, ExitPos.position.z);
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }
}
