using UnityEngine;
using System.Collections;


namespace Scripts.AI.Actions
{
    public abstract class AIAction
    {



        public string Name;


        abstract public void Execute(GameObject go);



    }
}