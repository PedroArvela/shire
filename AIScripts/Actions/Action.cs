using UnityEngine;
using System.Collections;


namespace Scripts.AI.Actions
{
    public abstract class Action : MonoBehaviour
    {



        public string Name;


        abstract public void Execute();



    }
}