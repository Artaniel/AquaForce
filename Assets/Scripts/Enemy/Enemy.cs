using UnityEngine;

public class Enemy : MonoBehaviour , IHealthy
{
    private Game _game;
    private EnemyFactory _factory;
    public EnemyDamageAcceptor damageAcceptor;
    public Health health;
    public Rigidbody2D enemyRigidbody;
    public CircleCollider2D enemyCollider;

    void Start() {
        if (_factory) return;
        Game.instance.enemyFactory.Register(this);
    }

    public void Init(Game game, EnemyFactory factory) {
        _game = game;
        _factory = factory;
        health.Init(this);
        damageAcceptor.Init(_game, this);
    }

    public void NonLetalDamage() {
        
    }

    public void Death() {
        Debug.Log("Death");
        _factory.Destroy(this);
    }

    public void Heal() {
        
    }

    private void OnValidate() {
        if (!enemyRigidbody) enemyRigidbody = GetComponent<Rigidbody2D>();
        if (!enemyCollider) enemyCollider = GetComponent<CircleCollider2D>();
    }
}
