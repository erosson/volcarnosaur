using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public GameObject enemyTemplate;
	public Transform enemyParent;
	public float spawnDelaySeconds = 1;
	private int spawned = 0;

	void Start() {
		StartCoroutine(SpawnForever()) ;
	}

	private IEnumerator SpawnForever() {
		while(true) {
			SpawnOne();
			yield return new WaitForSeconds(spawnDelaySeconds);
		}
	}

	private void SpawnOne() {
		var enemy = Instantiate(enemyTemplate, transform.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = enemyParent;
		spawned++;
		enemy.name = "Enemy" + spawned;
		enemy.SetActive(true);
		// send them flying far to the left or the right
		var direction = (Mathf.Round(Random.Range(0, 2)) * 2 - 1);
		DebugUtil.Assert (direction == 1 || direction == -1);
		var magnitude = Random.Range(1000, 10000);
		enemy.rigidbody2D.AddForce(new Vector2(magnitude * direction, 0));
	}
}
