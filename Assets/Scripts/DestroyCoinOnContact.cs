using UnityEngine;

public class DestroyCoinOnContact : MonoBehaviour {
    //This is for destroying the coins to avoid overlapping
	void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")||other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
    }
}
