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


	public class DeciderVillagerBDI : Decider
	{
		public List<Belief> beliefs;
		List<Desire> desires;
		Intention currentIntention;
		Plan plan;
		Emotion blankEmotion = new Emotion ();

		public DeciderVillagerBDI ()
		{
			beliefs = new List<Belief> ();
			desires = new List<Desire> ();
			//intentions = new List<Intention> ();
			//plan = new Stack<AIAction> ();
			blankEmotion.intensity = 0;
			blankEmotion.valence = 0;
		}

		public override AIAction Decide (List<Perception> perceptions)
		{
			reviseBeliefs (perceptions);

			if (plan == null || planSucceeded () || !planIsPossible ()) {
				if (shouldReconsider ()) {
					deliberateDesires ();
					filterIntentions ();
				}

				if (planSucceeded () || !planIsPossible () || !planIsSound ()) {
					makePlan ();
				}
			}

			return plan;
		}

		public void reviseBeliefs (List<Perception> perceptions)
		{
			// Add new beliefs
			foreach (Perception perception in perceptions) {
				if (!beliefs.Exists (b => b.Subject.Equals (perception.target))) {
					if (perception.target.Equals (gameObject)) {
						beliefs.Add (new IExist (gameObject));

					} else {
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

			// Update each belief
			foreach (Belief b in beliefs) {
				b.updateBelief (perceptions);
			}

			// Remove all beliefs no longer certain
			//beliefs.RemoveAll (b => b.Uncertain ());
		}

		private void deliberateDesires ()
		{
			if (!desires.Exists (d => d.Type ().Equals (DesireType.BeHealthy))) {
				desires.Add (new BeHealthy (gameObject));
			}
			if (!desires.Exists (d => d.Type ().Equals (DesireType.ExterminateOrcs))) {
				desires.Add (new ExterminateOrcs (gameObject));
			}
			if (!desires.Exists (d => d.Type ().Equals (DesireType.GatherResources))) {
				desires.Add (new GatherResources (gameObject));
			}

			foreach (Desire desire in desires) {
				desire.updateDesire (beliefs, blankEmotion);
			}

			//desires.RemoveAll (d => d.intensity < 0.05f);
		}

		private void filterIntentions ()
		{
			Desire choosenDesire = null;

			foreach (Desire d in desires) {
				if (choosenDesire == null) {
					choosenDesire = d;
					continue;
				}

				if (d.intensity < choosenDesire.intensity) {
					choosenDesire = d;
				}
			}

			if (choosenDesire != null) {
				switch (choosenDesire.Type ()) {
				case DesireType.GatherResources:
					currentIntention = new IncreaseVillageResources ();
					break;
				case DesireType.ExterminateOrcs:
					currentIntention = new KillOrcs ();
					break;
				case DesireType.BeHealthy:
					currentIntention = new BecomeHealthy ();
					break;
				}
			}

		}

		private void makePlan ()
		{
			List<ActionBareBone> possibleActions = new List<ActionBareBone> {
				new WanderBare (),
				new AttackTargetBare (),
				new FleeToVillageBare (),
				new DropResourcesBare (),
				new GatherResourceBare ()
			};
			List<ActionBareBone> newPlanBareBone = new List<ActionBareBone> ();
			Stack<AIAction> newPlan = new Stack<AIAction> ();

			Stack<string> currentConditions = new Stack<string> ();
			currentConditions.Push (currentIntention.Goal);

			while (currentConditions.Count > 0) {
				string preCondition = currentConditions.Pop ();
				ActionBareBone possibleAction = possibleActions.Find (action => action.postConditions.Contains (preCondition));
				if (possibleAction != null) {
					newPlanBareBone.Add (possibleAction);
					foreach (string s in possibleAction.preConditions) {
						currentConditions.Push (s);
					}
					//continue;
				} 

			}

			foreach (ActionBareBone abb in newPlanBareBone) {
                
				switch (abb.Name) {
				case AIActions.GoToTarget:
					newPlan.Push (new GoToTarget (new Vector3 (0, 0, 0)));
					break;
				case AIActions.FleeToVillage:
					newPlan.Push (new FleeToVillage ());
					break;
				case AIActions.DropResources:
					newPlan.Push (new DropResources ());
					break;
				case AIActions.GatherResources:
					newPlan.Push (new GatherResource (null));
					break;
				case AIActions.Wander:
					newPlan.Push (new Wander ());
					break;
				case AIActions.Attack:
					newPlan.Push (new AttackTarget (gameObject, null));
					break;
				case AIActions.HealAtVillage:
					newPlan.Push (new HealAtVillage ());
					break;
				}

				return;
			}

			if (newPlan.Count == 0) {
				Debug.Log ("Catastrophic failure");
				return;
			}

			plan = new Plan (newPlan, this);

			plan.Goal = newPlanBareBone [0].postConditions;

		}

		private bool planIsSound ()
		{
			return (plan != null && plan.Goal.Exists (str => str.Equals (currentIntention.Goal)));
		}

		private bool planIsPossible ()
		{
			return true;
		}

		private bool planSucceeded ()
		{
			return plan != null && plan.Succeeded ();
		}

		private bool shouldReconsider ()
		{
			return true;
		}
	}
}