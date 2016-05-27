using UnityEngine;
using System.Collections;

namespace Scripts.Utils
{

	public class CharacterVars : MonoBehaviour
	{
		public float FoVAngle = 110f;
		public float HearingRange = 5f;

		public int currentHealth;
		public int currentEnergy;
		public int currentResource;

		public int maxHealth;
		public int maxEnergy;
		public int maxResource;
	}
}