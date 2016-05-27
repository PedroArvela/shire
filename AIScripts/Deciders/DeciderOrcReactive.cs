using UnityEngine;
using System.Collections;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using System;
using System.Collections.Generic;


namespace Scripts.AI.Deciders
{
    public class DeciderOrcReactive : Decider
    {



        public override Actions.AIAction Decide(List<Perception> perceptions)
        {
            GameObject currentVillager = null;

            foreach (Perception p in perceptions)
            {
                if (p.Name == "SeeVillager")
                {
                    if(currentVillager == null || (Vector3.Distance(currentVillager.transform.position, this.transform.position) > Vector3.Distance(p.target.transform.position, this.transform.position)))
                    {
                        currentVillager = p.target;
                    }   
                }
            }

            if (currentVillager != null)
                return new AttackTarget(currentVillager);
            else return new Wander();


        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
