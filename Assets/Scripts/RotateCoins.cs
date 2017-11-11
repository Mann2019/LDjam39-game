using UnityEngine;

public class RotateCoins : MonoBehaviour {

	void FixedUpdate () {
        transform.Rotate(Vector3.up, 2);
    }
}