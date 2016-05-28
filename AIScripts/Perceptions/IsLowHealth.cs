using UnityEngine;
using System.Collections;

namespace Scripts.AI.Perceptions
{
    public class IsLowHealth : Perception
    {
        public IsLowHealth(GameObject target)
        {
            Name = "IsLowHealth";
            this.target = target;
            targetTag = target.tag;
        }
    }
}
