using UnityEngine;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using System;
using System.Linq;
using Scripts.Utils;
using System.Collections.Generic;

namespace Scripts.AI.Deciders
{
	public class DeciderVillagerReactive : Decider
	{
		public override Actions.AIAction Decide (HashSet<Perception> perceptions)
		{
			if (perceptions.Where (p => p.targetTag == "Orc").Any ()) {
				Debug.Log ("Decided Attack");
				IEnumerable<Perception> orcs = perceptions.Where (p => p.targetTag == "Orc");
				return new AttackTarget (ClosestPerception (orcs).target);
			} else {
				Debug.Log ("Decided Wander");
				return new Wander ();
			}

/*			if (perceptions.Where (p => p.Name == "SeeOrc").Any ()) {
				Debug.Log ("Decided Attack");
				IEnumerable<Perception> orcs = perceptions.Where (p => p.Name == "SeeOrc");
				return new AttackTarget (ClosestPerception (orcs).target);
			} else if (perceptions.Where (p => p.Name == "SeeResource").Any () && CharVars ().currentResource < CharVars ().maxResource) {
				Debug.Log ("Decided Gather");
				IEnumerable<Perception> resources = perceptions.Where (p => p.Name == "SeeResource");
				return new GatherResource (ClosestPerception (resources).target);
			} else if (perceptions.Where (prop => prop.Name == "InVillage").Any () && CharVars ().currentResource >= CharVars ().maxResource) {
				Debug.Log ("Drop Resources");
				return new DropResources ();
			} else if (CharVars ().currentResource >= CharVars ().maxResource) {
				Debug.Log ("Go To Village: " + GameObject.FindGameObjectWithTag ("Village").transform.position);
				return new GoToTarget (GameObject.FindGameObjectWithTag ("Village").gameObject.transform.position);
			} else {
				Debug.Log ("Decided Wander");
				return new Wander ();
			}*/
		}
	}
}