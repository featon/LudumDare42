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

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);

        transform.rotation = rotation;
        transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
        rB.angularVelocity = 0;

    }

}
