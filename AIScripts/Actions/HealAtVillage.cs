using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
	class HealAtVillageBare : ActionBareBone
	{
		public HealAtVillageBare ()
		{
			Name = AIActions.HealAtVillage;
			preConditions = new List<string> { Elements.IS_IN_VILLAGE };
			postConditions = new List<string> { Elements.IS_HEALTHY };
		}
	}

	public class HealAtVillage : AIAction
	{
		private float distanceToVillage;
		RunToTarget Goto;

		public HealAtVillage ()
		{
			Name = AIActions.HealAtVillage;
			target = GameObject.FindGameObjectWithTag (Elements.VILLAGE);
			distanceToVillage = 6.0f;
			preConditions = new List<string> { Elements.IS_IN_VILLAGE };
			postConditions = new List<string> { Elements.IS_HEALTHY };
		}

		public override void Execute (GameObject go)
		{
			if (Vector3.Distance (go.transform.position, target.transform.position) < distanceToVillage) {
				go.GetComponent<NavMeshAgent> ().Stop ();
				go.GetComponent<Animator> ().SetBool ("isWalking", false);
				go.GetComponent<Animator> ().SetBool ("isRunning", false);
				go.transform.forward = (go.transform.position - target.transform.position).normalized;
				go.GetComponent<CharacterVars> ().currentHealth++;
			}
		}
	}
}
