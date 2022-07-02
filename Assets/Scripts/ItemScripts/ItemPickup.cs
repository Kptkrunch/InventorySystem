using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class ItemPickup : MonoBehaviour
{
    public float PickUpRadius = 1f;
    public InventoryItemData ItemData;

    CircleCollider2D itemCollider;

    private void Awake() {
        itemCollider = GetComponent<CircleCollider2D>();    
        itemCollider.isTrigger = true;
        itemCollider.radius = PickUpRadius;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var inventory = other.transform.GetComponent<InventoryHolder>();

        if(!inventory) {
            return;
        }

        if(inventory.InventorySystem.AddToInventory(ItemData, 1)) {
            Destroy(this.gameObject);
        }
    }
}
