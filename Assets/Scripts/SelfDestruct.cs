using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public int destroyAfter;

    private void Start()
    {
        Destroy(gameObject, destroyAfter);
    }
}
