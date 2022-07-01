using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemData", menuName = "InventorySystem/InventoryItem", order = 0)]
public class InventoryItemData : ScriptableObject {
    public int ID;
    public string DisplayName;
    [TextArea(4, 4)]
    public string Description;
    public Sprite Icon;
    public int MaxStackSize;

}
