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
            attackDistance = 5.0f;

        }



        public override void Execute(GameObject go)
        {
            if (Vector3.Distance(go.transform.position, attackTarget.transform.position) < attackDistance)
            {

                attackTarget.gameObject.GetComponent<CharacterVars>().currentHealth--;

            }
            else
            {

                Goto.Execute(go);

            }

            Debug.Log("Attaking");



        }

    }

}