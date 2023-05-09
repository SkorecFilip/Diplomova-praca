using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public GameObject brush;
    public Material material;

    private void OnTriggerEnter(Collider other)
    {
        brush.GetComponent<LineRenderer>().material = material;      
    }
}
