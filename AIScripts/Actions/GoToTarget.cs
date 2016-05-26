using UnityEngine;
using System.Collections;

namespace Scripts.AI.Actions
{

	public class GoToTarget : AIAction
	{
		public Vector3 position { get; set; }

		private float stopDistance { get; set; }

		public GoToTarget (Vector3 pos)
		{
			position = pos;
			Name = "GoToTarget";

			stopDistance = 10;
		}

		public override void Execute (GameObject go)
		{
			if (Vector3.Distance (go.transform.position, position) > stopDistance) {
				go.GetComponent<NavMeshAgent> ().SetDestination (position);
				go.GetComponent<NavMeshAgent> ().Resume ();
			} else {
				Debug.Log ("Reached destination");
				go.GetComponent<NavMeshAgent> ().Stop ();
			}
		}
	}
}