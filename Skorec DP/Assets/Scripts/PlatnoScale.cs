using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatnoScale : MonoBehaviour
{
    public Transform platno;
    public Transform lowerBall;
    public Transform upperBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upperBall.position = new Vector3 (upperBall.position.x, platno.position.y, upperBall.position.z);
        lowerBall.position = new Vector3 (lowerBall.position.x, platno.position.y, lowerBall.position.z);
        Vector3 newPosition = (upperBall.position + lowerBall.position) / 2;
        Vector3 newScale = (upperBall.position - lowerBall.position) / 10;
        newScale.y = 1;
        platno.localScale = newScale;
        platno.position = newPosition;

    }
    
}
