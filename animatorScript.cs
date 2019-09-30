using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorScript : StateMachineBehaviour {
	public bool willAttack;
	public bool IsLastAttack;
	//public string CurAttackButton;
	public PlayerController attackValues;
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		willAttack = false;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		//CurAttackButton = attackValues.AttackButton;
		//if (!IsLastAttack)
		//{
		//	if ((!willAttack)&&(Input.GetKeyDown(CurAttackButton)))
		//	{
		//		animator.SetTrigger("Attack");
		//		willAttack = true;
		//	}
		//	else if (!willAttack)
		//	{
		//		animator.SetBool("Attack", false);
		//	}
		//}
		//else
		//{
		//	animator.SetBool("Attack", false);
		//}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		willAttack = false;
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
