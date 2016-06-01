using UnityEngine;
using Scripts.AI.Deciders;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using Scripts.Utils;
using System.Collections.Generic;

namespace Scripts.AI.Characters
{
	public class VillagerScriptBDI : CharacterScript
	{


		// Use this for initialization
		void Start ()
		{
			decider = this.gameObject.AddComponent<DeciderVillagerBDI> ();
            
		}


		override public void processPerceptions ()
		{
			currentPerceptions.Clear ();
			currentPerceptions.AddRange (nextPerceptions);
			nextPerceptions.Clear ();

			currentPerceptions.Add (new IAm (gameObject));

			foreach (Collider other in triggerList) {
				switch (other.tag) {
				case "Orc":
				case "Villager":
				case "Resource":
				case "Village":
					if (inSight (other)) {
						currentPerceptions.Add (new CanSee (other.gameObject));
					}
					break;
				}
			}

			((DeciderVillagerBDI)decider).reviseBeliefs (currentPerceptions);
		}
	}
}
