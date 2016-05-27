using UnityEngine;
using System.Collections;

namespace Scripts.AI.Actions
{
	public class Wander : AIAction
	{
		public Vector3 position { get; set; }

		private float stopDistance { get; set; }

		public Wander ()
		{
			Name = "Wander";
		}

		public override void Execute (GameObject go)
		{
			NavMeshHit myNavHit;
			Vector3 tg = go.gameObject.transform.forward.normalized * 10;
			tg = Quaternion.AngleAxis ((Random.value * 20) - 10, Vector3.up) * tg;
			tg = tg + go.transform.position;

			if (NavMesh.SamplePosition (tg, out myNavHit, 100, -1)) {
				go.GetComponent<NavMeshAgent> ().SetDestination (myNavHit.position + ((myNavHit.position - tg) * 5));
				go.GetComponent<NavMeshAgent> ().Resume ();
				go.GetComponent<Animator> ().SetBool ("isWalking", true);
			}
		}
	}
}