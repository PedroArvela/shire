﻿using UnityEngine;
using System.Collections;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using System;



namespace Scripts.AI.Deciders
{
    public class DeciderOrcReactive : Decider
    {



        public override Actions.Action Decide(Perception[] perceptions)
        {
            GameObject currentVillager = null;

            foreach (Perception p in perceptions)
            {
                if (p.Name == "SeeVillager")
                {
                    if(currentVillager == null || (Vector3.Distance(currentVillager.transform.position, this.transform.position) > Vector3.Distance(p.perceptionTarget.transform.position, this.transform.position)))
                    {
                        currentVillager = p.perceptionTarget;
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
