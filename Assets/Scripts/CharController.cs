using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4.0f;

    Vector3 forward, right;
    Animator anim;

    [SerializeField]
    private Stat health;

    bool attacking = false;

    void Awake()
    {
        health.Initialize();
    }
    
    void Start ()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
        anim = GetComponent<Animator>(); 
    }
	
	void Update ()
    {
        if (Input.anyKey)
             move(); 
        if (Input.GetKey(KeyCode.Space))
        {
            if(!attacking)
                Attack();
            health.CurrentVal -= 10;
        }
    }
    void move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"),0,Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
        // anim.Play("Walk");
        Walk();
    }
    
    void Idle()
    {
        anim.SetInteger("Condition",0);
    }
    void Attack()
    {
        anim.SetInteger("Condition",1);
        StartCoroutine(AttackRoutine());
    }
    void Walk()
    {
        Debug.Log("walk animation");
        anim.SetInteger("Condition", 2);
    }
    void Death()
    {
        anim.SetInteger("Condition",3);
    }
    IEnumerator AttackRoutine()
    {
        attacking = true;
        yield return new WaitForSeconds(0.5f);
        attacking = false;
    }
}
