using UnityEngine;
using System.Collections;

namespace Scripts.AI.Perceptions
{

    public class SeeVillager : Perception
    {

        public SeeVillager(GameObject target)
        {
            Name = "SeeVillager";
            perceptionTarget = target;

        }


    }
}
