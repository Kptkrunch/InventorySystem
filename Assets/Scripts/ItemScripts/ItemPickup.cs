using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class ItemPickup : MonoBehaviour
{

    Animator itemAnimator;
    Rigidbody2D itemRB2D;
    CircleCollider2D itemCollider;

    public float PickUpRadius = 1f;
    public InventoryItemData ItemData;



    private void Awake() {
        itemAnimator = GetComponent<Animator>();
        itemRB2D = GetComponent<Rigidbody2D>();
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
            itemAnimator.Play("CinderPuff", -1);
            Destroy(this.gameObject, itemAnimator.GetCurrentAnimatorStateInfo(0).length);

        }
    }

}

