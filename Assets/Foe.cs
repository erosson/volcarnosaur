using UnityEngine;
using System.Collections;

// even in unity, F O E
public class Foe : MonoBehaviour {
	public float moveForce = 2;
	public float moveVMax = 2;
	private GameObject gameUI;
	private int walking = 0;

	void Start () {
		gameUI = GameObject.Find("/GameUI");
		StartCoroutine (AI());
	}
	
	void OnTouchLava() {
		Destroy(gameObject);
		gameUI.BroadcastMessage("OnEnemyKilled", this);
    }

	private IEnumerator AI() {
		yield return new WaitForSeconds(Random.Range(0f, 5f));
		while (true) {
			walking = Random.Range(0, 3) - 1;
			yield return new WaitForSeconds(Random.Range(0f, 1f));
			walking = 0;
			yield return new WaitForSeconds(Random.Range(0f, 5f));
		}
	}

	void FixedUpdate() {
		var force = walking * moveForce;
		rigidbody2D.AddForce(Vector2.right * force);
		//rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -moveVMax, moveVMax), rigidbody2D.velocity.y);
	}
}
