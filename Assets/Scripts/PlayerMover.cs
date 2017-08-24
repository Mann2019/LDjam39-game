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
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
            rb.MovePosition(rb.position + Vector3.left);
			
		}
		else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            rb.MovePosition(rb.position + Vector3.right);
		}

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -xMin, xMax),
            transform.position.y, 
            transform.position.z);
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Road"))
        {
            Destroy(other.gameObject);
        }
    }
}
