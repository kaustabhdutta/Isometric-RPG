using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Animator anim;
    public float turnSpeed = 75;
    public float moveSpeed = 5f;
     
    void Start ()
    {
        anim = GetComponent<Animator>();
        //player = GetComponent<GameObject>(); 
	} 
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            anim.Play("Walk"); 
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            anim.Play("Walk");
        }            

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            anim.Play("Walk");
        }            

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            anim.Play("Walk");
        }
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            anim.Play("Attack");
        }
        if(Input.GetKey(KeyCode.RightShift))
        {
            Debug.Log("key is pressed");
            anim.Play("Run");
        }
    } 
}
