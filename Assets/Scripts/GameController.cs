using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	[SerializeField] private GameObject m_MainPlayPanel;
	[SerializeField] private GameObject m_SelectCharacterPanel;
	[SerializeField] private Transform m_Character1;
	[SerializeField] private Transform m_Character2;

	private static int m_TotalPointsWG = 0;
	private static int m_TotalTimeWG = 0;

	private readonly Vector2 ro_InitialCharacterPosition = new Vector2 ( 0f, 0f );
	private readonly Quaternion ro_InitialCharacterRotation = new Quaternion (0f, 0f, 0f, 0f);

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}

	public void Character1Selected () {
		Instantiate (m_Character1, ro_InitialCharacterPosition, ro_InitialCharacterRotation);
		HideSelectPanel ();
	}

	public void Character2Selected() {
		Instantiate (m_Character2, ro_InitialCharacterPosition, ro_InitialCharacterRotation);
		HideSelectPanel ();
	}

	void HideSelectPanel () {
		m_SelectCharacterPanel.SetActive (false);
		m_MainPlayPanel.SetActive (true);
	}
		
	public static void GameOver() {
		SceneManager.LoadScene ("MainMenu");
	}

	public static void WonTheGame (int TotalPoints, int TotalTime ) {
		m_TotalPointsWG = TotalPoints;
		m_TotalTimeWG = TotalTime;
		SceneManager.LoadScene ("WonTheGame");
		return;
	}

	public static int GetTotalPointsWP (){
		return m_TotalPointsWG;
	}

	public static int GetTotalTimeWP () {
		return m_TotalTimeWG;
	}
}
