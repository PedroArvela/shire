using UnityEngine;
using System.Collections;

namespace Scripts.Utils
{

	public class CharacterVars : MonoBehaviour
	{
		public float FoVAngle = 110f;
		public float HearingRange = 5f;

		public float currentHealth;
		public float currentEnergy;
		public float currentResource;

		public int maxHealth;
		public int maxEnergy;
		public int maxResource;


        void Update()
        {

            if(currentHealth <= 0 && gameObject.tag != "Dead")
            {
                gameObject.GetComponent<Animator>().SetTrigger("Dieded");
                this.gameObject.tag = "Dead";
                

            }


        }


    }

    
}