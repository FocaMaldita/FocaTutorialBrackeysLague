using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
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
            }
            if(Input.GetMouseButtonDown(1)){
                if(Physics.Raycast(ray,out hit)){

                }
            }
        }
    }
}
