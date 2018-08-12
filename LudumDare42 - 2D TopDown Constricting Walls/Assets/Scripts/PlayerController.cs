using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float movementX;
    float movementY;
    Vector2 deltaMove;
    int speed = 3;

    DashState dashState = DashState.Ready;
    float dashTimer = 0f;
    float maxDashTimer = 0.1f;
    float cooldownTimer = 0.1f;
    float cooldownTimerCopy;
    int previousSpeed = 0;

    Rigidbody2D rB;

	// Use this for initialization
	void Start () {

        rB = transform.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        switch (dashState)
        {
            case DashState.Ready:
                if (Input.GetButtonDown("Dash"))
                {
                    previousSpeed = speed;
                    speed = 20;
                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime;
                if (dashTimer >= maxDashTimer)
                {
                    dashTimer = maxDashTimer;
                    cooldownTimerCopy = cooldownTimer;
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                speed = previousSpeed;
                cooldownTimer -= Time.deltaTime;
                if (cooldownTimer <= 0)
                {
                    dashTimer = 0;
                    cooldownTimer = cooldownTimerCopy;
                    dashState = DashState.Ready;
                }
                break;
        }

        // TODO: have speed of diagonal movement reduced to the cardinal movement
        deltaMove = new Vector2(movementX * speed , movementY * speed);

	}

    void FixedUpdate()
    {

        rB.MovePosition(rB.position + deltaMove * Time.fixedDeltaTime);

        // Get mouse position from perspective of screen
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // TODO: understand this
        Quaternion rotation = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);

        transform.rotation = rotation;
        // Have rotation only on the z axis
        transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
        rB.angularVelocity = 0;
        

    }

}

enum DashState
{
    Ready,
    Dashing,
    Cooldown
}