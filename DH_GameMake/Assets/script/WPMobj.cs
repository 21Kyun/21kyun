using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPMobj : MonoBehaviour
{
    public GameObject WPM_obj;
    public Material capMaterial;
    public GameObject[] gameObjects;

    private void Start()
    {
        gameObjects = MeshCut.Cut(WPM_obj, transform.position, Vector3.down, capMaterial);
    }

}