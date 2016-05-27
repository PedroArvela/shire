using UnityEngine;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using System;
using Scripts.Utils;
using System.Collections.Generic;

namespace Scripts.AI.Deciders
{
	public class DeciderVillagerReactive : Decider
	{
		public override Actions.AIAction Decide (List<Perception> perceptions)
		{
			if (perceptions.Exists (p => p.targetTag == "Orc")) {
				Debug.Log ("Decided Attack");
				List<Perception> orcs = perceptions.FindAll (p => p.targetTag == "Orc");
				return new AttackTarget (ClosestPerception (orcs).target);
			} else if (perceptions.Exists (p => p.targetTag == "Resource") && CharVars ().currentResource < CharVars ().maxResource) {
				Debug.Log ("Decided Gather");
				List<Perception> resources = perceptions.FindAll (p => p.targetTag == "Resource");
				return new GatherResource (ClosestPerception (resources).target);
			} else if (perceptions.Exists (p => p.Name == "IsNear" && p.targetTag == "Village") && CharVars ().currentResource >= CharVars ().maxResource) {
				Debug.Log ("Drop Resources");
				return new DropResources ();
			} else if (CharVars ().currentResource >= CharVars ().maxResource) {
				Debug.Log ("Go To Village: " + GameObject.FindGameObjectWithTag ("Village").transform.position);
				return new GoToTarget (GameObject.FindGameObjectWithTag ("Village").gameObject.transform.position);
			} else {
				Debug.Log ("Decided Wander");
				return new Wander ();
			}
		}
	}
}