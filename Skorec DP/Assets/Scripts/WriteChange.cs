using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteChange : MonoBehaviour
{
    public bool drawPen = false;

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
        if (drawPen == true) {
            drawPen = false;
        }
        else{
            drawPen = true;
        }
    }
}
