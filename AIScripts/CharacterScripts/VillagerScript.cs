using UnityEngine;
using Scripts.AI.Deciders;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using Scripts.Utils;
using System.Collections.Generic;

public class VillagerScript : MonoBehaviour
{
	List<Perception> currentPerceptions;
	List<Collider> triggerList;

	private SphereCollider col;
	private float fov;
	private float hearingRange;

	AIAction currentAction = null;
	Decider decider;

	void Awake ()
	{
		currentPerceptions = new List<Perception> ();
		triggerList = new List<Collider> ();

		decider = this.gameObject.AddComponent<DeciderVillagerReactive> ();

		col = GetComponent<SphereCollider> ();
		fov = GetComponent<CharacterVars> ().FoVAngle;
		hearingRange = GetComponent<CharacterVars> ().HearingRange;
	}

	// Use this for initialization
	void Start ()
	{
		InvokeRepeating ("DecideAction", 2f, 2f);
		InvokeRepeating ("processPerceptions", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentAction != null) {
			currentAction.Execute (this.gameObject);
		}
	}

	void DecideAction ()
	{
		Debug.Log ("Perceptions " + currentPerceptions.Count);
		currentAction = decider.Decide (currentPerceptions);
	}

	void processPerceptions ()
	{
		currentPerceptions.Clear ();

		foreach (Collider other in triggerList) {
			if (other.tag == "Orc" || other.tag == "Villager" || other.tag == "Resource" || other.tag == "Village") {

				if (inSight (other)) {
					currentPerceptions.Add (new CanSee (other.gameObject));
				}

				if (withinHearing (other)) {
					currentPerceptions.Add (new IsNear (other.gameObject));
				}
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (!triggerList.Contains (other)) {
			triggerList.Add (other);
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (triggerList.Contains (other)) {
			triggerList.Remove (other);
		}
	}

	bool inSight (Collider other)
	{
		Vector3 direction = other.transform.position - transform.position;
		float angle = Vector3.Angle (direction, transform.forward);

		if (angle <= fov * 0.5f) {

			RaycastHit hit;

			return Physics.Raycast (transform.position + transform.up, direction.normalized, out hit, col.radius) && hit.collider.gameObject == other.gameObject;
		}

		return false;
	}

	bool withinHearing (Collider other)
	{
		return Vector3.Distance (other.transform.position, transform.position) <= hearingRange;
	}
}
