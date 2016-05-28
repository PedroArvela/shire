using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Scripts.AI.Perceptions
{
	public abstract class Perception
	{
		public string Name;
		public GameObject target;
		public string targetTag;
        public SortedDictionary<string, float> attributes;

        protected Perception()
        {

            attributes = new SortedDictionary<string, float>();

        }


    }
}