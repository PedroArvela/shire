using UnityEngine;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using Scripts.AI.Beliefs;
using Scripts.AI.Desires;
using Scripts.AI.Intentions;
using System.Collections.Generic;

namespace Scripts.AI.Deciders
{
	public class DeciderVillagerBDI : Decider
	{
		List<Belief> beliefs;
		List<Desire> desires;
		List<Intention> intentions;
		List<AIAction> plan;

		public DeciderVillagerBDI ()
		{
			beliefs = new List<Belief> ();
			desires = new List<Desire> ();
			intentions = new List<Intention> ();
			plan = new List<AIAction> ();
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

			AIAction action = plan [0];
			plan.RemoveAt (0);
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
		}

		private void filterIntentions ()
		{
		}

		private void makePlan ()
		{
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