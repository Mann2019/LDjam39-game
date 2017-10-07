using UnityEngine;

public class TheifAI : MonoBehaviour {

    public float speedFactor;
    public Transform policeCar;
    public float startSpeed_min;
    public float startSpeed_max;

    private int speedFlag = 0;
    private float speed;

	void Start () {
        speed = Random.Range(startSpeed_min, startSpeed_max);
        InvokeRepeating("CheckDistance", 2f, 0.2f);
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
                Invoke("SpeedDown", 4f);
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
