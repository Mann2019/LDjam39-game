using UnityEngine;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour {

	public float speed;
    public static float speedUp;
	public static float resultantFuel;

    public float xMin;
    public float xMax;
    public bool right = false;
    public bool left = false;
    public Button rightButton;
    public Button leftButton;
    public Text distanceCounter;

    private FuelController fc;
	private Rigidbody rb;
    private Button rbt;
    private Button lbt;
    private int distance = 0;
    private float distFactor = 0.2f;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		fc = gameObject.GetComponent<FuelController>();
        rbt = rightButton.GetComponent<Button>();
        lbt = leftButton.GetComponent<Button>();
        InvokeRepeating("SpeedUp", 30f, 30f);
        InvokeRepeating("CountDistance", 3f, distFactor);
	}

    void SpeedUp()
    {
        speed = speed + speedUp;
    }

    public bool SetTurn(bool turn)
    {
        turn = true;
        return turn;
    }

    public void CountDistance()
    {
        distance = distance + 1;
        distanceCounter.text = distance.ToString();
    }

    void Update() {
        resultantFuel = fc.resultingFuel + 0.5f;
        distFactor = distFactor - Mathf.Abs(fc.resultingFuel)/100;
        transform.Translate(Vector3.forward * Time.deltaTime * -speed * resultantFuel, Space.Self);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -xMin, xMax),
            transform.position.y,
            transform.position.z);
    }
    private void FixedUpdate()
    {
        //For PC/UI controls..
        if (right)
        {
            //if(Input.GetKeyDown(KeyCode.RightArrow)) {
            rb.MovePosition(rb.position + Vector3.right);
            right = false;

        }
        else if (left)
        {
            //else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            rb.MovePosition(rb.position + Vector3.left);
            left = false;
        }

        rbt.onClick.AddListener(delegate
        {
            right = SetTurn(right);
        });
        lbt.onClick.AddListener(delegate
        {
            left = SetTurn(left);
        });

        //For Mobile....
        /*if (Input.GetTouch(0).deltaPosition.x>80)
        {
            rb.MovePosition(rb.position + Vector3.left);
        }
        else if (Input.GetTouch(0).deltaPosition.x<-80)
        {
            rb.MovePosition(rb.position + Vector3.right);
        }*/
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            CancelInvoke("CountDistance");
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Road"))
        {
            Destroy(other.gameObject);
        }
    }
}
