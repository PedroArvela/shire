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

            if (perceptions.Exists(p => (p.Name == "IAm" && p.attributes[Elements.HEALTH] < 70)) && Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("Village").transform.position) < 5) 
            {
                //Debug.Log ("Decided Attack");
                Name = "HealAtVillage";

                return new HealAtVillage();
            } else if (perceptions.Exists(p => (p.Name == "IAm" && p.attributes[Elements.HEALTH] < 30)))
            {
                //Debug.Log ("Decided Attack");
                Name = "FleeToVillage";
                
                return new FleeToVillage();
            }
            else if(perceptions.Exists (p => p.targetTag == "Orc")) {
                //Debug.Log ("Decided Attack");
                Name = "AttackOrc";
				List<Perception> orcs = perceptions.FindAll (p => p.targetTag == "Orc");
				return new AttackTarget (gameObject, ClosestPerception (orcs).target);
			} else if (perceptions.Exists(p => p.targetTag == "Resource") && perceptions.Exists(p => (p.Name == "IAm" && p.attributes[Elements.RESOURCE] < p.attributes[Elements.MAX_RESOURCE]))) {
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