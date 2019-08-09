using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour {
    public float radius = 3f;
    public Transform interactionTransform;
    public bool isFocused = false;
    public bool hasInteracted = false;
    public Transform player;
    public virtual void InteractWith(){
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAA");
    }
    void Update(){
        if(isFocused && !hasInteracted){
            float distance = Vector3.Distance(player.position, interactionTransform.position);
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
        if(interactionTransform == null){
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
