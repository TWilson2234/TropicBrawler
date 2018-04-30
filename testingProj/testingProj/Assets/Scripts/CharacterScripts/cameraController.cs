﻿using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {
	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5f;
	public float smoothing = 2f;
	GameObject charRig;
	public Animator camAnim;

	public bool isDeath = false;

	// Use this for initialization
	void Awake () {
		camAnim = GetComponent<Animator> ();
		charRig = this.transform.parent.gameObject;

	}

	// Update is called once per frame
	void Update () {

		CameraMove ();
		CheckPlayerDeath ();

	}

	void CameraMove() {
		var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); 

		mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);
		mouseLook.y = Mathf.Clamp(mouseLook.y, -90,90);
		mouseLook += smoothV;

		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		charRig.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, charRig.transform.up);

		Cursor.lockState = CursorLockMode.Locked; //Locks the cursor in the middle of screen.

	}

	void CheckPlayerDeath() {
		if (isDeath == true) {
			camAnim.SetTrigger ("IsDeath");

			
		}
	}
}
