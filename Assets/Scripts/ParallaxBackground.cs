using UnityEngine;
using System.Collections;

public class ParallaxBackground : MonoBehaviour {
	[SerializeField] private float m_BackgroundSize;
	[SerializeField] private float m_ParalaxSpeed;

	private static Transform m_CameraTransform;
	private Transform[] m_Layers;
	private float m_ViewZone = 10;
	private int m_LeftIndex;
	private int m_RightIndex;
	private float m_lastCamaraX;
	private static bool m_IsCameraAsigned;



	public static void AsigneCamera ( Camera CameraTransform ) {
		m_CameraTransform = CameraTransform.transform;
		m_IsCameraAsigned = true;
	}

	void Awake () {
		m_IsCameraAsigned = false;
		m_ParalaxSpeed *= -1;
		m_Layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			m_Layers [i] = transform.GetChild (i);
		}
		m_LeftIndex = 0;
		m_RightIndex = m_Layers.Length - 1;
	}

	void FixedUpdate (){
		
		if (m_CameraTransform == null) {
			m_IsCameraAsigned = false;
		}

		if (m_IsCameraAsigned) {
			float deltaX = m_CameraTransform.position.x - m_lastCamaraX;
			transform.position += new Vector3 (deltaX * m_ParalaxSpeed, 0f, 0f);
			m_lastCamaraX = m_CameraTransform.position.x;

			if (m_CameraTransform.position.x < (m_Layers [m_LeftIndex].transform.position.x + m_ViewZone)) {
				ScrollLeft ();
			}

			if (m_CameraTransform.position.x > (m_Layers [m_RightIndex].transform.position.x - m_ViewZone)) {
				ScrollRight ();
			}
		}
	}

	private void ScrollLeft () {
		m_Layers [m_RightIndex].position = new Vector3 (m_Layers [m_LeftIndex].position.x - m_BackgroundSize, 0f, 0f);
		m_LeftIndex = m_RightIndex;
		m_RightIndex--;
		if (m_RightIndex < 0) {
			m_RightIndex = m_Layers.Length - 1;
		}
	}

	private void ScrollRight () {
		m_Layers [m_LeftIndex].position = new Vector3 (m_Layers [m_RightIndex].position.x + m_BackgroundSize, 0f, 0f);
		m_RightIndex = m_LeftIndex;
		m_LeftIndex++;
		if (m_LeftIndex == m_Layers.Length) {
			m_LeftIndex = 0;
		}
	}

}
