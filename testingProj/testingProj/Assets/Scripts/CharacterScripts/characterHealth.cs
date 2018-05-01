using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float healthPoints = 100f;
	public cameraController camCon;
	public characterMovement charMove;
	

	// Use this for initialization
	void Start () {
		charMove = GetComponent<characterMovement> ();
		camCon = this.GetComponentInChildren<cameraController>();

		
	}
	
	// Update is called once per frame
	void Update () {

		CheckHealth ();
		
	}

	void CheckHealth() {
		if(healthPoints > 0) {
			healthPoints -= 1f;
			if (healthPoints <= 0) {
				camCon.isDeath = true;
				//charMove.enabled = false;
			}
		}
	}
}
