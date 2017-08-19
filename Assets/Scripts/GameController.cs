using UnityEngine;

public class GameController : MonoBehaviour {
    public float invokeTime;
    public float invokeRate;
    public GameObject roadPrefab;
    public GameObject roadLead;
    public GameObject car;

    private Vector3 v;
    private GameObject g;
    private float roadSpeed;
    private PlayerMover pm;

    void Start () {
        pm = car.GetComponent<PlayerMover>();
        InvokeRepeating("GenerateRoad", invokeTime, invokeRate);
	}

    private void Update()
    {
        roadSpeed = pm.speed * pm.resultantFuel * -100;
    }

    public void GenerateRoad()
    {
        v = roadLead.transform.position;
        g = Instantiate(roadPrefab, v, Quaternion.identity) as GameObject;
        roadLead.transform.Translate(Vector3.forward * Time.deltaTime * roadSpeed, Space.Self);
    }
}
