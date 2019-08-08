using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake(){
        if(instance != null){
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public int sizeOfInventory = 20;
    public List<Item> items = new List<Item>();

    public bool Add(Item item){
        if(item.isDefault == false){
            if(items.Count >= sizeOfInventory){
                Debug.Log("Inventory is full.");
                return false;
            }
            items.Add(item);
            return true;
        }
        return false;
    }

    public void Remove(Item item){
        items.Remove(item);
    }
}
