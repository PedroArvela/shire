using UnityEngine;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using Scripts.AI.Beliefs;
using Scripts.AI.Desires;
using Scripts.AI.Intentions;
using System.Collections.Generic;
using Scripts.AI.Emotions;

namespace Scripts.AI.Deciders
{


    abstract class ActionBareBone
    {

        public string actionName;
        public List<string> preConditions;
        public List<string> postConditions;

    }

    class GoToTargetBare : ActionBareBone
    {

        public GoToTargetBare()
        {
            actionName = "GoToTarget";
            preConditions = new List<string> { };
            postConditions = new List<string> { "IsAtLocation" };
        }
    }

    class WanderBare : ActionBareBone
    {

        public WanderBare()
        {
            actionName = "Wander";
            preConditions = new List<string> { };
            postConditions = new List<string> { "ResourceInSight", "OrcInSight", "VillagerInSight" };
        
        }
    }

    class AttackTargetBare : ActionBareBone
    {

        public AttackTargetBare()
        {
            actionName = "AttackTarget";
            preConditions = new List<string> { "OrcInSight", "Healthy" };
            postConditions = new List<string> { "OrcIsDead" };
        }
    }

    class FleeToVillageBare : ActionBareBone
    {

        public FleeToVillageBare()
        {
            actionName = "FleeToVillage";
            preConditions = new List<string> { };
            postConditions = new List<string> { "IsInVillage" };
        }
    }

    class DropResourcesBare : ActionBareBone
    {

        public DropResourcesBare()
        {
            actionName = "DropResources";
            preConditions = new List<string> { "HasResources" };
            postConditions = new List<string> { "VillageIncreasedResources", "IsInVillage" };
        }
    }


    class GatherResourceBare : ActionBareBone
    {

        public GatherResourceBare()
        {
            actionName = "GatherResource";
            preConditions = new List<string> { "ResourceInSight" };
            postConditions = new List<string> { "HasResources" };
        }
    }


    public class DeciderVillagerBDI : Decider
	{
		List<Belief> beliefs;
		List<Desire> desires;
		Intention currentIntention;
		Stack<AIAction> plan;
		Emotion blankEmotion;

        


		public DeciderVillagerBDI ()
		{
			beliefs = new List<Belief> ();
			desires = new List<Desire> ();
			//intentions = new List<Intention> ();
			plan = new Stack<AIAction> ();
			blankEmotion.intensity = 0;
			blankEmotion.valence = 0;
		}

		public override AIAction Decide (List<Perception> perceptions)
		{
			reviseBeliefs (perceptions);

			if (plan.Count == 0 || planSucceeded () || !planIsPossible ()) {
				if (shouldReconsider ()) {
					deliberateDesires ();
					filterIntentions ();
				}

				if (!planIsSound ()) {
					makePlan ();
				}
			}

            //execute plan?
			AIAction action = plan.Pop();
			//plan.RemoveAt (0);
			return action;
		}

		private void reviseBeliefs (List<Perception> perceptions)
		{
			// Update each belief
			foreach (Belief b in beliefs) {
				b.updateBelief (perceptions);
			}

			// Remove all beliefs no longer certain
			beliefs.RemoveAll (b => b.Uncertain ());

			// Add new beliefs
			foreach (Perception perception in perceptions) {
				if (!beliefs.Exists (b => b.Subject.Equals (perception.target))) {
					switch (perception.targetTag) {
					case "Orc":
						beliefs.Add (new OrcExists (perception.target));
						break;
					case "Villager":
						beliefs.Add (new VillagerExists (perception.target));
						break;
					case "Resource":
						beliefs.Add (new ResourceExists (perception.target));
						break;
					case "Village":
						beliefs.Add (new VillageExists (perception.target));
						break;
					}
				}
			}
		}

		private void deliberateDesires ()
		{
			if (desires.Exists (d => d.Type () == "BeHealthy")) {
				desires.Add (new BeHealthy (gameObject));
			}
			if (desires.Exists (d => d.Type () == "ExterminateOrcs")) {
				desires.Add (new ExterminateOrcs (gameObject));
			}
			if (!desires.Exists (d => d.Type () == "GatherResources")) {
				desires.Add (new GatherResources (gameObject));
			}

			foreach (Desire desire in desires) {
				desire.updateDesire (beliefs, blankEmotion);
			}

			desires.RemoveAll (d => d.intensity < 0.05f);
		}

		private void filterIntentions ()
		{


		}

		private void makePlan ()
		{
            List<ActionBareBone> possibleActions = new List<ActionBareBone> { new WanderBare(), new AttackTargetBare(), new FleeToVillageBare(), new DropResourcesBare(),  new GatherResourceBare()};
            List<ActionBareBone> newPlanBareBone = new List<ActionBareBone>();
            Stack<AIAction> newPlan = new Stack<AIAction>();
            Stack<string> currentConditions = new Stack<string>();
            currentConditions.Push(currentIntention.Goal);

            while(currentConditions.Count > 0)
            {
                string preCondition = currentConditions.Pop();
                ActionBareBone possibleAction = possibleActions.Find(action => action.postConditions.Contains(preCondition));
                if (possibleAction != null)
                {
                    newPlanBareBone.Add(possibleAction);
                    foreach(string s in possibleAction.preConditions)
                    {
                        currentConditions.Push(s);
                    }
                    //continue;
                } 

            }

            

            foreach (ActionBareBone abb in newPlanBareBone)
            {
                
                switch (abb.actionName) {

                    case "GoToTarget": newPlan.Push(new GoToTarget(new Vector3(0,0,0))); break;
                    case "FleeToVillage": newPlan.Push(new FleeToVillage()); break;
                    case "DropResources": newPlan.Push(new DropResources()); break;
                    case "GatherResource": newPlan.Push(new GatherResource(null)); break;
                    case "Wander": newPlan.Push(new Wander()); break;
                    case "AttackTarget": newPlan.Push(new AttackTarget(gameObject, null)); break;

                }

            }


            plan = newPlan;

        }

		private bool planIsSound ()
		{
			return plan.Count != 0;
		}

		private bool planIsPossible ()
		{
			return true;
		}

		private bool planSucceeded ()
		{
			return false;
		}

		private bool shouldReconsider ()
		{
			return true;
		}
	}
}