using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactible onFocus;
    public LayerMask moveMask;
    PlayerMotor playerMotor;
    Camera cam;

    // Start is called before the first frame update
    void Start(){
        playerMotor = GetComponent<PlayerMotor>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100, moveMask)){
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                playerMotor.MoveToPoint(hit.point);
                RemoveFocus();
            }
            if(Input.GetMouseButtonDown(1)){
                if(Physics.Raycast(ray,out hit)){
                    Interactible interactible = hit.collider.GetComponent<Interactible>();
                    if(interactible!=null){
                        SetFocus(interactible);
                    }
                }
            }
        }
    }

    void SetFocus(Interactible focus){
        if(onFocus != focus){
            if(onFocus != null){
                onFocus.OnDefocused();
            }
            onFocus = focus;
            playerMotor.FollowTarget(focus);
        }
        focus.OnFocused(transform);
    }

    void RemoveFocus(){
        if(onFocus != null){
            onFocus.OnDefocused();
        }
        onFocus = null;
        playerMotor.StopFollowingTarget();
    }
}
