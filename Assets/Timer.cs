using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public int timerSeconds = 60;
	public long elapsedSeconds = 0;

	private GameObject gameUI;

	void Start () {
		gameUI = GameObject.Find("/GameUI");
		StartCoroutine(Countdown());
	}

	private IEnumerator Countdown() {
		while (timerSeconds > 0) {
			yield return new WaitForSeconds(1);
			timerSeconds -= 1;
			elapsedSeconds += 1;
		}
		gameUI.BroadcastMessage("OnTimerExpired");
	}

	private void OnGUI() {
		GUI.Label (new Rect(0, 0, Screen.width, 100), string.Format("{0} seconds left", timerSeconds));
	}

	public void OnEnemyKilled() {
		timerSeconds += 10;
	}
}
