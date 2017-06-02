using UnityEngine;
using System.Collections;

public class ButcherController : MonoBehaviour {

	[SerializeField] private CoinsController m_CoinsController;

	void OnTriggerEnter2D ( Collider2D other ){
		if (other.gameObject.tag == "Player") {
			TimerController.StopTimer ();
			int TotalCoins = m_CoinsController.GetTotalCoins ();
			int TotalTime = TimerController.GetTime ();
			GameController.WonTheGame ( TotalCoins, TotalTime );
		}
	}
}