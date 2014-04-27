using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public Texture2D logo;
	private GameOverParams args;

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
	}

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		GUI.backgroundColor = Color.clear;
		GUILayout.Box(logo);
		GUI.backgroundColor = Color.white;
		GUILayout.Box(string.Format ("Survived {0} seconds\nKilled {1} enemies", args.elapsedSeconds, args.enemiesKilled));
		if (GUILayout.Button ("Return to Main Menu")) {
			Application.LoadLevel("MainMenu");
		}
		GUILayout.EndArea();
	}
}
