using UnityEngine;
using System.Collections;


namespace Scripts.AI.Actions
{

    public class GoToTarget : Action
    {

        public Vector3 position { get; set; }
        private float stopDistance { get; set; }


        public GoToTarget(Vector3 pos)
        {
            position = pos;
            Name = "GoToTarget";

        }

        public override void Execute()
        {
            if (Vector3.Distance(this.transform.position, position) < stopDistance)
            {

                this.GetComponent<NavMeshAgent>().SetDestination(position);
                this.GetComponent<NavMeshAgent>().Resume();

            }
            else
            {

                this.GetComponent<NavMeshAgent>().Stop();

            }
        }




    }
}