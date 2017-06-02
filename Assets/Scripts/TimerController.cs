using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerController : MonoBehaviour {

	private static Text m_TimeToShow;
	private static float m_TimeOnGoing;
	private static bool m_StillRunning;

	void Awake() {
		m_TimeToShow = GetComponent<Text> ();
		m_TimeOnGoing = 0f;
		m_StillRunning = true;
	}

	void Start () {
		m_TimeToShow.text = "0\"";
	}

	void FixedUpdate () {
		if (m_StillRunning) {
			m_TimeOnGoing += Time.deltaTime;
			m_TimeToShow.text = (int)m_TimeOnGoing + "\"";
		}
	}

	public static void StopTimer () {
		m_StillRunning = false;
	}

	public static int GetTime () {
		return (int)m_TimeOnGoing;
	}
}
