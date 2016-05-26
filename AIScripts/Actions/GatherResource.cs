using UnityEngine;
using System.Collections;
using System;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
    public class GatherResource : Action
    {

        private GameObject targetResource;
        private GoToTarget Goto;
        private float gatherDistance { get; set; }


        public GatherResource(GameObject tar)
        {

            targetResource = tar;
            Name = "GatherResource";
            Goto = new GoToTarget(tar.transform.position);
            gatherDistance = 5.0f;

        }


        public override void Execute()
        {
            if (Vector3.Distance(this.transform.position, targetResource.transform.position) < gatherDistance)
            {

                targetResource.gameObject.GetComponent<ResourceVars>().currentResource -= 10;

            }
            else
            {

                Goto.Execute();

            }
        }

        
    }
}