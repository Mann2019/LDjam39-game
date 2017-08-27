using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour {
    public float invokeTime;
    public float invokeRate;
    public GameObject roadPrefab;
    public GameObject roadLead;
    public GameObject car;
    public GameObject thief;
    public GameObject fuelPrefab;
    public float fuelProduceTime;
    public float fuelProduceRate;
    public Vector3 roadPos;
    public Vector3 fuelSpawnValues;
    public float[] fuelSpawnPoints;

    public bool endGame=false;
    public bool pauseGame=false;

    private Vector3 v;
    private GameObject g;
    private PlayerMover pm;
    private float spawnPoint;

    void Start () {
        pm = car.GetComponent<PlayerMover>();
        InvokeRepeating("GenerateRoad", invokeTime, invokeRate);
        InvokeRepeating("ProduceFuel", fuelProduceTime, fuelProduceRate);
        InvokeRepeating("MoveRoad", 0.3f, 0.3f);
	}

    public void MoveRoad()
    {
        roadLead.transform.position = roadLead.transform.position + roadPos;
    }

    public void GenerateRoad()
    {
        v = roadLead.transform.position;
        g = Instantiate(roadPrefab, v, Quaternion.identity) as GameObject;
    }

    private void ProduceFuel()
    {
        int i = Random.Range(0, fuelSpawnPoints.Length);
        spawnPoint = fuelSpawnPoints[i];
        Vector3 spawnPos = new Vector3(spawnPoint, fuelSpawnValues.y, fuelSpawnValues.z+car.transform.position.z);
        //Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z+car.transform.position.z);
        Instantiate(fuelPrefab, spawnPos, Quaternion.identity);
    }
}
