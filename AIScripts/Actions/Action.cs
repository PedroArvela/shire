﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
	public abstract class AIAction
	{
		public string Name;
		public GameObject target;
        

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
}