using UnityEngine;

public class CameraController : MonoBehaviour {

	//public GameObject car;
	public float speed;
    public float speedUp;

	//private PlayerMover pm;
	private float camSpeed;

	void Start() {
		//pm=car.GetComponent<PlayerMover>();
        InvokeRepeating("SpeedUp", 30f, 30f);
	}

    void SpeedUp()
    {
        //speed = speed + speedUp;
        speed = speed + PlayerMover.speedUp;
    }

	void LateUpdate () {
        //camSpeed = pm.resultantFuel;
        camSpeed = PlayerMover.resultantFuel;
        transform.Translate(Vector3.forward * Time.deltaTime * -speed * camSpeed, Space.World);
    }
}
