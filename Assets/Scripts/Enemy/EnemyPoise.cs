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
        _enemy.enemyRigidbody.linearDamping = poise * dragMultiplier;
        _enemy.view.Refresh(poise);
    }

    public float GetForceMultiplier() {
        float forceMultiplier = Mathf.Lerp(0f, 1f, poise * 2f - 1f);
        forceMultiplier = Mathf.Max(0f, forceMultiplier);
        return forceMultiplier;
    }

    public void TakeDamage(float speed, float mass, float poiseDamageModifier = 1f) {
        Debug.Log($"TakeDamage: {speed} {mass} {poiseDamageModifier}");
        poise -= speed * damagePerSpeed * mass * poiseDamageModifier;
        poise = Mathf.Max(0f, poise);
        _enemy.view.Refresh(poise);
    }
}
