using UnityEngine;
using System.Collections;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
	public class AttackTarget : AIAction
	{
		private GoToTarget Goto;

		private float attackDistance { get; set; }

		public AttackTarget (GameObject tar)
		{
			target = tar;
			Name = "AttackTarget";
			Goto = new GoToTarget (tar.transform.position);
			attackDistance = 7.0f;
		}

		public override void Execute (GameObject go)
		{
			Animator anim = go.GetComponent<Animator> ();

			if (Vector3.Distance (go.transform.position, target.transform.position) < attackDistance) {
				go.GetComponent<NavMeshAgent> ().Stop ();
				anim.SetBool ("isWalking", false);

				if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Attack") && anim.GetBool ("isAttacking")) {
					TargetCharVars ().currentHealth -= 10;
					anim.SetBool ("isAttacking", false);
					Debug.Log ("Attack");
				} else if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Attack")) {
					anim.SetBool ("isAttacking", true);
				}
                
				//attackTarget.gameObject.GetComponent<CharacterVars>().currentHealth--;
				Debug.Log (target);
				Debug.Log ("Attacking");
				return;
			} else {
				Goto.position = target.transform.position;
				Goto.Execute (go);
				Debug.Log ("Moving to Attack");
				return;
			}
		}
	}
}