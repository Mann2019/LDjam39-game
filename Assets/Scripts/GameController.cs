using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject roadPrefab;
    public GameObject roadLead;
    public GameObject car;
    public GameObject fuelPrefab;
    public GameObject coinPrefab;
    public Camera mainCamera;
    public GameObject[] obstacles;

    public float roadProduceTime;
    public float roadProduceRate;
    public float fuelProduceTime;
    public float fuelProduceRate;
    public float fuelSpawnZ;
    public Vector3 roadPos;
    public float[] spawnPoints;
    public int[] coinValues;
    public Text coinText;
    public Color[] bGColors;
    public float environmentDelay = 10f;

    public static int currentCoinValue = 0;

    private Vector3 roadPosition;
    private GameObject road;
    private PlayerMover pm;
    private float spawnPoint;
    private int envirFlag = 0;
    private GameObject obstacle;

    void Start () {
        pm = car.GetComponent<PlayerMover>();
        InvokeRepeating("MoveRoad", roadProduceTime, roadProduceRate);
        InvokeRepeating("ProduceFuel", fuelProduceTime, fuelProduceRate);
        InvokeRepeating("ProduceCoins", fuelProduceTime + 3f, fuelProduceRate + 3f);
        InvokeRepeating("ProduceObstacles", fuelProduceTime + 1.2f, fuelProduceRate + 1.2f);
        InvokeRepeating("ChangeEnvironment", roadProduceTime + 10f, roadProduceRate + 10f);
	}

    private void Update()
    {
        coinText.text = currentCoinValue.ToString();

        /*if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }*/
    }

    public void MoveRoad()
    {
        roadPosition = roadLead.transform.position;
        road = Instantiate(roadPrefab, roadPosition, Quaternion.identity) as GameObject;
        roadLead.transform.position = roadLead.transform.position + roadPos;
    }

    private void ProduceFuel()
    {
        int i = Random.Range(0, spawnPoints.Length);
        spawnPoint = spawnPoints[i];
        Vector3 spawnPos = new Vector3(spawnPoint, 0.0f, fuelSpawnZ + car.transform.position.z);
        Instantiate(fuelPrefab, spawnPos, Quaternion.identity);
    }

    private void ProduceCoins()
    {
        int i = Random.Range(0, spawnPoints.Length);
        spawnPoint = spawnPoints[i];
        Vector3 firstPos = new Vector3(spawnPoint, 0.25f, fuelSpawnZ + car.transform.position.z);
        GameObject firstCoin = Instantiate(coinPrefab, firstPos, Quaternion.identity);
        int k = Random.Range(0, coinValues.Length);
        int num = coinValues[k];
        for (int j=0;j<num;j++)
        {
            Vector3 nextPos = new Vector3(firstCoin.transform.position.x, 0.25f, firstCoin.transform.position.z - 1f);
            GameObject nextCoin = Instantiate(coinPrefab, nextPos, Quaternion.identity);
            firstCoin = nextCoin;
        }
    }

    private void ProduceObstacles()
    {
        int i = Random.Range(0, spawnPoints.Length);
        spawnPoint = spawnPoints[i];
        obstacle = obstacles[envirFlag];
        Vector3 spawnPos = new Vector3(spawnPoint, 0.0f, fuelSpawnZ + car.transform.position.z);
        Instantiate(obstacle, spawnPos, Quaternion.identity);
    }

    private void ChangeEnvironment()
    {
        int i = Random.Range(0, bGColors.Length);
        envirFlag = i;
        mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, bGColors[i], Time.frameCount * environmentDelay);
    }
}
