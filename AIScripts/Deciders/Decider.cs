using UnityEngine;
using System.Collections;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;


namespace Scripts.AI.Deciders
{
    public abstract class Decider : MonoBehaviour
    {

        public string Name;

        public abstract Action Decide(Perception[] perceptions);
        
        
    }
}