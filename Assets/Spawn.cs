using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	private GameObject enemyTemplate;
	private Transform enemyParent;
	public float spawnDelaySeconds = 1;
	public float spawnDelayVariance = 0.1f;
	public float maxEnemies = 10;
	private int spawned = 0;
	private bool heroTooClose = false;

	public int numEnemies {
		get {
			return enemyParent.childCount;
		}
	}

	void Start() {
		// all this parenting is kind of hacky, but I'm experientming with Find instead of direct references...
		enemyParent = transform.parent.parent.Find("Enemies").transform;
		enemyTemplate = transform.parent.parent.Find("EnemyTemplate").gameObject;
		StartCoroutine(SpawnForever()) ;
	}

	private IEnumerator SpawnForever() {
		yield return new WaitForSeconds(Random.Range (0, spawnDelaySeconds));
		while(true) {
			if (numEnemies < maxEnemies && !heroTooClose) {
				SpawnOne();
			}
			yield return new WaitForSeconds(spawnDelaySeconds + Random.Range (-spawnDelayVariance, spawnDelayVariance));
		}
	}

	private void SpawnOne() {
		var enemy = Instantiate(enemyTemplate, transform.position, transform.rotation) as GameObject;
		enemy.transform.parent = enemyParent;
		spawned++;
		enemy.name = string.Format("Enemy{0}{1}", name, spawned);
		enemy.SetActive(true);
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.name == "Hero") {
			heroTooClose = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) {
		if (coll.name == "Hero") {
			heroTooClose = false;
		}
	}
}
