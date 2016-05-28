﻿using UnityEngine;
using Scripts.AI.Deciders;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using Scripts.Utils;
using System.Collections.Generic;


namespace Scripts.AI.Characters
{
    public class VillagerScript : CharacterScript
    {
        

        // Use this for initialization
        void Start()
        {
            decider = this.gameObject.AddComponent<DeciderVillagerReactive>();
           
            

        }

        
    }
}