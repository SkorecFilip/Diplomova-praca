using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FingerWrite : MonoBehaviour
{
    public WriteChange drawPen;
    public OVRSkeleton skeleton;
    public GameObject pokeCube;
    public Vector3 trans;
    public GameObject brush;
    LineRenderer currentLineRenderer;
    public Vector3 lastPos;
    public float maxX;
    public float maxZ;
    public float maxPanelX;
    public float maxPanelZ;
    public bool draw = false;
    public bool shouldDraw;

    private OVRBone tip = null;


    // Start is called before the first frame update
    void Start()
    {
        //List<OVRBone> fingerbones = new List<OVRBone>(skeleton.Bones);
        //OVRBone tip = fingerbones.Find(bone => bone.Id.Equals(OVRSkeleton.BoneId.Body_LeftHandIndexTip));
        //trans = tip.Transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (tip == null) {
            List<OVRBone> fingerbones = new List<OVRBone>(skeleton.Bones);
            tip = fingerbones.Find(bone => bone.Id.Equals(OVRSkeleton.BoneId.Hand_IndexTip));
            if (tip == null) return;
        }

        trans = tip.Transform.position;
        pokeCube.transform.position = trans;
        Correction();

        if (drawPen.drawPen == false)
        {
            IsDrawing();
            if (draw == true)
            {
                if (lastPos != trans)
                {
                    AddAPoint(trans);
                    lastPos = trans;
                }

            }
        }
        

    }

    private void Correction()
    {
        Vector3 parentPostion = transform.position;
        float x = trans.x - parentPostion.x;
        float y = trans.y - parentPostion.y;
        float z = trans.z - parentPostion.z;
        Vector3 halfPlane = transform.parent.transform.localScale;      
        trans = new Vector3(x * (1 / halfPlane.x), z * (1 / halfPlane.z), 0F);

    }

    private void IsDrawing()
    {
        
        if (draw == false && shouldDraw)
        {
            StartLine();
            draw = true;
        }
        draw = shouldDraw;
    }

    private void StartLine()
    {
        GameObject brushInstance = Instantiate(brush, Vector3.zero, Quaternion.Euler(90, 0,0 ));
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        //Debug.LogWarning("Institiate prebehol");
        currentLineRenderer.SetPosition(0, trans);
        currentLineRenderer.SetPosition(1, trans);
        currentLineRenderer.positionCount = 2;
        brushInstance.transform.SetParent(transform, false);
    }

    void AddAPoint(Vector3 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
}
