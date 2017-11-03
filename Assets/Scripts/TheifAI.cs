using UnityEngine;
using UnityEngine.UI;

public class TheifAI : MonoBehaviour {

    public float speedFactor;
    public Transform policeCar;
    public float startSpeed_min;
    public float startSpeed_max;
    public Slider targetDistanceSlider;

    private int speedFlag = 0;
    private float speed;
    private Vector3 rayDir;
    private RaycastHit hit;
    private Ray backRay;
    private float dist;
    private float progress;

	void Start () {
        speed = Random.Range(startSpeed_min, startSpeed_max);
        InvokeRepeating("CheckDistance", 1.5f, 0.2f);
        targetDistanceSlider.value = 100f;
	}

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * -speed, Space.World);
        dist = Vector3.Distance(policeCar.position, transform.position);
        progress = Mathf.Clamp01(dist/100f);
        targetDistanceSlider.value = progress;
    }

    void CheckDistance()
    {
        Vector3 rayDir = policeCar.position;
        RaycastHit hit;
        Ray backRay = new Ray(transform.position, -rayDir);
        if (Physics.Raycast(backRay, out hit))
        {
            float distn = hit.distance;
            if(distn<2f)
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

    public void StopIt()
    {
        CancelInvoke();
    }

    public void RestartInvokes()
    {
        InvokeRepeating("CheckDistance", 0.0f, 0.2f);
    }
}
