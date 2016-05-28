using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.Utils;
using Scripts.AI.Characters;
using Scripts.AI.Perceptions;

namespace Scripts.AI.Actions
{
	public class AttackTarget : AIAction
	{
		private GoToTarget Goto;
		private GameObject self;

		private float attackDistance { get; set; }


		public AttackTarget (GameObject self, GameObject tar)
		{
			target = tar;
			this.self = self;
			Name = "AttackTarget";
			Goto = new GoToTarget (tar.transform.position);
			attackDistance = 5.0f;
		}


		public override void Execute (GameObject go)
		{
			Animator anim = go.GetComponent<Animator> ();

			if (Vector3.Distance (go.transform.position, target.transform.position) < attackDistance) {
				go.GetComponent<NavMeshAgent> ().Stop ();
				anim.SetBool ("isWalking", false);
                go.transform.forward = (target.transform.position - go.transform.position).normalized;
				if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Attack") && anim.GetBool ("isAttacking")) {
					TargetCharVars ().currentHealth -= 10;
					target.GetComponent<CharacterScript> ().nextPerceptions.Add (new AttackedMe(self));

					anim.SetBool ("isAttacking", false);
					//if(go.tag == "Orc") Debug.Log ("Attack Orc");
                    //Debug.Log(target);
                } else if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Attack")) {
					anim.SetBool ("isAttacking", true);
				}
                
				//attackTarget.gameObject.GetComponent<CharacterVars>().currentHealth--;
				
				
				return;
			} else {
				Goto.position = target.transform.position;
				Goto.Execute (go);

				return;
			}
		}
	}
}