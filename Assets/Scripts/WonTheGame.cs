using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WonTheGame : MonoBehaviour {

	[SerializeField] private MovieTexture m_EndMovie;

	void Start () {
		GetComponent<RawImage> ().texture = m_EndMovie as MovieTexture;
		m_EndMovie.loop = true;
		m_EndMovie.Play ();
	}
		
}
