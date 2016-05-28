using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
    public class HealAtVillage : AIAction
    {

        private float distanceToVillage;
        RunToTarget Goto;

        public HealAtVillage()
        {
            Name = "FleeToVillage";
            target = GameObject.FindGameObjectWithTag("Village");
            Goto = new RunToTarget(target.transform.position);
            distanceToVillage = 5.0f;
            preConditions = new List<string> { "IsInVillage" };
            postConditions = new List<string> { "Healthy" };

        }

        public override void Execute(GameObject go)
        {


            if (Vector3.Distance(go.transform.position, target.transform.position) < distanceToVillage)
            {
                go.GetComponent<NavMeshAgent>().Stop();
                go.GetComponent<Animator>().SetBool("isWalking", false);
                go.GetComponent<Animator>().SetBool("isRunning", false);
                go.transform.forward = (go.transform.position - target.transform.position).normalized;


            }
            else
            {

                Goto.Execute(go);

            }



        }
    }
}
