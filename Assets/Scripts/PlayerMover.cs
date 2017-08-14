using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	public float speed;
	public float resultantFuel;
	public float xMin;
	public float xMax;

	private FuelController fc;
	private Rigidbody rb;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		fc = gameObject.GetComponent<FuelController>();
	}

	void Update () {
		resultantFuel=fc.resultingFuel+0.5f;
		transform.Translate(Vector3.forward*Time.deltaTime*-speed*resultantFuel, Space.Self);
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			rb.MovePosition(rb.position+Vector3.left);
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow)) {
			rb.MovePosition(rb.position+Vector3.right);
		}
	}
}
