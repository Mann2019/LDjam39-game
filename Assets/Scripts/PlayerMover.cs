using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	public float speed;
    public float speedUp;
	public float resultantFuel;
    public float xMin;
    public float xMax;

	private FuelController fc;
	private Rigidbody rb;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		fc = gameObject.GetComponent<FuelController>();
        InvokeRepeating("SpeedUp", 30f, 30f);
	}

    void SpeedUp()
    {
        speed = speed + speedUp;
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Road"))
        {
            Destroy(other.gameObject);
        }
    }
}
