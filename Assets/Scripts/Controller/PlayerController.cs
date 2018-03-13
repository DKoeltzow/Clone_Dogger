using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float MovementSpeed;

    public delegate void OnContactEvent();
    public OnContactEvent OnContact;

    Rigidbody2D rigi;

    private void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        Clamp();
	}

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(x * MovementSpeed, 0);
        rigi.velocity = movement;
        //transform.Translate(movement);
    }

    void Clamp()
    {
       float clampedX=  Mathf.Clamp(transform.position.x, -10f, 10f);
        transform.position = new Vector2(clampedX, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        StartCoroutine(Example());
        Time.timeScale = 0;
    }

    IEnumerator Example()
    {
        yield return new WaitForSecondsRealtime(5);
        if (OnContact != null)
        {
            OnContact();
        }
    }
}
