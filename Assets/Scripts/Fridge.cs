using UnityEngine;
using System.Collections;

public class Fridge : MonoBehaviour, iCollectable {
	
	[SerializeField] private GameObject m_Explotion;

	void Awake (){
		this.SetTag ();
		this.SetName ();
	}

	public void SetName() { 
		gameObject.name = "Fridge";
	}

	public void SetTag (){
		gameObject.tag = "Collectable";
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.tag == "Player") {
			Instantiate (m_Explotion, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (gameObject);
		}
	}
		
}

