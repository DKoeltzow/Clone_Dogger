using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public GameObject Enemy;

    private float SpawnDelay;

    private float timer;

    private int nbr;

	// Use this for initialization
	void Start () {
        nbr = 0;
        SpawnDelay = 1f;	
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if(timer >SpawnDelay)
        {
            Spawnenemy();
            timer = 0;
        }
    }

    private void Spawnenemy()
    {
        float xPos = UnityEngine.Random.Range(-10f, 10f);
        float size = UnityEngine.Random.Range(2f, 8f);
        float fallSpeed = UnityEngine.Random.Range(2f, 10f);
        Vector2 enemyPos = new Vector2(xPos, 25);
        Vector3 enemySize = new Vector3(size, size, 0);
        GameObject enemy = Instantiate(Enemy, enemyPos, Quaternion.identity);
        enemy.transform.localScale = enemySize;
        enemy.GetComponent<EnemyController>().Speed = fallSpeed;
        enemy.transform.name = "Enemy_" + nbr;
        nbr += 1;
    }
}
