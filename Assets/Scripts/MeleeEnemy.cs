using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;

public class MeleeEnemy : PortalTraveller
{
    public float movementSpeed = 1.0f;
    public Animator Animator;
    //public NavMeshAgent agent;
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    public float viewRadius = 5;
    public float attackRadius = 2;
    public int attackCoolDown = 2;
    public int walkCoolDown=5;
    public Transform target;
    private float attackTimeStamp = 0f;
    private float walkTimeStamp = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }

    private void Update()
    {
        //agent.enabled = false;
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= viewRadius)
        {
            FaceTarget(target);
            //agent.enabled = true;
            //agent.SetDestination(target.position);
            if (distance >= 2)
            {
                Animator.SetTrigger("walkingTrigger");
                transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime*movementSpeed);
                
            }
            
            if (distance <= attackRadius && Time.time >= attackTimeStamp)
            {
                attackTimeStamp = Time.time + attackCoolDown;
                Animator.SetTrigger("scanTrigger");
                //todo attack player
            }
        }
        else if (Time.time >= walkTimeStamp)
        {
            //agent.enabled = true;
          //  Animator.SetTrigger("walkingTrigger");
            currentWaypoint++;
            if (currentWaypoint == waypoints.Length)
            {
                currentWaypoint = 0;
            }

            //agent.SetDestination(waypoints[currentWaypoint].position);
            
            walkTimeStamp = Time.time + walkCoolDown;
        }
    }

    void FaceTarget(Transform currentTarget)
    {
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}