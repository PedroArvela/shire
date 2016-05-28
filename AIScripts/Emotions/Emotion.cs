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
		 * The valence is measured from -1 to 1, and intensity from 0 to 1.
		 * 
		 * The target is the "cause" of the emotion.
		 */

		float valence;
		float intensity;

		GameObject target;
	}
}