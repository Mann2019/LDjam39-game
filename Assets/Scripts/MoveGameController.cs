using UnityEngine;

public class MoveGameController : MonoBehaviour {

    public float speed;
    private float moveSpeed;

	void Start () {
        InvokeRepeating("SpeedUp", 30f, 30f);
	}

    private void SpeedUp()
    {
        speed = speed + PlayerMover.speedUp;
    }

    private void LateUpdate()
    {
        moveSpeed = PlayerMover.resultantFuel;
        transform.Translate(Vector3.forward*Time.deltaTime*-speed*moveSpeed, Space.World);
    }

    private void OnCollisionExit(Collision collision)
    {
        Collider other = collision.collider;
        if(!((other.CompareTag("Enemy"))||(other.CompareTag("Player")))) {
            Destroy(other.gameObject);
        }
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
