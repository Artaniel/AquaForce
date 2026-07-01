using UnityEngine;

public class Enemy : MonoBehaviour , IHealthy
{
    private Game _game;
    private EnemyFactory _factory;
    public EnemyDamageAcceptor damageAcceptor;
    public Health health;
    public EnemyAI ai;
    public EnemyPoise poise;
    public Rigidbody2D enemyRigidbody;
    public CircleCollider2D enemyCollider;    
    public Transform mainSprite;
    public EnemyView view;
    public EnemySound sound;

    void Start() {
        if (_factory) return;
        //Debug.LogWarning("Enemy was not inited.");
        Game.instance.enemyFactory.Register(this);
    }

    public void Init(Game game, EnemyFactory factory) {
        _game = game;
        _factory = factory;
        health.Init(this);
        damageAcceptor.Init(_game, this);
        ai.Init(_game, this);
        poise.Init(_game, this);
        view.Init(_game, this);
        sound.Init(_game, this);
    }

    public void NonLetalDamage() {
        sound.Hit();
    }
    
    public void ManualFixedUpdate(float deltaTime) {
        ai.ManualFixedUpdate(deltaTime);
        view.ManualFixedUpdate(deltaTime);
    }

    public void Death() {        
        sound.Death();
        _game.session.EnemyKilled();
        _factory.Destroy(this); 
    }

    private void OnValidate() {
        if (!enemyRigidbody) enemyRigidbody = GetComponent<Rigidbody2D>();
        if (!enemyCollider) enemyCollider = GetComponent<CircleCollider2D>();
        if (!view) view = GetComponentInChildren<EnemyView>();
    }
}
