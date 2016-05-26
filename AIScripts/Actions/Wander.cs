using UnityEngine;
using System.Collections;

namespace Scripts.AI.Actions
{

    public class Wander : Action
    {

        public Vector3 position { get; set; }
        private float stopDistance { get; set; }


        public Wander()
        {
            
            Name = "Wander";

        }

        public override void Execute()
        {

            //this.GetComponent<Animator>().SetBool("isWalking", true);
            NavMeshHit myNavHit;
            Vector3 tg = this.gameObject.transform.forward.normalized * 10;

            tg = Quaternion.AngleAxis((Random.value * 20) - 10, Vector3.up) * tg;
            tg = tg + this.transform.position;
            if (NavMesh.SamplePosition(tg, out myNavHit, 100, -1))
            {

                this.GetComponent<NavMeshAgent>().SetDestination(myNavHit.position + ((myNavHit.position - tg) * 5));
                this.GetComponent<NavMeshAgent>().Resume();
            }


        }




    }
}