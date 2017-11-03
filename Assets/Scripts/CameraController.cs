using UnityEngine;

public class CameraController : MonoBehaviour {

	public float speed;
	private float camSpeed;

	void Start() {
        InvokeRepeating("SpeedUp", 30f, 30f);
	}

    void SpeedUp()
    {
        speed = speed + PlayerMover.speedUp;
    }

	void LateUpdate () {
        camSpeed = PlayerMover.resultantFuel;
        transform.Translate(Vector3.forward * Time.deltaTime * -speed * camSpeed, Space.World);
    }

    public void StopIt()
    {
        CancelInvoke();
    }

    public void RestartInvokes()
    {
        InvokeRepeating("SpeedUp", 0.0f, 30f);
    }
}
