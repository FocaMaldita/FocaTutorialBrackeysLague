using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactible {

    public Item item;

    public override void InteractWith(){
        base.InteractWith();
        PickUp();
    }

    public void PickUp(){
        Debug.Log("Picking up item "+item.itemName+"!");
        bool couldPickUp = Inventory.instance.Add(item);
        if(couldPickUp){
            Destroy(gameObject);
        }    
    }
}
