using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float movementX;
    float movementY;
    Vector2 deltaMove;
    public int speed = 10;

    Rigidbody2D rB;

	// Use this for initialization
	void Start () {

        rB = transform.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");

        deltaMove = new Vector2(movementX *speed , movementY * speed);

	}

    void FixedUpdate()
    {

        rB.MovePosition(rB.position + deltaMove *Time.fixedDeltaTime);

    }

}
