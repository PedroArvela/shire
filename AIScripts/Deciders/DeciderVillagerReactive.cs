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
            if (perceptions.Exists(p => p.Name == "IsLowHealth"))
            {
                //Debug.Log ("Decided Attack");
                Name = "FleeToVillage";
                
                return new FleeToVillage();
            }
            else if(perceptions.Exists (p => p.targetTag == "Orc")) {
                //Debug.Log ("Decided Attack");
                Name = "AttackOrc";
				List<Perception> orcs = perceptions.FindAll (p => p.targetTag == "Orc");
				return new AttackTarget (ClosestPerception (orcs).target);
			} else if (perceptions.Exists(p => p.targetTag == "Resource" && p.target.GetComponent<ResourceVars>().currentResource > 0) && CharVars().currentResource < CharVars().maxResource) {
                //Debug.Log ("Decided Gather");
                Name = "Gather";
                List<Perception> resources = perceptions.FindAll(p => p.targetTag == "Resource" && p.target.GetComponent<ResourceVars>().currentResource > 0);
                return new GatherResource (ClosestPerception (resources).target);
			} else if (CharVars ().currentResource >= CharVars ().maxResource) {
                //Debug.Log ("Go To Village: " + GameObject.FindGameObjectWithTag ("Village").transform.position);
                Name = "DropResources";
                return new DropResources();
			} else {
                //Debug.Log ("Decided Wander");
                Name = "Wander";
                return new Wander ();
			}
		}
	}
}