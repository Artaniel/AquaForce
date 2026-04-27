using UnityEngine;

public class EnemyDamageAcceptor : MonoBehaviour
{
    private Game _game;
    private Enemy _enemy;

    public void Init(Game game, Enemy enemy) {
        _game = game;
        _enemy = enemy;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Damager damager = collision.collider.GetComponent<Damager>();
        if (!damager) return;
        if (collision.relativeVelocity.magnitude >= damager.minVelocity) 
            _enemy.health.Damage(1);
    }
}