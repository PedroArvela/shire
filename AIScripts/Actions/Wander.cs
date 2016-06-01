using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
	class WanderBare : ActionBareBone
	{
		public WanderBare ()
		{
			Name = AIActions.Wander;
			preConditions = new List<string> { };
			postConditions = new List<string> { Elements.RESOURCE_IN_SIGHT, Elements.ORC_IN_SIGHT, Elements.VILLAGER_IN_SIGHT };
		}
	}

	public class Wander : AIAction
	{
		public Vector3 position { get; set; }

		private float stopDistance { get; set; }

		public Wander ()
		{
			Name = AIActions.Wander;
			preConditions = new List<string> { };
			postConditions = new List<string> { Elements.RESOURCE_IN_SIGHT, Elements.ORC_IN_SIGHT, Elements.VILLAGER_IN_SIGHT };
		}

		public override void Execute (GameObject go)
		{
			NavMeshHit myNavHit;
			Vector3 tg = go.gameObject.transform.forward.normalized * go.GetComponent<CharacterVars> ().wanderSphereDistance;

			tg = tg + go.transform.position;
			tg = tg + (Random.insideUnitSphere * go.GetComponent<CharacterVars> ().wanderSphereRadius);

			if (NavMesh.SamplePosition (tg, out myNavHit, 100, -1)) {
				go.GetComponent<NavMeshAgent> ().SetDestination (myNavHit.position + ((myNavHit.position - tg) * 5));
				go.GetComponent<NavMeshAgent> ().speed = go.GetComponent<CharacterVars> ().walkSpeed;
				go.GetComponent<NavMeshAgent> ().Resume ();
				go.GetComponent<Animator> ().SetBool ("isWalking", true);
				go.GetComponent<Animator> ().SetBool ("isRunning", false);
				go.GetComponent<Animator> ().SetBool ("isAttacking", false);
			}
		}
	}
}