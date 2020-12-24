using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    public float viewRadius = 5;
    public float attackRadius = 2;
    public int attackCoolDown = 3;
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
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= viewRadius)
        {
            FaceTarget();
            agent.SetDestination(target.position);
            GetComponent<Animator>().SetTrigger("walkTrigger");
            if (distance <= attackRadius && Time.time >= attackTimeStamp)
            {
                attackTimeStamp = Time.time + attackCoolDown;
                GetComponent<Animator>().SetTrigger("scanTrigger");
                //todo attack player
            }
        }
        else if (Time.time >= walkTimeStamp)
        {
            
            GetComponent<Animator>().SetTrigger("walkingTrigger");
            currentWaypoint++;
            if (currentWaypoint == waypoints.Length)
            {
                currentWaypoint = 0;
            }

            agent.SetDestination(waypoints[currentWaypoint].position);
            walkTimeStamp = Time.time + walkCoolDown;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}