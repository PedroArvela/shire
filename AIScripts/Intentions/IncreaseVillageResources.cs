using UnityEngine;
using System.Collections;


namespace Scripts.AI.Intentions
{
	public class IncreaseVillageResources : Intention
	{
		public IncreaseVillageResources ()
		{
			Goal = Elements.VILLAGE_INCREASED_RESOURCES;
		}
	}
}