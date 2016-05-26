using UnityEngine;
using Scripts.AI.Deciders;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using Scripts.Utils;
using System.Collections.Generic;


public class VillagerScript : MonoBehaviour {


    List<Perception> currentPerceptions;
    AIAction currentAction = null;
    Decider decider;
    CharacterVars charVars = null;




	// Use this for initialization
	void Start () {

        currentPerceptions = new List<Perception>();
        decider = this.gameObject.AddComponent<DeciderVillagerReactive>();
        charVars = this.gameObject.GetComponent<CharacterVars>();



    }
	
	// Update is called once per frame
	void Update () {

        if(currentAction != null)
        {
            currentAction.Execute(this.gameObject);

        }
	
	}


    void FixedUpdate()
    {

        currentAction = decider.Decide(currentPerceptions);


    }




    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Orc")
        {
            currentPerceptions.Add(new SeeOrc(other.gameObject));
        }

        if(other.tag == "Villager")
        {
            currentPerceptions.Add(new SeeVillager(other.gameObject));

        }

        if(other.tag == "Resource")
        {
            currentPerceptions.Add(new SeeResource(other.gameObject));

        }



    }


    void OnTriggerExit(Collider other)
    {

        Perception per = currentPerceptions.Find(p => p.perceptionTarget.Equals(other.gameObject));
        currentPerceptions.Remove(per);

    }


}
