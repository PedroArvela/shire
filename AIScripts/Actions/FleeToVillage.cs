using UnityEngine;
using System.Collections;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
    public class FleeToVillage : AIAction
    {

        private float distanceToVillage;
        RunToTarget Goto;

        public FleeToVillage()
        {
            Name = "FleeToVillage";
            target = GameObject.FindGameObjectWithTag("Village");
            Goto = new RunToTarget(target.transform.position);
            distanceToVillage = 5.0f;
        }

        public override void Execute(GameObject go)
        {

           
                if (Vector3.Distance(go.transform.position, target.transform.position) < distanceToVillage)
                {
                go.GetComponent<NavMeshAgent>().Stop();
                go.GetComponent<Animator>().SetBool("isWalking", false);
                go.GetComponent<Animator>().SetBool("isRunning", false);
                go.transform.forward = (go.transform.position - target.transform.position).normalized;
                if (go.GetComponent<CharacterVars>().currentHealth != 100)
                {
                    go.GetComponent<CharacterVars>().currentHealth += 0.5f; 
                }


                }
                else
                {

                    Goto.Execute(go);

                }
            


        }
    }
}
