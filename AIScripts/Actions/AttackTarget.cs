using UnityEngine;
using System.Collections;
using Scripts.Utils;


namespace Scripts.AI.Actions
{
    public class AttackTarget : AIAction
    {



        private GameObject attackTarget { get; set; }
        private GoToTarget Goto;
        private float attackDistance { get; set; }


        public AttackTarget(GameObject tar)
        {

            attackTarget = tar;
            Name = "AttackTarget";
            Goto = new GoToTarget(tar.transform.position);
            attackDistance = 7.0f;

        }



        public override void Execute(GameObject go)
        {
            if (Vector3.Distance(go.transform.position, attackTarget.transform.position) < attackDistance)
            {

                go.GetComponent<NavMeshAgent>().Stop();
                go.GetComponent<Animator>().SetBool("isWalking", false);



                if (go.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack") && go.GetComponent<Animator>().GetBool("isAttacking"))
                {
                    attackTarget.gameObject.GetComponent<CharacterVars>().currentHealth-=10;
                    go.GetComponent<Animator>().SetBool("isAttacking", false);
                    Debug.Log("Attack");

                } else if (!go.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {

                    go.GetComponent<Animator>().SetBool("isAttacking", true);
                }
                
                
                //attackTarget.gameObject.GetComponent<CharacterVars>().currentHealth--;
                Debug.Log(attackTarget);
                Debug.Log("Attacking");
                return;
            }
            else
            {
                Goto.position = attackTarget.transform.position;
                Goto.Execute(go);
                Debug.Log("Moving to Attack");
                return;
            }

            



        }

    }

}