using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraController : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 rotation;

    public float lerpSpeed;

    public bool isEnabled;

    public Transform[] followingObjects;

    public Camera controlledCamera;

    private Vector3 _followingObjectsCenter;

    void Start()
    {
    
        if(controlledCamera == null)
            controlledCamera = Camera.main;

        if(controlledCamera == null)
            Debug.LogError("No Camera Found");
    }


    void FixedUpdate()
    {
        if(isEnabled && followingObjects != null && followingObjects.Length > 0){
            _followingObjectsCenter = Vector3.zero;

            foreach(Transform t in followingObjects){
                _followingObjectsCenter += t.position;
            }
            
            _followingObjectsCenter.x /= followingObjects.Length;
            _followingObjectsCenter.y /= followingObjects.Length;
            _followingObjectsCenter.z /= followingObjects.Length;
        
            controlledCamera.transform.position = Vector3.Lerp( controlledCamera.transform.position, _followingObjectsCenter + offset, lerpSpeed);
            controlledCamera.transform.rotation = Quaternion.Lerp( controlledCamera.transform.rotation ,Quaternion.Euler(rotation), lerpSpeed );
        }   
    }
}
