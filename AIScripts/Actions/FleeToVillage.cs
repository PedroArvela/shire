using UnityEngine;
using System.Collections.Generic;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
	class FleeToVillageBare : ActionBareBone
	{
		public FleeToVillageBare ()
		{
			Name = AIActions.FleeToVillage;
			preConditions = new List<string> { };
			postConditions = new List<string> { Elements.IS_IN_VILLAGE };
		}
	}

	public class FleeToVillage : AIAction
	{
		private float distanceToVillage;
		RunToTarget Goto;

		public FleeToVillage ()
		{
			Name = AIActions.FleeToVillage;
			target = GameObject.FindGameObjectWithTag (Elements.VILLAGE);
			Goto = new RunToTarget (target.transform.position);
			distanceToVillage = 5.0f;
			preConditions = new List<string> { };
			postConditions = new List<string> { Elements.IS_IN_VILLAGE };
		}

		public override void Execute (GameObject go)
		{
			if (Vector3.Distance (go.transform.position, target.transform.position) < distanceToVillage) {
				go.GetComponent<NavMeshAgent> ().Stop ();
				go.GetComponent<Animator> ().SetBool ("isWalking", false);
				go.GetComponent<Animator> ().SetBool ("isRunning", false);
				go.transform.forward = (go.transform.position - target.transform.position).normalized;
			} else {
				Goto.Execute (go);
			}
		}
	}
}
