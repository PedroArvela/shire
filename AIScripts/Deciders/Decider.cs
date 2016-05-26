using UnityEngine;
using System.Collections;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using System.Collections.Generic;


namespace Scripts.AI.Deciders
{
    public abstract class Decider : MonoBehaviour
    {

        public string Name;

        public abstract AIAction Decide(List<Perception> perceptions);
        
        
    }
}