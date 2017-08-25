using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImovement : MonoBehaviour {

    public float speed;
    public float speedFactor;
    public GameObject player;

    private PlayerMover pm;
    private FuelController fc;

    void Start () {
        pm = player.GetComponent<PlayerMover>();
        fc = player.GetComponent<FuelController>();
        InvokeRepeating("CheckDistanceToEnd", 5f, 0.1f);
	}
	
	void Update () {
        PushSpeed();
        //Invoke("CheckDistanceToEnd", 5f);
        transform.Translate(Vector3.forward*Time.deltaTime*-speed, Space.World);
	}

    void PushSpeed()
    {
        RaycastHit hit;
        Ray backRay = new Ray(transform.position, -Vector3.forward);
        if (Physics.Raycast(backRay, out hit))
        {
            float dist = hit.distance;
            if (dist < 1f)
            {
                speed = speed + speedFactor;
                Invoke("SpeedDown", 4f);
            }
        }
    }

    void CheckDistanceToEnd()
    {
        RaycastHit hit;
        Ray backRay = new Ray(transform.position, -Vector3.forward);
        if(Physics.Raycast(backRay, out hit))
        {
            float dist = hit.distance;
            if(dist>59.5f)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
    void SpeedDown()
    {
        speed = speed - speedFactor;
    }
}
