using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterControl : MonoBehaviour {

	[SerializeField] private LayerMask m_WhatIsGround;

	private const float k_GroundedRadius = .2f;

	private int m_JumpHigh;
	private float m_MaxSpeed = 10f;
	private float m_JumpForce = 1000f;
	private bool m_FacingRight;
	private bool m_IsGrounded;
	private bool m_isDead;

	private Camera m_Camera;
	private Transform m_GroundCheck;
	private Animator m_Anim;
	private Rigidbody2D m_Character;

	private static int s_RemainingLifes;
	private const int k_InitialLifes = 9;


	private void Awake() {
		m_Camera = GetComponentInChildren <Camera> ();
		m_JumpHigh = 0;
		s_RemainingLifes = k_InitialLifes;
		m_GroundCheck = transform.Find ("GroundCheck");
		m_Anim = GetComponent<Animator> ();
		m_Character = GetComponent<Rigidbody2D> ();
		m_isDead = false;
		m_Anim.SetBool ("IsDead", false);
	}

	void Start() {
		ParallaxBackground.AsigneCamera (m_Camera);
	}

	void FixedUpdate () {

		m_IsGrounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position , k_GroundedRadius, m_WhatIsGround);

		for (int i = 0; i < colliders.Length; i++) {
			
			if (colliders [i].gameObject != gameObject) {
				m_IsGrounded = true;
			} 
		}

		if (!m_IsGrounded) {
			m_JumpHigh++;
		} else {
			ItsGonnaHurt ();
		}

		m_Anim.SetBool("Jump", !m_IsGrounded);
		m_Anim.SetBool ("IsGettingHurt", false);

		float movement = CrossPlatformInputManager.GetAxis("Horizontal");
		bool jump = CrossPlatformInputManager.GetButtonDown ("Jump");
		Move (movement, jump);

	}

	private void ItsGonnaHurt(){
		if(m_JumpHigh > 69) {
			DiscountLife();
		}

		m_JumpHigh = 0;

	}

	void Move(float movement, bool jump){
		if (!m_isDead) {
			m_Character.velocity = new Vector2 (movement * m_MaxSpeed, m_Character.velocity.y);
			m_Anim.SetFloat ("Speed", Mathf.Abs (movement));

			if (movement < 0 && !m_FacingRight) {
			
				Flip ();
			} else if (movement > 0 && m_FacingRight) {

				Flip ();
			}

			if (m_IsGrounded && jump) {
				m_IsGrounded = false;
				m_Anim.SetBool ("Jump", true);
				m_Character.AddForce (new Vector2 (0f, m_JumpForce));
			}
		}
	}


	void Flip (){
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag == "Enemy") {
			DiscountLife ();
		} else if (collision.gameObject.tag == "Collectable") {
			CoinsController.UpdateCoins (collision.name);
		}
	}

	private void DiscountLife(){
		s_RemainingLifes--;

		if (s_RemainingLifes > 0) {
			m_Anim.SetBool ("IsGettingHurt", true);
		} else if(s_RemainingLifes == 0){
			m_Anim.SetBool ("IsDead", true);
			m_isDead = true;
			StartCoroutine (Destroytimer ());
		}

		LifeController.UpdateLifes ();
	}

	IEnumerator Destroytimer (){
		yield return new WaitForSeconds (3);
		GameController.GameOver ();
		Destroy(gameObject) ;
	}
		
}
