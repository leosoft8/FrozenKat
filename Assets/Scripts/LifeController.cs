using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeController : MonoBehaviour {

	private static int s_LifesRemaining;
	private static Text s_LifesRemainingText;

	void Awake () {
		s_LifesRemainingText = GetComponentInChildren<Text> ();
		s_LifesRemaining = 9;
	}

	void Start () {
		s_LifesRemainingText.text = "X " + s_LifesRemaining;
	}
	
	public static void UpdateLifes () {
		s_LifesRemaining--;
		s_LifesRemainingText.text = "X " + s_LifesRemaining;
	}
}
