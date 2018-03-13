using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public GameObject Enemy;

    public GameObject Player;

    private float SpawnDelay;

    private float delay;

    private float timer;

    private int nbr;

    private float difficulty;

    private bool cheatMode;

	// Use this for initialization
	void Start () {
        nbr = 0;
        delay = 1f;
        SpawnDelay = 1f;
        difficulty = 0;
        cheatMode = false;
    }
	
	// Update is called once per frame
	void Update () {

        SpawnDelay = delay - setDifficulty();

        timer += Time.deltaTime;
        if(timer > SpawnDelay)
        {
            Spawnenemy();
            timer = 0;
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            cheatMode = true;
        }
    }

    private void Spawnenemy()
    {
        float xPos = UnityEngine.Random.Range(-10f, 10f);
        float size = UnityEngine.Random.Range(3f, 10f);
        float fallSpeed = UnityEngine.Random.Range(5f+difficulty, 20f+difficulty);
        Vector2 enemyPos = new Vector2(xPos, 25);
        Vector3 enemySize = new Vector3(size, size, 0);

        //Spawn at player pos
        if(nbr % 4 == 0)
        {
            enemyPos = new Vector2(Player.transform.position.x, 25);
            Debug.Log("Spawning on Head");
        }
        GameObject enemy = Instantiate(Enemy, enemyPos, Quaternion.identity);
        enemy.transform.localScale = enemySize;
        enemy.GetComponent<EnemyController>().Speed = fallSpeed;
        enemy.transform.name = "Enemy_" + nbr;
        nbr += 1;
    }

    private float setDifficulty()
    {
        if(cheatMode)
        {
            nbr = nbr+100;
        }
        difficulty = Mathf.Clamp(Mathf.RoundToInt( nbr / 10f),0,8);
        float reduction =  Mathf.Clamp((nbr / 100f),0f,0.75f);
        Debug.Log("Diff : " + difficulty + "reduction :" + reduction);
        return reduction;
    }
}
