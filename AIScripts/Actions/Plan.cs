using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.AI.Deciders;


namespace Scripts.AI.Actions
{
    public class Plan : AIAction
    {

        DeciderVillagerBDI decider;
        Stack<AIAction> actionPlan;
        AIAction currentAction;


        public override void Execute(GameObject go)
        {
            
            if(currentAction == null)
            {
                currentAction = actionPlan.Pop();
            }


        }




    }
}