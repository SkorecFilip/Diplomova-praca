using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushFinger : MonoBehaviour
{
    public FingerWrite fingerWrite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.tag.Equals("Respawn"))
        {
            fingerWrite.shouldDraw = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Respawn"))
        {
            fingerWrite.shouldDraw = false;
        }
    }
}
