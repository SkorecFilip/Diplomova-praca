using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour
{
    public float MaxX;
    public float MaxY;
    public int Resolution;
    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {
        float StepX = MaxX/Resolution;
        float StepY = MaxY/Resolution;
        for (int j = 0; j <= Resolution; j++) {
            for (int i = 0; i <= Resolution; i++)
            {
                GameObject kocka = Instantiate(myPrefab, new Vector3(j * StepX, 0, i * StepY), Quaternion.identity);
                kocka.transform.SetParent(transform, false);
                //kocka.SetActive(false);
            }
        }
    }


}
