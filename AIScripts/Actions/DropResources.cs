using UnityEngine;
using System.Collections;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
	public class DropResources : AIAction
	{
		public DropResources ()
		{
			target = GameObject.FindGameObjectWithTag ("Village");
		}

		public override void Execute (GameObject go)
		{
			target.GetComponent<VillageVars> ().currentResources += go.GetComponent<CharacterVars> ().currentResource;
			go.GetComponent<CharacterVars> ().currentResource = 0;
		}
	}
}