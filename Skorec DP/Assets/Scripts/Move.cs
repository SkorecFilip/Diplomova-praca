using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform position;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveN()
    {
        Vector3 halfPlane = (transform.localScale / 2) * 10;
        halfPlane.y = 0;
        transform.position = position.position + (offset + halfPlane);
    }
}

