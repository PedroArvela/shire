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

			attributes.Add(Elements.HEALTH, target.GetComponent<CharacterVars>().currentHealth);
			attributes.Add(Elements.RESOURCE, target.GetComponent<CharacterVars>().currentResource);
			attributes.Add(Elements.ENERGY, target.GetComponent<CharacterVars>().currentEnergy);
			attributes.Add(Elements.MAXRESOURCE, target.GetComponent<CharacterVars>().maxResource);
			attributes.Add(Elements.MAXHEALTH, target.GetComponent<CharacterVars>().maxHealth);
		}
	}
}