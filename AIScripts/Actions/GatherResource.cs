﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
	class GatherResourceBare : ActionBareBone
	{
		public GatherResourceBare ()
		{
			Name = AIActions.GatherResources;
			preConditions = new List<string> { Elements.RESOURCE_IN_SIGHT };
			postConditions = new List<string> { Elements.HAS_RESOURCES };
		}
	}

	public class GatherResource : AIAction
	{
		private GoToTarget Goto;

		private float gatherDistance { get; set; }

		public GatherResource (GameObject tar)
		{
			target = tar;
			Name = AIActions.GatherResources;
			if (tar == null) {
				Goto = null;
			} else {
				Goto = new GoToTarget (tar.transform.position);
			}
			gatherDistance = 5.0f;
			preConditions = new List<string> { Elements.RESOURCE_IN_SIGHT };
			postConditions = new List<string> { Elements.HAS_RESOURCES };

		}

		public override void Execute (GameObject go)
		{
			// Can't gather what there no longer is
			if (TargetResVars ().currentResource < 10) {
				return;
			}

			if (Vector3.Distance (go.transform.position, target.transform.position) < gatherDistance) {
				TargetResVars ().currentResource -= 10;
				go.GetComponent<CharacterVars> ().currentResource += 10;
			} else {
				if (Goto == null) {
					Goto = new GoToTarget (target.transform.position);
				}
				Goto.Execute (go);
			}
		}
	}
}