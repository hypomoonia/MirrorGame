using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable {
    public override void StartInteraction(PlayerController player) {
        base.StartInteraction(player);
        Debug.Log("Item is being picked up!");
        player.AddItem(this);
        gameObject.SetActive(false);
    }

    public override void EndInteraction(PlayerController player) {
        base.EndInteraction(player);
    }
}
