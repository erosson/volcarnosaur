using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour {
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// TODO confirm quit; pause
			Application.LoadLevel("MainMenu");
		}
	}

	void OnHeroDeath() {
		GameOver();
	}
	
	void OnTimerExpired() {
		GameOver();
	}
	
	private void GameOver() {
		// TODO game over screen
		Application.LoadLevel("MainMenu");
	}
}
