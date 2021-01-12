using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;

public class LaserEnemy : PortalTraveller
{
    
    public float movementSpeed = 6.0f;
    public Transform centerOfPlayer;
    public Transform eyePosition;
    public LineRenderer lineRenderer;
    public Animator Animator;
    //public NavMeshAgent agent;
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    public float keepDistance = 5;
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

    private void Start()
    {
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

    }

    private void Update()
    {
        
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= viewRadius)
        {
            FaceTarget(target);
            //agent.SetDestination(target.position);
            if (distance >= 4)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime*movementSpeed);
                
            }
            
            lineRenderer.SetPosition(0, eyePosition.transform.position);
            
            if (distance <= attackRadius && Time.time >= attackTimeStamp)
            {
                RaycastHit hit;
                Animator.SetBool("isWalking", false);
                Animator.SetTrigger("scanTrigger");
                Ray ray = new Ray(eyePosition.transform.position, eyePosition.transform.forward);
                if (Physics.Raycast(ray,out hit))
                {
                   
                    if (hit.collider && hit.transform.tag.Equals("Player"))
                    {   
                        Debug.Log("Got hit");
                        lineRenderer.SetPosition(1, hit.point);
                        StartCoroutine(StopLaserCoroutine());
                        //todo attack player
                    } 
                    attackTimeStamp = Time.time + attackCoolDown;
                }
                
                
            }
            
        }
        else if (Time.time >= walkTimeStamp)
        {
            if (!Animator.GetBool("isWalking"))
            {
                Animator.SetBool("isWalking",true);
            }

            if (currentWaypoint == waypoints.Length)
            {
                currentWaypoint = 0;
            }

            //agent.SetDestination(waypoints[currentWaypoint].position);
  
            FaceTarget(waypoints[currentWaypoint]);
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime*movementSpeed);
            if (transform.position == waypoints[currentWaypoint].transform.position)
            {
                Animator.SetBool("isWalking",false);
                walkTimeStamp = Time.time + walkCoolDown;
                currentWaypoint++;
            }
            
            
        }
    }

    IEnumerator StopLaserCoroutine()
    {
        yield return new WaitForSeconds(2);
        lineRenderer.SetPosition(1, eyePosition.transform.position);
    }
    void FaceTarget(Transform currentTarget)
    {
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}