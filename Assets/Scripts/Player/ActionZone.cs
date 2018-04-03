using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class ActionZone : MonoBehaviour {
    public PlayerController player;
    private BoxCollider2D _col;

    private Interactable interactableInRange;

    private void Awake() {
        _col = GetComponent<BoxCollider2D>();
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        switch (collision.gameObject.layer) {
            case Constant.INTERACTABLE_LAYER:
                Interactable item = collision.gameObject.GetComponent<Interactable>();
                if (item != null) interactableInRange = item;
                break;
            default: break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        switch (collision.gameObject.layer) {
            case Constant.INTERACTABLE_LAYER:
                Interactable item = collision.gameObject.GetComponent<Interactable>();
                if (item != null && item == interactableInRange) interactableInRange = null;
                break;
            default: break;
        }
    }

    public void Interact() {
        //Performs the desired action for an item in range.
        if (interactableInRange != null) interactableInRange.StartInteraction(player);
    }
}
