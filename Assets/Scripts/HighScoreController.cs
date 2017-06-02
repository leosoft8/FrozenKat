using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HighScoreController : MonoBehaviour {

	[SerializeField] private GameObject m_NameSB;
	[SerializeField] private GameObject m_ValueSB;

	private int m_TotalToShow;

	void Awake () {
		m_TotalToShow = m_NameSB.transform.childCount;
	}

	public void ShowHighestScores (List<Tuple> HighScore) {

		Text[] valueStored = m_ValueSB.GetComponentsInChildren <Text> ();
		Text[] nameStored = m_NameSB.GetComponentsInChildren <Text> ();

		HighScore.Sort ();

		for (int i = 0; i < m_TotalToShow && i < HighScore.Count; i++) {
			valueStored [i + 1].text = (HighScore.ElementAt (i).First).ToString();
			nameStored [ i + 1 ].text =  HighScore.ElementAt(i).Second;
		}
	}
}
