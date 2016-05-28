using UnityEngine;
using System.Collections;

namespace Scripts.Utils
{

    public class ResourceVars : MonoBehaviour
    {

        public int currentResource;
        public int maxResource;


        private float lastUpdate;
        ResourceVars manager;
        ParticleSystem particles;
        Color pcolor;
        // Use this for initialization
        void Start()
        {

            lastUpdate = Time.realtimeSinceStartup;
            particles = gameObject.GetComponentInChildren<ParticleSystem>();
            manager = gameObject.GetComponent<ResourceVars>();
            pcolor = particles.startColor;
        }

        // Update is called once per frame
        void Update()
        {

            if ((Time.realtimeSinceStartup - lastUpdate) > 60 && currentResource < maxResource)
            {
                lastUpdate = Time.realtimeSinceStartup;
                manager.currentResource += 10;
    
            }


            if(currentResource == 0)
            {
                pcolor.a = 0;
                particles.startColor = pcolor;
                gameObject.tag = "Untagged";

            }

            if (currentResource > 0)
            {
                pcolor.a = 100;
                particles.startColor = pcolor;
                gameObject.tag = "Resource";

            }

        }

    }
}