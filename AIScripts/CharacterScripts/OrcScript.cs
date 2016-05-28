using UnityEngine;
using Scripts.AI.Deciders;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using Scripts.Utils;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Scripts.AI.Characters
{
    public class OrcScript : CharacterScript
    {

        void Start()
        {
            decider = this.gameObject.AddComponent<DeciderOrcReactive>();

            bar.GetComponent<Slider>().fillRect.GetComponent<Image>().color = Color.red;

        }
    }
}