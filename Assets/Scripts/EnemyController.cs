using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 5.0f;
    Transform target;
    NavMeshAgent agent; 

	void Start ()
    {
       target = Player.instance.player.transform;
        //target = Player.instance.transform;
        agent = GetComponent<NavMeshAgent>();
	}
	
    void Update ()
    {
        float distance = Vector3.Distance(target.position, transform.position);
       // Debug.Log("distance:    "+ distance);
        if(distance <= lookRadius)
        {
            //Debug.Log("start attacking");
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                // Attack 
               //FaceTarget();
            }

        }
        agent.SetDestination(target.position);
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
