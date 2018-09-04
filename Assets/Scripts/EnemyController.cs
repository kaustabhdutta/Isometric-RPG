using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 5.0f;
    Transform target;
    NavMeshAgent agent;
    bool walk;
    //public GameObject player;

   Animator anim;

	void Start ()
    {
        target = Player.instance.player.transform; 
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
	}
	
    void Update ()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        
        if(distance <= lookRadius)
        {
            //Debug.Log("start attacking");
            agent.SetDestination(target.position);
              anim.Play("Walk");
            // anim.SetBool("walk", true);
            //anim.SetBool("idle", false); 
            if (distance <= agent.stoppingDistance)
            {
                // Attack 
                anim.Play("Attack");
            }

        }
        else
        {
            //  debug.log("not attacking");
            // anim.setbool("walk", false);
            //anim.setbool("idle", true);
            anim.Play("Idle");
        }


    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
     
}
