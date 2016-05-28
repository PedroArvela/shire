using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
	public class Wander : AIAction
	{
		public Vector3 position { get; set; }

		private float stopDistance { get; set; }

		public Wander ()
		{
			Name = "Wander";
            preConditions = new List<string> { };
            postConditions = new List<string> { "ResourceInSight", "OrcInSight", "VillagerInSight" };
        }

		public override void Execute (GameObject go)
		{
			NavMeshHit myNavHit;
			Vector3 tg = go.gameObject.transform.forward.normalized * go.GetComponent<CharacterVars>().wanderSphereDistance;
            float randomAngle = (Random.value * 40) - 20;



            //tg = Quaternion.AngleAxis (randomAngle, Vector3.up) * tg;
            tg = tg + go.transform.position;

            tg = tg + (Random.insideUnitSphere * go.GetComponent<CharacterVars>().wanderSphereRadius);

            if (go.GetComponent<NavMeshAgent>().destination != null && Vector3.Distance(go.GetComponent<NavMeshAgent>().destination, go.transform.position) < 15)
            {
                //tg = Vector3.Lerp(tg, go.GetComponent<NavMeshAgent>().destination, 0.5f);
            }

            if (NavMesh.SamplePosition (tg, out myNavHit, 100, -1)) {
                
                go.GetComponent<NavMeshAgent> ().SetDestination (myNavHit.position + ((myNavHit.position - tg) * 5));
                go.GetComponent<NavMeshAgent>().speed = go.GetComponent<CharacterVars>().walkSpeed;
                go.GetComponent<NavMeshAgent> ().Resume ();
				go.GetComponent<Animator> ().SetBool ("isWalking", true);
                go.GetComponent<Animator>().SetBool("isRunning", false);
                go.GetComponent<Animator>().SetBool("isAttacking", false);

            }
		}
	}
}