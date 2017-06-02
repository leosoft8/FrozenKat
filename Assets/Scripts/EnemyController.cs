using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	[SerializeField] private GameObject m_Explotion;
	private Rigidbody2D m_Enemy;
	private float m_Velocity;
	private int HowMuchWalk;
	private bool m_HaveToFlip;

	void Awake(){
		m_Velocity = -10f;
		m_Enemy = GetComponent<Rigidbody2D> ();
		m_Enemy.velocity = new Vector2 (m_Velocity, 0f);
		HowMuchWalk = 0;
	}

	void FixedUpdate(){
		HowMuchWalk++;
		if (HowMuchWalk >= 70) {
			m_Velocity *= -1;
			m_Enemy.velocity = new Vector2 (m_Velocity, 0f);
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			HowMuchWalk = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			Instantiate (m_Explotion, gameObject.transform.position, gameObject.transform.rotation);
			Destroy (gameObject);
		}
	}
}
