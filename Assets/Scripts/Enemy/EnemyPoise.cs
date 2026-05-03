using UnityEngine;

public class EnemyPoise : MonoBehaviour
{  

    private Game _game;
    private Enemy _enemy;
    public float poise = 1;
    public float dragMultiplier = 1f;
    public float recoveryRate = 0.1f;
    public float damagePerSpeed = 1f;

    public void Init(Game game, Enemy enemy) {
        _game = game;
        _enemy = enemy;
    }
    
    public void Update() {
        poise += recoveryRate * Time.deltaTime; 
        poise = Mathf.Clamp01(poise);
        _enemy.enemyRigidbody.linearDamping = poise * dragMultiplier;// * GetSpeedMultiplier();
    }

    public float GetForceMultiplier() {
        float forceMultiplier = Mathf.Lerp(0f, 1f, poise * 2f - 1f);
        forceMultiplier = Mathf.Max(0f, forceMultiplier);
        return forceMultiplier;
    }
    
    private float GetSpeedMultiplier() {
        float speed = _enemy.enemyRigidbody.linearVelocity.magnitude;
        //TODO Формула и пороги подбираются в тесте
        return Mathf.Clamp01(1f - speed / 10f);
    }

    public void TakeDamage(float speed) {
        poise -= speed * damagePerSpeed;
        poise = Mathf.Max(0f, poise);
    }
}
