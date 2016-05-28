using UnityEngine;
using System.Collections;


namespace Scripts.AI.Intentions
{
    public class KillOrcs : Intention
    {



        public KillOrcs()
        {

            //colocar como atributo orcs que já viu vs orcs que já matou?
            Goal = "OrcIsDead";

        }


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}