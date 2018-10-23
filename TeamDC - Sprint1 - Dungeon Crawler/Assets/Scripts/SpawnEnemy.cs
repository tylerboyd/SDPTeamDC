using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject EnemyPrefab;
    public Vector2 center;
    public Vector2 size;
    private float spawnTimeCounter;
    public float spawnTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnTimeCounter > 0)
            spawnTimeCounter -= Time.deltaTime;
        else if (spawnTimeCounter <= 0)
        {
            spawnTimeCounter = spawnTime;
            SpawnEnemies();
        }
    }

    public void SpawnEnemies()
    {
        Vector2 pos = center + new Vector2(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));
        Instantiate(EnemyPrefab, pos, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireCube(center, size);
    }
}
