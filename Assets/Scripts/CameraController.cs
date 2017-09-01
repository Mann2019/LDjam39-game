using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject car;
	public float speed;
    public float speedUp;

	private PlayerMover pm;
	private float camSpeed;

	void Start() {
		pm=car.GetComponent<PlayerMover>();
        InvokeRepeating("SpeedUp", 30f, 30f);
	}

    void SpeedUp()
    {
        speed = speed + speedUp;
    }

	void Update() {
		//camSpeed = pm.resultantFuel;
        //transform.Translate(Vector3.forward * Time.deltaTime * -speed * camSpeed, Space.World);
    }

	void LateUpdate () {
        //transform.Translate(Vector3.forward*Time.deltaTime*-speed*camSpeed, Space.World);
        //transform.LookAt(car.transform);
        camSpeed = pm.resultantFuel;
        transform.Translate(Vector3.forward * Time.deltaTime * -speed * camSpeed, Space.World);
    }
}
