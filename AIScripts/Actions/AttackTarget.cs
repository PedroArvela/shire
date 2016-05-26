using UnityEngine;
using System.Collections;
using Scripts.Utils;


namespace Scripts.AI.Actions
{
    public class AttackTarget : Action
    {



        private GameObject attackTarget { get; set; }
        private GoToTarget Goto;
        private float attackDistance { get; set; }


        public AttackTarget(GameObject tar)
        {

            attackTarget = tar;
            Name = "AttackTarget";
            Goto = new GoToTarget(tar.transform.position);
            attackDistance = 5.0f;

        }



        public override void Execute()
        {
            if (Vector3.Distance(this.transform.position, attackTarget.transform.position) < attackDistance)
            {

                attackTarget.gameObject.GetComponent<CharacterVars>().currentHealth--;

            }
            else
            {

                Goto.Execute();

            }





        }

    }

}