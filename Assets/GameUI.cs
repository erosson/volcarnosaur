using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour {
	private GameOverParams gameOverParams;
	private Timer timer;

	void Start() {
		gameOverParams = GetComponentInChildren<GameOverParams>();
		DebugUtil.Assert (gameOverParams != null);
		timer = GetComponentInChildren<Timer>();
		DebugUtil.Assert (timer != null);
	}

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
		gameOverParams.elapsedSeconds = timer.elapsedSeconds;
		gameOverParams.transform.parent = null;
		DontDestroyOnLoad(gameOverParams);
		Application.LoadLevel("GameOver");
	}
}
