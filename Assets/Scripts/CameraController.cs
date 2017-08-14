using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject car;
	public float speed;

	private PlayerMover pm;
	private float camSpeed;

	void Start() {
		pm=car.GetComponent<PlayerMover>();
	}

	void Update() {
		camSpeed = pm.resultantFuel;
	}

	void LateUpdate () {
		transform.Translate(Vector3.right*Time.deltaTime*-speed*camSpeed, Space.Self);
	}
}
