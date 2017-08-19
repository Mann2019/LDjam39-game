using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float destructionTimer;

	// Use this for initialization
	void Start () {
        StartCoroutine("DestroyYourself");
	}

    IEnumerator DestroyYourself()
    {
        yield return new WaitForSeconds(destructionTimer);
        Destroy(gameObject);
    }
}
