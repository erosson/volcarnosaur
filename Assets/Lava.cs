using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D coll) {
		coll.gameObject.SendMessage("OnTouchLava", SendMessageOptions.DontRequireReceiver);
	}
}
