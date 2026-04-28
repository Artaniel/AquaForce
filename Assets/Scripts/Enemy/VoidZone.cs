using UnityEngine;

public class VoidZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (!enemy) return;
        enemy.health.Kill();
    }
}
