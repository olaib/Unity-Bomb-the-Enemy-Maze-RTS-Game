using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttakeState : StateMachineBehaviour
{
    Transform player;
    public float atackRange = 3.5f;
    [SerializeField]
    [Header("Attack Interval")]
    public float attackInterval = 2f;
    private float damage = 10f;

    private float attackTimer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackTimer = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float dist = Vector3.Distance(animator.transform.position,player.position);

        if(dist > atackRange)
            animator.SetBool("isAttaking",false);

        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0)
        {
            AttackPlayer(animator);
            attackTimer = attackInterval;  // Reset the attack timer
        }

    }

    private void AttackPlayer(Animator animator)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
            playerHealth.TakeDamage(damage);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
