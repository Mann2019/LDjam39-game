﻿using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject roadPrefab;
    public GameObject roadLead;
    public GameObject car;
    public GameObject thief;
    public GameObject fuelPrefab;
    public GameObject coinPrefab;

    public float roadProduceTime;
    public float roadProduceRate;
    public float fuelProduceTime;
    public float fuelProduceRate;
    public Vector3 roadPos;
    public Vector3 fuelSpawnValues;
    public float[] fuelSpawnPoints;
    public int[] coinValues;
    public bool endGame=false;
    public bool pauseGame=false;
    public Text coinText;
    public static int currentCoinValue = 0;

    private Vector3 v;
    private GameObject g;
    private PlayerMover pm;
    private float spawnPoint;

    void Start () {
        pm = car.GetComponent<PlayerMover>();
        InvokeRepeating("GenerateRoad", roadProduceTime, roadProduceRate);
        InvokeRepeating("ProduceFuel", fuelProduceTime, fuelProduceRate);
        InvokeRepeating("ProduceCoins", fuelProduceTime + 1.5f, fuelProduceRate + 1.5f);
        InvokeRepeating("MoveRoad", roadProduceTime, roadProduceRate);
	}

    private void Update()
    {
        coinText.text = currentCoinValue.ToString();
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
        Instantiate(fuelPrefab, spawnPos, Quaternion.identity);
    }

    private void ProduceCoins()
    {
        int i = Random.Range(0, fuelSpawnPoints.Length);
        spawnPoint = fuelSpawnPoints[i];
        Vector3 spawnPos = new Vector3(spawnPoint, fuelSpawnValues.y+0.25f, fuelSpawnValues.z + car.transform.position.z);
        GameObject firstCoin = Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        int k = Random.Range(0, coinValues.Length);
        int num = coinValues[k];
        for (int j=0;j<num;j++)
        {
            Vector3 nextPos = new Vector3(firstCoin.transform.position.x, fuelSpawnValues.y+0.25f, firstCoin.transform.position.z - 1f);
            GameObject nextCoin = Instantiate(coinPrefab, nextPos, Quaternion.identity);
            firstCoin = nextCoin;
        }
    }
}
