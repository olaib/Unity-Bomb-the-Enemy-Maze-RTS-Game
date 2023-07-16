using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class patrolState : StateMachineBehaviour
{
    Transform player;
    float chaseRange = 8;
    float timer;
    float patrolTime = 10;
    NavMeshAgent agent;
    List<Transform> waypoints = new List<Transform>();
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        // dragon agent navmesh
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = 1.5f;
        GameObject go = GameObject.FindGameObjectWithTag("Waypoints");
        
        foreach (Transform t in go.transform)
            waypoints.Add(t);
        
        float dist = Vector3.Distance(animator.transform.position,player.position);
        if(dist < chaseRange)
        {
            animator.SetBool("isChasing",true);
        }
        agent.SetDestination(waypoints[Random.Range(0,waypoints.Count)].position);
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(waypoints[Random.Range(0,waypoints.Count)].position);

        timer += Time.deltaTime;

        if(timer > patrolTime)
            animator.SetBool("isPatrolling",false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
