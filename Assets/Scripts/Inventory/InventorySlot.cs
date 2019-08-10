using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    public Image icon;
    public Transform player;
    public Button removeButton;
    Item item;
    public void AddItem(Item newItem){
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }
    public void ClearSlot(){
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton(){
        GameObject.Instantiate(item.itemItself,new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z),Quaternion.LookRotation(new Vector3(player.transform.position.x, 0f, player.transform.position.z)));
        Inventory.instance.Remove(item);
        Inventory.instance.Remove(item); 
    }

    public void UseItem(){
        item.Use();
    }
}
