
using UnityEngine;
using System.Collections.Generic;
 
public class Swamp : MonoBehaviour
{
    public float slowFactor = 0.99f;
 
    private HashSet<Rigidbody2D> _affectedBodies = new HashSet<Rigidbody2D>();
 
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log($"Swamp: OnTriggerEnter2D - {other.name}");
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
            _affectedBodies.Add(rb);
    }
 
    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log($"Swamp: OnTriggerExit2D - {other.name}");
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
            _affectedBodies.Remove(rb);
    }
 
    private void FixedUpdate() {
        foreach (Rigidbody2D rb in _affectedBodies) {
            if (rb != null) 
                rb.linearVelocity *= slowFactor;
        }
    }
}