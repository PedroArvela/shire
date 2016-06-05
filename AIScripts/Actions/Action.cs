using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
	public enum AIActions {
		Attack,
		GoToTarget,
		RunToTarget,
		GatherResources,
		DropResources,
		FleeToVillage,
		HealAtVillage,
		Wander
	}

	public abstract class AIAction
	{
		public AIActions Name;
		public GameObject target;
		public List<string> preConditions;
		public List<string> postConditions;

		abstract public void Execute (GameObject go);

		protected CharacterVars TargetCharVars ()
		{
			return target.gameObject.GetComponent<CharacterVars> ();
		}

		protected ResourceVars TargetResVars ()
		{
			return target.gameObject.GetComponent<ResourceVars> ();
		}
	}

	abstract class ActionBareBone
	{
		public AIActions Name;
		public List<string> preConditions;
		public List<string> postConditions;
	}
}