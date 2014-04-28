using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hero : MonoBehaviour {
	public float collisionForce = 5;
	public float moveForce = 1;
	public float jumpForce = 0.1f;
	public float moveVMax = 1;
	public Transform groundCheck;
	private Animator anim;

	private GameObject gameUI;
	
	void Start () {
		gameUI = GameObject.Find("/GameUI");
		anim = DebugUtil.AssertNotNull(GetComponent<Animator>());
	}

	void FixedUpdate() {
		var movement = Input.GetAxis("Horizontal");
		var force = movement * moveForce;
		anim.SetFloat("Acceleration", force);
		rigidbody2D.AddForce(Vector2.right * force);

		var jump = Input.GetAxis("Vertical");
		var jumpForce = jump * moveForce / 2;
		//anim.SetFloat("Jump", force);
		rigidbody2D.AddForce(Vector2.up * jumpForce);
		rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -moveVMax, moveVMax), Mathf.Clamp(rigidbody2D.velocity.y, -moveVMax * 3, moveVMax * 3));
		// TODO grounded detection; no flying
		// nope. out of time!
		//if (jump > 0) {
			//var cast = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));
			//if (cast.collider) {
		//		rigidbody2D.AddForce(Vector2.up * jumpForce);
            //}
			//else {
			//	Debug.Log ("grounded-check prevents jump");
			//}
        //}
	}

	void OnTouchLava() {
		gameUI.BroadcastMessage("OnHeroDeath");
	}
}
