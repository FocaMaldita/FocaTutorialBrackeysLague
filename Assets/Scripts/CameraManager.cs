using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform focusOn;
    public Vector3 cameraOffset;
    public float minZoom = 4f;
    public float zoomSpeed = 5f;
    public float maxZoom = 12f;
    public float minPitch = 0f;
    public float pitch = 2f;
    public float pitchDelta = 0.2f;
    public float maxPitch = 4f;
    public float yawSpeed = 100f;

    private float CurrentZoom = 10f;
    private float CurrentYaw = 0f;
    private float CurrentPitch = 2f;

    void Update(){
        CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        CurrentZoom = Mathf.Clamp(CurrentZoom, minZoom, maxZoom); 
        CurrentYaw -= Input.GetAxis("Horizontal")*yawSpeed*Time.deltaTime;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f) CurrentPitch -= CurrentPitch*pitchDelta;
        if(Input.GetAxis("Mouse ScrollWheel") < 0f) CurrentPitch += CurrentPitch*pitchDelta;
        CurrentPitch = Mathf.Clamp(CurrentPitch, minPitch, maxPitch);
    }

    void LateUpdate(){
        transform.position = focusOn.position - cameraOffset * CurrentZoom;
        transform.LookAt(focusOn.position + Vector3.up * CurrentPitch);
        transform.RotateAround(focusOn.position, Vector3.up, CurrentYaw);
    }
}
