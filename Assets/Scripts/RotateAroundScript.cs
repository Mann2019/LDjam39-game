using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundScript : MonoBehaviour {
    public float rotateBy;
	void Update () {
        transform.RotateAround(Vector3.up, Vector3.zero, rotateBy*Time.deltaTime);
	}
}
