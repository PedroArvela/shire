using UnityEngine;
using System.Collections;
using Scripts.Utils;

namespace Scripts.AI.Perceptions
{
	public class CanSee : Perception
	{
		public CanSee (GameObject target) : base()
		{
			Name = "CanSee";
			this.target = target;
			targetTag = target.tag;

            if (targetTag == "Orc" || targetTag == "Villager")
            {
                attributes.Add(Elements.HEALTH, target.GetComponent<CharacterVars>().currentHealth);
                attributes.Add(Elements.RESOURCE, target.GetComponent<CharacterVars>().currentResource);
                attributes.Add(Elements.ENERGY, target.GetComponent<CharacterVars>().currentEnergy);
                attributes.Add(Elements.MAX_RESOURCE, target.GetComponent<CharacterVars>().maxResource);
                attributes.Add(Elements.MAX_HEALTH, target.GetComponent<CharacterVars>().maxHealth); 
            } else if (targetTag == "Resource")
            {
                attributes.Add(Elements.RESOURCE, target.GetComponent<ResourceVars>().currentResource);
                attributes.Add(Elements.MAX_RESOURCE, target.GetComponent<ResourceVars>().maxResource);
            } else if (targetTag == "Village")
            {
                attributes.Add(Elements.RESOURCE, target.GetComponent<VillageVars>().currentResources);
                
            }
        }
	}
}