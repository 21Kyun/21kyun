using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPMobj : MonoBehaviour
{
    public GameObject WPM_obj;
    //public Material capMaterial;
    //public GameObject[] gameObjects;

    //private void Start()
    //{
    //    Debug.Log("WPM_Start");
    //    gameObjects = MeshCut.Cut(WPM_obj, WPM_obj.transform.position, Vector3.down, capMaterial);
    //}
    public GameObject WPM_Drop;
    public GameObject Fire;
    public GameObject Fire_Somke;
    public ParticleSystem Fire_Somke_Particle;
    public GameObject Fire_Field;
    public CapsuleCollider Damage_Field;

    float time = 0;

    float delayTime = 0;

    private void Start()
    {
        WPM WPM_Script = (WPM)FindObjectOfType(typeof(WPM));
        //Fire_Somke.GetComponent<ParticleSystem>().duration = WPM_Script.duration;
        var Fire_Somke_Main = Fire_Somke_Particle.main;
        Fire_Somke_Main.duration = WPM_Script.duration - 6f;
        Debug.Log("start");
        Invoke("FireInsEnable", 1f);
        Destroy(WPM_obj, WPM_Script.duration + 1f);

    }

    private void FixedUpdate()
    {
        if (Fire_Field.active == true && Damage_Field.enabled == false)
        {
            Debug.Log("StartFF");
            StartCoroutine(DamageField());
        }
      
        time += Time.deltaTime;
        Debug.Log("Time = " + time);
    }

    void FireInsEnable()
    {
        StartCoroutine(FireIns(Fire_Field.transform.position));
        Fire_Field.active = enabled;
    }

    public IEnumerator FireIns(Vector3 Fire_Pos)
    {
        WPM WPM_Script = (WPM)FindObjectOfType(typeof(WPM));
        for (int i = 0; i < 5; i++)
        {
            Vector3 RandomPos = Fire_Pos;
            RandomPos.x = RandomPos.x + Random.Range(-6.5f, 6.5f);
            RandomPos.z = RandomPos.z + Random.Range(-6.5f, 6.5f);
            GameObject InstantFire = Instantiate(Fire, RandomPos, Fire.transform.rotation);
            yield return new WaitForSeconds(Random.RandomRange(0.15f, 0.35f));
            InstantFire.active = enabled;
            Destroy(InstantFire, WPM_Script.duration - 1f);
        }
        yield return null;
    }

    public IEnumerator DamageField()
    {
        Damage_Field.enabled = true;
        yield return new WaitForSeconds(0.1f);
        Damage_Field.enabled = false;
        yield return null;
    }
}