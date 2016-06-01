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
				if ((other.tag == "Orc" || other.tag == "Villager" || other.tag == "Resource" || other.tag == "Village")) {


					if (inSight (other)) {
						currentPerceptions.Add (new CanSee (other.gameObject));
						//Debug.Log("Adding");
					}



				}
			}

			((DeciderVillagerBDI)decider).reviseBeliefs (currentPerceptions);
		}




	}
}
