using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>{
    #region DELEGATE FUNCTIONS
    public delegate void KeyPress();
    public static event KeyPress MoveUpEvent;
    public static event KeyPress MoveDownEvent;
    public static event KeyPress MoveLeftEvent;
    public static event KeyPress MoveRightEvent;
    #endregion

    private void Update() {
        if (Input.GetButton("Up") && MoveUpEvent != null) MoveUpEvent();
        if (Input.GetButton("Down") && MoveDownEvent != null) MoveDownEvent();
        if (Input.GetButton("Left") && MoveLeftEvent != null) MoveLeftEvent();
        if (Input.GetButton("Right") && MoveRightEvent != null) MoveRightEvent();
    }
}
