using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;

    private void OnEnable() {
        //Subscribe all movement events.
        InputManager.MoveUpEvent += MoveUp;
        InputManager.MoveDownEvent += MoveDown;
        InputManager.MoveRightEvent += MoveRight;
        InputManager.MoveLeftEvent += MoveLeft;
    }

    private void OnDisable() {
        //Unsubscribe all movement events.
        InputManager.MoveUpEvent -= MoveUp;
        InputManager.MoveDownEvent -= MoveDown;
        InputManager.MoveRightEvent -= MoveRight;
        InputManager.MoveLeftEvent -= MoveLeft;
    }

    private void Move(Vector3 dir) {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void MoveUp() { Move(Vector3.up); }
    private void MoveDown() { Move(-Vector3.up); }
    private void MoveLeft() { Move(-Vector3.right); }
    private void MoveRight() { Move(Vector3.right); }
}
