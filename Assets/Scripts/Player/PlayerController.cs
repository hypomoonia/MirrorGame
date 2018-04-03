using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public ActionZone actionZone;
    public BoxCollider2D col;

    public float speed;

    [SerializeField] private List<Interactable> inventory;

    public delegate void Action();
    public event Action Interact;

    private void Awake() {
        gameObject.layer = Constant.PLAYER_LAYER;
        col = GetComponent<BoxCollider2D>();
        actionZone.player = this;
    }

    private void OnEnable() {
        //Subscribe all movement events.
        InputManager.MoveUpEvent += MoveUp;
        InputManager.MoveDownEvent += MoveDown;
        InputManager.MoveRightEvent += MoveRight;
        InputManager.MoveLeftEvent += MoveLeft;
        InputManager.ActEvent += Act;

        if (actionZone != null) Interact += actionZone.Interact;
    }

    private void OnDisable() {
        //Unsubscribe all movement events.
        InputManager.MoveUpEvent -= MoveUp;
        InputManager.MoveDownEvent -= MoveDown;
        InputManager.MoveRightEvent -= MoveRight;
        InputManager.MoveLeftEvent -= MoveLeft;
        InputManager.ActEvent -= Act;

        if (actionZone != null) Interact -= actionZone.Interact;
    }

    private void Move(Vector3 dir) {
        transform.position += dir * speed * Time.deltaTime;
        //Move ActionZone so it is pointing the same way the player is.
        if(actionZone != null) {
            Vector3 actionZoneDir = dir;
            actionZoneDir.x *= col.size.x;
            actionZoneDir.y *= col.size.y;
            actionZone.transform.localPosition = actionZoneDir;
        }
    }

    private void MoveUp() { Move(Vector3.up); }
    private void MoveDown() { Move(-Vector3.up); }
    private void MoveLeft() { Move(-Vector3.right); }
    private void MoveRight() { Move(Vector3.right); }

    public void Act() {
        Debug.Log("Player is trying to act!");
        if (Interact != null) Interact();
    }

    public void AddItem(Interactable item) {
        if(item != null) inventory.Add(item);
    }

    public void RemoveItem(Interactable item) {
        if (item != null) inventory.Remove(item);
    }
}
