using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WonTheGameController : MonoBehaviour {

	[SerializeField] private Text m_Score;
	[SerializeField] private Text m_Time;
	[SerializeField] private Text m_Total;
	[SerializeField] private HighScoreManager m_HighScoreDB;
	[SerializeField] private InputField m_TextBox;
	[SerializeField] private Text m_TextBoxText;
	[SerializeField] private Button m_SendScore;
	[SerializeField] private Button m_BackToMainMenu;

	private int m_TotalPoints;

	private const int t_TotalToStore = 5;

	void Awake(){
		m_TextBox.interactable = false;
		m_SendScore.interactable = false;
		m_BackToMainMenu.interactable = true;
	}

	void Start () {
		m_Score.text = (GameController.GetTotalPointsWP ()).ToString();
		m_Time.text = (GameController.GetTotalTimeWP ()).ToString ();
		m_TotalPoints = CalculateTotalPoints (GameController.GetTotalPointsWP (), GameController.GetTotalTimeWP ());
		m_Total.text = (m_TotalPoints).ToString();
		List<Tuple> HighestScores = m_HighScoreDB.GetHighestScores ();
		CheckForNewHS (HighestScores);
	}

	private int CalculateTotalPoints ( int points, int time ){
		float multiplier = 1f;

		int range = 20;
		int newNumber = time / range;

		switch (newNumber)
		{
		//0 a 20
		case (0): 
			multiplier = 4f;
			break;
		//20 a 40
		case (1): 
			multiplier = 3f;
			break;
		//40 a 60
		case (2): 
			multiplier = 2f;
			break;
		//60 a 80
		case (3):
			multiplier = 1.7f;
			break;
		case (4):
			multiplier = 1.5f;
			break;
		case (5):
			multiplier = 1.3f;
			break;
		case (6):
			multiplier = 1.1f;
			break;
		default:  break;
		}

		return (int) (points * multiplier);
	}

	private void CheckForNewHS (List<Tuple> highestScores) {


		highestScores.Sort ();


		if (highestScores.Count < t_TotalToStore) {
			m_TextBox.interactable = true;
			m_SendScore.interactable = true;
			m_BackToMainMenu.interactable = false;
		} else if (m_TotalPoints > highestScores.ElementAt (4).First) {
			m_TextBox.interactable = true;
			m_SendScore.interactable = true;
			m_BackToMainMenu.interactable = false;
			m_HighScoreDB.DeleteScore (highestScores.ElementAt (4).First, highestScores.ElementAt (4).Second);
		}
	}

	public void SendScore () {
		string nameToStore = m_TextBoxText.text;

		if (nameToStore != "") {
			m_TextBox.interactable = false;
			m_SendScore.interactable = false;
			m_BackToMainMenu.interactable = true;
			m_HighScoreDB.InsertScore (nameToStore, m_TotalPoints);
		}
	}

	public void BackToMenu () {
		SceneManager.LoadScene ("MainMenu");
	}
}
