using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameOver : MonoBehaviour {
	private static readonly Dictionary<GameOverParams.Cause, string> causeTexts = new Dictionary<GameOverParams.Cause, string> {
		{GameOverParams.Cause.FellInLava, "You fell into the volcano."},
		{GameOverParams.Cause.TimeOver, "You ran out of time and the volcano erupted."},
	};

	public Texture2D logo;
	public AudioClip selectSfx;
	public AudioClip playerDies;
	private GameOverParams args;
	private string causeText;

	// Use this for initialization
	void Start () {
		var obj = GameObject.Find("/GameOverParams");
		if (obj == null) {
			obj = GameObject.Find("/DefaultGameOverParams");
		}
		DebugUtil.Assert(obj != null);
		args = obj.GetComponent<GameOverParams>();
		DebugUtil.Assert(args != null);
		Destroy(obj);
		causeText = causeTexts[args.cause];
		AudioSource.PlayClipAtPoint(playerDies, transform.position);
	}

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		GUI.backgroundColor = Color.clear;
		GUILayout.Box(logo);
		GUI.backgroundColor = Color.white;
		GUILayout.Box(string.Format ("{0}\nSurvived {1} seconds\nKilled {2} enemies", causeText, args.elapsedSeconds, args.enemiesKilled));
		if (GUILayout.Button ("Return to Main Menu")) {
			//AudioSource.PlayClipAtPoint(selectSfx, transform.position);
			Application.LoadLevel("MainMenu");
		}
		GUILayout.EndArea();
	}
}
