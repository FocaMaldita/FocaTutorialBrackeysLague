using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public float radius = 3f;
    public bool isFocused = false;
    public bool hasInteracted = false;
    public Transform player;

    public virtual void InteractWith(){
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAA");
    }
    
    void Update(){
        if(isFocused && !hasInteracted){
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= radius){
                hasInteracted=true;
                InteractWith();
            }
        }
    }
    public void OnFocused(Transform playerTransform){
        isFocused=true;
        hasInteracted = false;
        player = playerTransform;
    }

    public void OnDefocused(){
        isFocused = false;
        hasInteracted = false;
        player = null;
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
