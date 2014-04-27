using UnityEngine;
using System.Collections;

public class GameOverParams : MonoBehaviour {
	public enum Cause {TimeOver, FellInLava};
	public Cause cause;
	public long elapsedSeconds;
	public long enemiesKilled;
}
