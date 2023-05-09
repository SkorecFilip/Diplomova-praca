using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Draw : MonoBehaviour
{
    public WriteChange drawPen;
    public GameObject brush;
    public bool pointerPressed;
    public bool helping = false;
    public bool paint = false;
    public float penPressure = 0;
    public Vector3 mousePos;
    public Vector3 lastPos;
    public Mouse mouse;
    LineRenderer currentLineRenderer;
    public float maxX;
    public float maxZ;
    public float maxPanelX;
    public float maxPanelZ;



    // Update is called once per frame
    void Update()
    {
        if (drawPen.drawPen == true) {
            Pointer pointer = Pointer.current;
            pointerPressed = pointer.press.isPressed;
            Pen pen = Pen.current;
            mouse = Mouse.current;
            penPressure = pen.pressure.ReadValue();
            mousePos = mouse.position.ReadValue();
            Correction();
            PointerP();
            Drawing();
        }
    }

    private void Correction()
    {
        float scaleX = maxPanelX / maxX;
        float scaleZ = maxPanelZ / maxZ;
        mousePos = new Vector3(mousePos.x*scaleX, mousePos.y * scaleZ, 0F);
    }

    void Drawing()
    {
        if (paint)
        {
            CreateBrush();
        }
        else if (penPressure > 0)
        {
            PointToMousePos();
        }
        else
        {
            //currentLineRenderer = null;
        }
    }
    
    void PointerP()
    {
        if(helping == false && pointerPressed == true)
        {
            helping = true;
            paint = true;
        }else if(helping == true && pointerPressed == true)
        {
            paint = false;
        }else if (pointerPressed == false)
        {
            helping = false;
        }

    }
    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush, Vector3.zero, Quaternion.Euler(90,0,0));
        brushInstance.transform.SetParent(transform, false);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
        currentLineRenderer.positionCount = 2;

    }
    void PointToMousePos()
    {
        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }
    void AddAPoint(Vector3 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        Debug.Log(positionIndex);
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
}
