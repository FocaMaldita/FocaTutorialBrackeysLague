using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Generic Item", menuName="Inventory/Generic Item")]
public class Item : ScriptableObject{
    public string itemName = "New name";
    public string itemDescription = "Description of said item";
    public Sprite icon = null;
    public bool isDefault = false;
}
