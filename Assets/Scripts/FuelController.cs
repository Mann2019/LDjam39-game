using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    //public AudioSource fuelPump;

	void Start () {
		startEngineFuel=0f;
		startReserveFuel=100f;
		engineFuel=startEngineFuel;
		reserveFuel=startReserveFuel;
		SetEngineUI();
		InvokeRepeating("UseFuel", 0.5f, 0.5f);
	}

	public void UseFuel() {
		if(engineFuel!=0) {
			engineFuel=engineFuel-5f;
			SetEngineUI();
		}
		resultingFuel=engineFuel/75f;
	}

	void SetEngineUI() {
		reserveSlider.value = reserveFuel;
		engineSlider.value = engineFuel;
		fillImageEngine.color = Color.Lerp(zeroFuelColor, fullFuelColor, engineFuel/100f);
		fillImageReserve.color = Color.Lerp(zeroFuelColor, fullFuelColor, reserveFuel/startReserveFuel);
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)&&reserveFuel!=0) {
            //if (Input.GetTouch(0).phase == TouchPhase.Began && reserveFuel != 0) {
            //fuelPump.Play();
            if (engineFuel < 91f)
            {
                engineFuel = engineFuel + 10f;
            }
			reserveFuel = reserveFuel-10f;
			SetEngineUI();
		}
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fuel"))
        {
            if(reserveFuel<91f)
            {
                reserveFuel = reserveFuel + fuelUp;
            }
            SetEngineUI();
            Destroy(other.gameObject);
        }
    }
}
