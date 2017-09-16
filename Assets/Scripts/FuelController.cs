﻿using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour {

	private float startReserveFuel;
	private float startEngineFuel;

	public float reserveFuel;
	public float engineFuel;
	public float resultingFuel;
	public Image fillImageEngine;
	public Image fillImageReserve;
	public Slider reserveSlider;
	public Slider engineSlider;
	public Color fullFuelColor = Color.green;
	public Color zeroFuelColor = Color.red;
    public float fuelUp;

	void Start () {
		startEngineFuel=0f;
		startReserveFuel=100f;
		engineFuel=startEngineFuel;
		reserveFuel=startReserveFuel;
		SetEngineUI();
		InvokeRepeating("UseFuel", 1f, 1f);
	}

	public void UseFuel() {
        engineFuel = engineFuel-10f;
		SetEngineUI();
		resultingFuel = engineFuel/75f;
	}

	void SetEngineUI() {
		reserveSlider.value = reserveFuel;
		engineSlider.value = engineFuel;
		fillImageEngine.color = Color.Lerp(zeroFuelColor, fullFuelColor, engineFuel/100f);
		fillImageReserve.color = Color.Lerp(zeroFuelColor, fullFuelColor, reserveFuel/startReserveFuel);
	}
	
	void Update () {
        reserveFuel = Mathf.Clamp(reserveFuel, 0f, 100f);
        engineFuel = Mathf.Clamp(engineFuel, 0f, 100f);
        if (Input.GetKeyDown(KeyCode.Space)) {
        //if (Input.GetTouch(0).phase == TouchPhase.Began) {
            engineFuel = engineFuel + 10f;
            reserveFuel = reserveFuel - 10f;
			SetEngineUI();
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fuel"))
        {
            reserveFuel = reserveFuel + fuelUp;
            SetEngineUI();
            Destroy(other.gameObject);
        }
    }
}
