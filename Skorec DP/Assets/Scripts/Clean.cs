using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean : MonoBehaviour
{
    public Transform brush;
    int nC;

    private void OnTriggerEnter(Collider other)
    {
            CountChildren();
            KillChildren();
            Debug.Log("reset");

    }

    void CountChildren()
    {
        nC = brush.childCount;
    }
    void KillChildren()
    {
        for(int i = nC - 1; i >= 0; i--)
        {
            Destroy(brush.GetChild(i).gameObject);
        }
    }
}
