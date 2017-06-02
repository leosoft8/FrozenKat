using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MainMenuController : MonoBehaviour {

	[SerializeField] private HighScoreManager m_HighScoreDB;
	[SerializeField] private HighScoreController m_HighScoreCn;

	void Awake () {
		GameObject PreviusScene = GameObject.Find("GameController");
		Destroy (PreviusScene);
	}

	public void StartPlay () {
		SceneManager.LoadScene ("FrozenKat");
	}

	public void ShowHighScore() {
		List<Tuple> HighestScores = m_HighScoreDB.GetHighestScores ();
		m_HighScoreCn.ShowHighestScores (HighestScores);
	}


	public void Exit () {
		Application.Quit ();
	}

}
