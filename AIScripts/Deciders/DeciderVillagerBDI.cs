using UnityEngine;
using System.Collections;
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
		List<Befief> beliefs;
		List<Desire> desires;
		List<Intention> intentions;
		List<AIAction> plan;

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
			return false;
		}

		private bool planIsPossible ()
		{
			return false;
		}

		private bool planSucceeded ()
		{
			return false;
		}

		private bool shouldReconsider ()
		{
			return false;
		}
	}
}