﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scripts.Utils;

namespace Scripts.AI.Actions
{
	public class DropResources : AIAction
	{

        private float distanceToDrop;
        GoToTarget Goto;

		public DropResources ()
		{
            Name = "DropResources";
			target = GameObject.FindGameObjectWithTag ("Village");
            Goto = new GoToTarget(target.transform.position);
            distanceToDrop = 5.0f;
            preConditions = new List<string> { "HasResources" };
            postConditions = new List<string> { "VillageIncreasedResources", "IsInVillage" };
        }

		public override void Execute (GameObject go)
		{

            if (go.GetComponent<CharacterVars>().currentResource > 0)
            {
                if (Vector3.Distance(go.transform.position, target.transform.position) < distanceToDrop)
                {
                    target.GetComponent<VillageVars>().currentResources += go.GetComponent<CharacterVars>().currentResource;
                    go.GetComponent<CharacterVars>().currentResource = 0;
                    go.GetComponent<NavMeshAgent>().Stop();
                    go.transform.rotation = Quaternion.AngleAxis(180, Vector3.up) * go.transform.rotation;
                    finished = true;
                    
                }
                else
                {

                    Goto.Execute(go);

                } 
            }


		}
	}
}