using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeController : MonoBehaviour {

    CircleCollider2D startMarker;
    bool cullStart;
    float holeScale;
    public float currentScale;
    public float maxScale;
    public float scaleRate;

    public GameObject floorHole;

	// Use this for initialization
	void Start ()
    {

        startMarker = transform.GetComponent<CircleCollider2D>();
        currentScale = transform.localScale.x;
        maxScale = 1000f;
        scaleRate = 0.1f;

	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!cullStart)
        {
            Debug.Log("Start!");
            Destroy(startMarker);
            Destroy(floorHole);
            cullStart = true;
        }

    }

    // Update is called once per frame
    void FixedUpdate () {

        if (cullStart)
        {
            holeScale = Mathf.MoveTowards(currentScale, maxScale, scaleRate * Time.deltaTime);
            currentScale = holeScale;
            transform.localScale = new Vector3(holeScale, holeScale, 1);

        }

	}
}
