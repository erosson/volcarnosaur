using UnityEngine;
using System.Collections;

// even in unity, F O E
public class Foe : MonoBehaviour {
	private GameObject gameUI;
	void Start () {
		gameUI = GameObject.Find("/GameUI");
	}
	
	void OnTouchLava() {
		Destroy(gameObject);
		gameUI.BroadcastMessage("OnEnemyKilled", this);
    }
}
