using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour {

	private float startReserveFuel;
	private float startEngineFuel;
    private Rigidbody rb;

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
    public float fuelLoss;
    public float fueluseRate;

	void Start () {
		startEngineFuel=0f;
		startReserveFuel=100f;
		engineFuel=startEngineFuel;
		reserveFuel=startReserveFuel;
		SetEngineUI();
		InvokeRepeating("UseFuel", 0.1f, fueluseRate);
        rb = gameObject.GetComponent<Rigidbody>();
	}

	public void UseFuel() {
        engineFuel = engineFuel-0.1f;
		SetEngineUI();
		resultingFuel = engineFuel/50f;
	}

	public void SetEngineUI() {
		reserveSlider.value = reserveFuel;
		engineSlider.value = engineFuel;
		fillImageEngine.color = Color.Lerp(zeroFuelColor, fullFuelColor, engineFuel/100f);
		fillImageReserve.color = Color.Lerp(zeroFuelColor, fullFuelColor, reserveFuel/startReserveFuel);
	}
	
	void Update () {
        reserveFuel = Mathf.Clamp(reserveFuel, 0f, 100f);
        engineFuel = Mathf.Clamp(engineFuel, 0f, 100f);
	}

    public void PumpFuel()
    {
        if (reserveFuel > 0f && engineFuel < 100f)
        {
            engineFuel = engineFuel + 10f;
            reserveFuel = reserveFuel - 10f;
            SetEngineUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fuel"))
        {
            Destroy(other.gameObject);
            reserveFuel = reserveFuel + fuelUp;
            SetEngineUI();
        }
        if (other.CompareTag("Obstacle"))
        {
            engineFuel = engineFuel - fuelLoss;
            SetEngineUI();
        }
    }

    public void StopIt()
    {
        CancelInvoke();
    }

    public void RestartInvokes()
    {
        InvokeRepeating("UseFuel", 0.1f, 1f);
    }
}
