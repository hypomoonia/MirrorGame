using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Interactable : MonoBehaviour {
    protected Rigidbody2D rigidbody;
    
    protected virtual void Awake() {
        gameObject.layer = Constant.INTERACTABLE_LAYER;
    }

    public virtual void StartInteraction(PlayerController player) {
        Debug.Log("Interaction with " + gameObject + " started!");
    }

    public virtual void EndInteraction(PlayerController player) {
        Debug.Log("Interaction with " + gameObject + " ended!");
    }
}
