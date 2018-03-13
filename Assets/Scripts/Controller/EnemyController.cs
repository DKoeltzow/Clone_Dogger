using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float Speed;    
	
	// Update is called once per frame
	void Update () {
        Move();		
	}

    void Move()
    {
        Vector2 fallSpeed = new Vector2(0, -Speed * Time.deltaTime);
        transform.Translate(fallSpeed);
    }

}
