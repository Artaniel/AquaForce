using UnityEngine;

public class Gem : MonoBehaviour
{
    public bool isReserved = false;
    public bool isCarried = false;
    public bool IsDelivered = false;
    public Rigidbody2D gemRigidbody;

    private void OnValidate() {
        if (!gemRigidbody) gemRigidbody = GetComponent<Rigidbody2D>();
    }
}
