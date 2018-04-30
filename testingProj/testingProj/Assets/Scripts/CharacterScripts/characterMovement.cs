using UnityEngine;
using System.Collections;

public class characterMovement : MonoBehaviour {

	private Rigidbody rb;
	float plrMoveSpd;
	public GameObject charCam;
	private float translation;
	private float straffe;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () {

		Movement ();
		//CheckHealth ();

	}

	void Movement() {
		//plrMoveSpd = 17f;
		Time.timeScale = 1;

		translation = Input.GetAxis("Vertical") * plrMoveSpd;
		straffe = Input.GetAxis("Horizontal") * plrMoveSpd;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		rb.transform.Translate(straffe, 0, translation);

		if (Input.GetKey(KeyCode.LeftShift)) {
			plrMoveSpd = 25f;
			print ("Sprint");
		} else {
			plrMoveSpd = 18f;
		}
	}
		
}
