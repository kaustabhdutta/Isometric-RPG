using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    Vector3 offset;

    public float smoothFactor = 0.5f;

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - playerTransform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void LateUpdate()
    {
        Vector3 newPos = playerTransform.position + offset;
        transform.position = Vector3.Slerp(transform.position,newPos,smoothFactor);
    }
}
