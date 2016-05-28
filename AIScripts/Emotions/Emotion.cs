using UnityEngine;
using System.Collections;

namespace Scripts.AI.Emotions
{
	public class Emotion
	{
		/**
		 * An emotion has a valence, which can be positive or negative, and an intensity, which says how intense that emotion is.
		 * 
		 * Happiness, for example, would have a positive valence and any intensity.
		 * Sadness would have a negative valence and low intensity.
		 * Anger would have negative valence and high intensity.
		 * 
		 * The valence is measured from -1 to 1, and intensity from -1 to 1.
		 * 
		 * Indiference is (0, 0).
		 * 
		 * The target is the "cause" of the emotion.
		 */

		public float valence;
		public float intensity;

		public GameObject target;
	}
}