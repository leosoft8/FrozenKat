using UnityEngine;
using System.Collections;

public class ExplotionController : MonoBehaviour {


	void Awake () {
		StartCoroutine (WaitToDestroy ());
	
	}

	IEnumerator WaitToDestroy () {
		yield return new WaitForSecondsRealtime (2);
		Destroy (gameObject);
	}

}
