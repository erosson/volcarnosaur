using UnityEngine;
using System.Collections;

// even in unity, F O E
public class Foe : MonoBehaviour {
	public float moveForce = 2;
	public float moveVMax = 2;
	private GameObject gameUI;
	private int walking = 0;
	private Animator anim;
	public AudioClip[] deaths;

	void Start () {
		gameUI = GameObject.Find("/GameUI");
		anim = DebugUtil.AssertNotNull(GetComponent<Animator>());
		StartCoroutine (AI());
	}
	
	void OnTouchLava() {
		AudioSource.PlayClipAtPoint(deaths[Random.Range (0, deaths.Length)], transform.position);
		Destroy(gameObject);
		gameUI.BroadcastMessage("OnEnemyKilled", this);
    }

	private IEnumerator AI() {
		// faces left or right randomly
		anim.SetFloat("Acceleration", Random.Range (-1f, 1f));
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
		anim.SetFloat("Acceleration", force);
		rigidbody2D.AddForce(Vector2.right * force);
		//rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -moveVMax, moveVMax), rigidbody2D.velocity.y);
	}
}
