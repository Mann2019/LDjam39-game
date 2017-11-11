using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float zOffset;
    public float smoothSpeed = 0.2f;

    private Vector3 currVelo;
    private Vector3 newPos;

	void LateUpdate () {

        if (target)
        {
            newPos = new Vector3(transform.position.x, transform.position.y, target.position.z+zOffset);
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currVelo, smoothSpeed * Time.deltaTime);
            //transform.position = newPos;
            //transform.LookAt(target);
        }
    }
}
