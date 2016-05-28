using UnityEngine;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using Scripts.AI.Beliefs;
using Scripts.AI.Desires;
using Scripts.AI.Intentions;
using System.Collections.Generic;
using Scripts.AI.Emotions;
using System;

namespace Scripts.AI.Deciders
{
	public class DeciderVillagerEmotional : Decider
	{
		List<Belief> beliefs;
		List<Desire> desires;
		List<Intention> intentions;
		Emotion primaryEmotion;
		List<Emotion> emotions;
		List<AIAction> plan;

		public DeciderVillagerEmotional ()
		{
			beliefs = new List<Belief> ();
			desires = new List<Desire> ();
			intentions = new List<Intention> ();
			emotions = new List<Emotion> ();
			plan = new List<AIAction> ();
		}

		public override AIAction Decide (List<Perception> perceptions)
		{
			reviseBeliefs (perceptions);
			appraiseEmotions (beliefs);

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

		private void appraiseEmotions (List<Belief> beliefs)
		{
			foreach (Belief belief in beliefs) {
				Emotion emotion;

				if (emotions.Exists (e => e.target.Equals (belief.Subject))) {
					emotion = emotions.Find (e => e.target.Equals (belief.Subject));
				} else {
					emotion = new Emotion ();
					emotion.valence = 0f;
					emotion.intensity = 0f;
				}

				belief.appraise (emotion);
			}

			float totalValence = 0f;
			float totalIntensity = 0f;

			foreach (Emotion e in emotions) {
				totalValence += (float)Math.Pow (e.valence, 2);
				totalIntensity += (float)Math.Pow (e.intensity, 2);
			}

			totalValence = totalValence / emotions.Count;
			totalIntensity = totalIntensity / emotions.Count;

			if (totalValence > 1f) {
				totalValence = 1f;
			} else if (totalValence < -1f) {
				totalValence = -1f;
			}

			if (totalIntensity > 1f) {
				totalIntensity = 1f;
			} else if (totalIntensity < -1f) {
				totalIntensity = -1f;
			}

			primaryEmotion.valence = totalValence;
			primaryEmotion.intensity = totalIntensity;
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
				desire.updateDesire (beliefs, primaryEmotion);
			}

			desires.RemoveAll (d => d.intensity < 0.05f);
		}

		private void filterIntentions ()
		{


		}

		private void makePlan ()
		{


		}

		private bool planIsSound ()
		{
			return planIsPossible () && plan.Count != 0;
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