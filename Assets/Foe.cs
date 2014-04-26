using UnityEngine;
using System.Collections;

public class Foe : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.tag == "lava") {
			Destroy(gameObject);
			Debug.Log("eeeeeek");
		}
	}
}
