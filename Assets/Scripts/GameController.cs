using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject roadPrefab;
    public GameObject roadLead;
    public GameObject car;
    public GameObject thief;
    public GameObject fuelPrefab;
    public GameObject coinPrefab;
    public GameObject bushPrefab;
    public Camera mainCamera;

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

    public static int currentCoinValue = 0;

    private Vector3 v;
    private GameObject g;
    private PlayerMover pm;
    private float spawnPoint;
    //private int c;

    void Start () {
        pm = car.GetComponent<PlayerMover>();
        InvokeRepeating("GenerateRoad", roadProduceTime, roadProduceRate);
        InvokeRepeating("ProduceFuel", fuelProduceTime, fuelProduceRate);
        InvokeRepeating("ProduceCoins", fuelProduceTime + 3f, fuelProduceRate + 3f);
        InvokeRepeating("ProduceObstacles", fuelProduceTime + 1.2f, fuelProduceRate + 1.2f);
        InvokeRepeating("MoveRoad", roadProduceTime, roadProduceRate);
        //InvokeRepeating("ChangeEnvironment", roadProduceTime + 1f, roadProduceRate + 1f);
	}

    private void Update()
    {
        coinText.text = currentCoinValue.ToString();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    /*private void ChangeEnvironment()
    {
        mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, bGColors[c], 100f);
        if (c>2)
        {
            c = 0;
        }
        else
        {
            c++;
        }
    }*/

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
        Vector3 spawnPos = new Vector3(spawnPoint, 0.0f, fuelSpawnZ + car.transform.position.z);
        Instantiate(bushPrefab, spawnPos, Quaternion.identity);
    }
}
