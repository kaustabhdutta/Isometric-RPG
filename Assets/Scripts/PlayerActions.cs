using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Animator anim;
    public float turnSpeed = 75.0f;
    public float moveSpeed = 5.0f;
    public bool isWalking; 
     
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
        //Mark: Player run movement
        if(Input.GetKey(KeyCode.M))
        {
            Debug.Log("Key is pressed");
             
            anim.SetBool("isRuning", true);
        }
    } 
}
