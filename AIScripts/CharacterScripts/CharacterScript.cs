using UnityEngine;
using UnityEngine.UI;
using Scripts.AI.Deciders;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using Scripts.Utils;
using System.Collections.Generic;


namespace Scripts.AI.Characters
{
	public class CharacterScript : MonoBehaviour
	{
		public List<Perception> nextPerceptions;

		protected List<Perception> currentPerceptions;
		protected List<Collider> triggerList;
		public GameObject BarBrefab;
		protected SphereCollider col;
		protected float fov;
		protected GameObject bar;
		protected float hearingRange;
		protected CharacterVars charVars;

		protected AIAction currentAction = null;
		protected Decider decider;

		void Awake ()
		{
			charVars = GetComponent<CharacterVars> ();
			nextPerceptions = new List<Perception> ();
			currentPerceptions = new List<Perception> ();
			triggerList = new List<Collider> ();

			bar = Instantiate (BarBrefab);
			bar.transform.SetParent (GameObject.FindWithTag ("Canvas").transform);
			bar.GetComponent<EnemyHealth> ().target = this.gameObject;
			bar.GetComponent<Slider> ().maxValue = charVars.maxHealth;
            
			col = GetComponent<SphereCollider> ();
			fov = charVars.FoVAngle;
			hearingRange = charVars.HearingRange;

			InvokeRepeating ("DecideAction", 2f, 2f);
		}

		// Update is called once per frame
		public void Update ()
		{
			if (currentAction != null) {
				currentAction.Execute (this.gameObject);
			}

			if (gameObject.tag == "Dead") {
				gameObject.GetComponent<NavMeshAgent> ().Stop ();
				this.enabled = false;
			}
		}

		void DecideAction ()
		{
			processPerceptions ();
			currentAction = decider.Decide (currentPerceptions);
		}

		virtual public void processPerceptions ()
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
		}

		void OnTriggerStay (Collider other)
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

		public bool inSight (Collider other)
		{
			if (Vector3.Distance (other.transform.position, transform.position) <= hearingRange) {
				return true;
			}

			Vector3 direction = other.transform.position - (transform.position + transform.up);
			float angle = Vector3.Angle (direction.normalized, transform.forward.normalized);

			if (angle <= fov * 0.5f) {
				RaycastHit hit;
				if (Physics.Raycast (transform.position + transform.up, direction.normalized, out hit, col.radius)) {
					return hit.collider.gameObject.Equals (other.gameObject);
				}
				return false;
			}

			return false;
		}

		bool withinHearing (Collider other)
		{
			return Vector3.Distance (other.transform.position, transform.position) <= hearingRange;
		}
	}
}