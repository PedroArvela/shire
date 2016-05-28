using UnityEngine;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using System;
using Scripts.Utils;
using System.Collections.Generic;


namespace Scripts.AI.Deciders
{
    public class DeciderOrcReactive : Decider
    {
        

		public override Actions.AIAction Decide(List<Perception> perceptions)
        {
            if (perceptions.Exists(p => p.targetTag == "Villager"))
            {
                //Debug.Log ("Decided Attack");
                Name = "AttackVillager";
                List<Perception> villagers = perceptions.FindAll(p => p.targetTag == "Villager");
                return new AttackTarget(ClosestPerception(villagers).target);
            } else
            {
                //Debug.Log ("Decided Wander");
                Name = "Wander";
                return new Wander();
            }


        }

  

    }
}
