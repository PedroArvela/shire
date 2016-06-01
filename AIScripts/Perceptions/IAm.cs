using UnityEngine;
using System.Collections;
using Scripts.Utils;

namespace Scripts.AI.Perceptions
{
    public class IAm : Perception
    {


        public IAm(GameObject target) : base()
        {
            Name = "IAm";
			this.target = target;
			targetTag = target.tag;

            attributes.Add(Elements.HEALTH, target.GetComponent<CharacterVars>().currentHealth);
            attributes.Add(Elements.RESOURCE, target.GetComponent<CharacterVars>().currentResource);
            attributes.Add(Elements.ENERGY, target.GetComponent<CharacterVars>().currentEnergy);
            attributes.Add(Elements.MAX_RESOURCE, target.GetComponent<CharacterVars>().maxResource);
            attributes.Add(Elements.MAX_HEALTH, target.GetComponent<CharacterVars>().maxHealth);
        }
    }
}
