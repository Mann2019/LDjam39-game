using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheifAI : MonoBehaviour {

    public float[] speeds;
    public float speedFactor;
    public Transform policeCar;

    private int speedFlag = 0;
    private float speed;

	void Start () {
        int i = Random.Range(0, speeds.Length);
        speed = speeds[i];
        InvokeRepeating("CheckDistance", 3f, 0.3f);
	}

	void Update () {
        transform.Translate(Vector3.forward*Time.deltaTime*-speed, Space.World);
	}

    void CheckDistance()
    {
        Vector3 rayDir = policeCar.position;
        RaycastHit hit;
        Ray backRay = new Ray(transform.position, -rayDir);
        if (Physics.Raycast(backRay, out hit))
        {
            float dist = hit.distance;
            if(dist<2f)
            {
                SpeedUp();
                speedFlag = 1;
                Invoke("SpeedDown", 3f);
            }
        }
    }

    void SpeedUp()
    {
        if(speedFlag==0)
        {
            speed = speed + speedFactor;
        }
    }

    void SpeedDown()
    {
        if(speedFlag==1)
        {
            speed = speed - speedFactor;
            speedFlag = 0;
        }
    }
}
