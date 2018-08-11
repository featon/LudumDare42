using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour {


	// Use this for initialization
	void Awake () {

        Cursor.lockState = CursorLockMode.Confined;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}
}
