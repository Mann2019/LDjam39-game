using UnityEngine;

public class RotateCoins : MonoBehaviour {
    //rotate coins and other collectibles..
	void FixedUpdate () {
        transform.Rotate(Vector3.up, 2);
    }
}