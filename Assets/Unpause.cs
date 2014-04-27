using UnityEngine;
using System.Collections;

public class Unpause : MonoBehaviour {
	private GameOverParams gameOverParams;
	private Timer timer;
	private Pause pause;
	private long enemyKillCount = 0;

	void Start () {
		gameOverParams = DebugUtil.AssertNotNull(GetComponentInChildren<GameOverParams>());
		timer = DebugUtil.AssertNotNull(GetComponentInChildren<Timer>());
		// pause starts out inactive!
		pause = transform.parent.GetComponentsInChildren<Pause>(true)[0];
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			pause.gameObject.SetActive(true);
		}
	}

	void OnHeroDeath() {
		GameOver();
	}
	
	void OnTimerExpired() {
		GameOver();
	}
	
	void OnEnemyKilled() {
		enemyKillCount++;
	}
	
	private void GameOver() {
		gameOverParams.elapsedSeconds = timer.elapsedSeconds;
		gameOverParams.enemiesKilled = enemyKillCount;
		gameOverParams.transform.parent = null;
		DontDestroyOnLoad(gameOverParams);
		Application.LoadLevel("GameOver");
	}
}
