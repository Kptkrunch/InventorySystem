using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlot assignedInventorySlot;

    private Button button;

    public InventorySlot AssignedInventorySlot => assignedInventorySlot;

    private void Awake() {
        ClearSlot();

        button.GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);
    }

    public void Init(InventorySlot slot) {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlot slot) {
        if(slot.ItemData != null) {
            itemSprite.sprite = slot.ItemData.Icon;
            itemSprite.color = Color.white;

            // if there is only 1 item then don't display quantity
            if(slot.StackSize > 1) {
                itemCount.text = slot.StackSize.ToString();
            } else {
                itemCount.text = "";
            }

        } else {
            ClearSlot();
        }
    }

    public void UpdateUISlot() {
        if(assignedInventorySlot != null) {
            UpdateUISlot(assignedInventorySlot);
        }
    }

    public void ClearSlot() {
        assignedInventorySlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.colot = Color.clear;
        itemCount.text = "";
    }

    public void OnUISlotClick() {
        // access display class function
    }
}