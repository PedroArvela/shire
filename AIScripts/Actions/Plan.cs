using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.AI.Deciders;
using Scripts.AI.Beliefs;

namespace Scripts.AI.Actions
{
    public class Plan : AIAction
    {

        public DeciderVillagerBDI decider;
        public Stack<AIAction> actionPlan;
        public AIAction currentAction;
        public List<string> Goal;
        public bool suceeded = false;

        public Plan(Stack<AIAction> actions, DeciderVillagerBDI dec)
        {
            decider = dec;
            actionPlan = actions;

        }

        public override void Execute(GameObject go)
        {
            
            if(currentAction == null)
            {
                currentAction = actionPlan.Pop();
            }

            bool readyStep = true;

            foreach (string s in actionPlan.Peek().preConditions)
            {
                bool tempStep = false;
                foreach (Belief b in decider.beliefs)
                {
                    if (b != null && b.conditions.Exists(cond => cond.Equals(s)))
                    {

                        tempStep = true;
                        break;
                    }
                }

                if (!tempStep) { readyStep = false; break; }

            }

            if (readyStep)
            {
                currentAction = actionPlan.Pop();
                if (currentAction.preConditions.Count > 0)
                {
                    currentAction.target = decider.beliefs.Find(b => b.conditions.Contains(currentAction.preConditions[0])).Subject;
                }
            }

            if(currentAction != null)
            {
                currentAction.Execute(go);

            } else
            {

                suceeded = true;
                go.GetComponent<NavMeshAgent>().Stop();
                
                go.GetComponent<Animator>().SetBool("isWalking", false);
                go.GetComponent<Animator>().SetBool("isRunning", false);
                go.GetComponent<Animator>().SetBool("isAttacking", false);
            }
            


        }




    }
}