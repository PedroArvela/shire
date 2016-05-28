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
			beliefs = new List<Desire> ();
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