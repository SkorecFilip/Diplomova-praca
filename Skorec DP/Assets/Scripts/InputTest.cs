using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public float pointerPressure = 0;
    public bool pointerPressed;
    public float penPressure = 0;
    public bool penTipPressed;
    public bool penIsHovering;
    public Vector2 mousePos;
    void Update()
    {

        Pointer pointer = Pointer.current;
        Pen pen = Pen.current;
        Mouse mouse = Mouse.current;
        pointerPressure = pointer.pressure.ReadValue();
        pointerPressed = pointer.press.isPressed;
        penPressure = pen.pressure.ReadValue();
        penTipPressed = pen.tip.isPressed;
        penIsHovering = pen.inRange.isPressed;
        if (mouse != null)
        {
            mousePos = mouse.position.ReadValue();

        }
    }
}
