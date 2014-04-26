using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	public float collisionForce = 5;
	public float moveForce = 1;
	public float jumpForce = 0.1f;
	public float moveVMax = 1;
	public Transform groundCheck;

	void Update () {
		var movement = Input.GetAxis("Horizontal");
		rigidbody2D.AddForce(Vector2.right * movement * moveForce);
		rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -moveVMax, moveVMax), rigidbody2D.velocity.y);

		var jump = Input.GetAxis("Vertical");
		if (rigidbody2D.velocity.y == 0 && jump > 0) {
			var cast = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));
			if (cast.collider) {
				rigidbody2D.AddForce(Vector2.up * jumpForce);
            }
			else {
				Debug.Log ("grounded-check prevents jump");
			}
        }
	}
}
