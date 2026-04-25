 using UnityEngine;

public class WaterWave : MonoBehaviour
{
    private Game _game;
    public Transform sphere;
    public TrailRenderer trail;
    public float positionLerpFactor = 0.1f;
    private Vector3 lastPosition;
    private bool isReleased;
    public Vector3 velocity;
    public Rigidbody2D waveRigidbidy;
    public float maxMass = 100f;
    public float maxScale = 10f;
    public float massgainSpeed = 1f;
    public float massDecayPerDistance = 1f;
    public float forceModifier = 1f;

    public void Init(Game game) {
        _game = game;
        lastPosition = transform.position;
    }

    public void Release() {
        isReleased = true;
        _game.waveFactory.ReleaseWave();
        waveRigidbidy.simulated = true;
        waveRigidbidy.linearVelocity = velocity;
    }

    private void Update() {
        MassUpdate();
        ForceFieldUpdate();  
    }

    private void MassUpdate() {
        velocity = (transform.position - lastPosition) / Time.deltaTime;         
        if (velocity.magnitude == 0) return;

        waveRigidbidy.mass -= massDecayPerDistance * (transform.position - lastPosition).magnitude;
        if (waveRigidbidy.mass < 0) waveRigidbidy.mass = 0;
        lastPosition = transform.position;

        if (!isReleased) {
            waveRigidbidy.mass += massgainSpeed * Time.deltaTime;
        }

        sphere.localScale = maxScale * waveRigidbidy.mass / maxMass * Vector3.one;
        trail.widthMultiplier = maxScale * waveRigidbidy.mass / maxMass;      
    }

    private void ForceFieldUpdate() {
        float waveRadius = sphere.localScale.x; 
        foreach (Enemy enemy in _game.enemyFactory.enemies) {
            if (!enemy) continue;
            if (Vector3.Distance(enemy.transform.position, transform.position) > waveRadius) continue;
            Vector3 deltaVelocity = velocity - (Vector3)enemy.enemyRigidbody.linearVelocity;
            enemy.enemyRigidbody.AddForce(waveRigidbidy.mass * forceModifier * deltaVelocity);
        }
    }    
}
