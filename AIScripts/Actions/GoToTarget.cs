using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
	class GoToTargetBare : ActionBareBone
	{
		public GoToTargetBare ()
		{
			Name = AIActions.GoToTarget;
			preConditions = new List<string> { };
			postConditions = new List<string> { Elements.IS_AT_LOCATION };
		}
	}

	public class GoToTarget : AIAction
	{
		public Vector3 position { get; set; }

		private float stopDistance { get; set; }

		public GoToTarget (Vector3 pos)
		{
			position = pos;
			Name = AIActions.GoToTarget;

			stopDistance = 1;

			preConditions = new List<string> { };
			postConditions = new List<string> { Elements.IS_AT_LOCATION };
		}

		public override void Execute (GameObject go)
		{
			if (Vector3.Distance (go.transform.position, position) > stopDistance) {
				go.GetComponent<NavMeshAgent> ().SetDestination (position);
				go.GetComponent<NavMeshAgent> ().speed = go.GetComponent<CharacterVars> ().walkSpeed;
				go.GetComponent<NavMeshAgent> ().Resume ();
               
				go.GetComponent<Animator> ().SetBool ("isWalking", true);
				go.GetComponent<Animator> ().SetBool ("isRunning", false);
				go.GetComponent<Animator> ().SetBool ("isAttacking", false);
			} else {
				go.GetComponent<NavMeshAgent> ().Stop ();
				go.GetComponent<Animator> ().SetBool ("isWalking", false);
				go.GetComponent<Animator> ().SetBool ("isRunning", false);
			}
		}
	}
}