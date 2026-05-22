 using UnityEngine;

public class WaterWave : MonoBehaviour
{
    private Game _game;
    public Transform view;
    public TrailRenderer trail;
    public float positionLerpFactor = 0.1f;
    private Vector3 lastPosition;
    private bool isReleased;
    public Vector3 velocity;
    public Rigidbody2D waveRigidbidy;
    public float maxMass = 100f;
    public float maxScale = 10f;
    public float massGainSpeed = 1f;
    public float massDecayPerDistance = 1f;
    public float forceModifier = 1f;
    public float releasedDecaySpeed = 1f;

    private Material material;
    public MeshRenderer sphereMeshRenderer;

    public void Init(Game game) {
        _game = game;
        lastPosition = transform.position;
        trail.Clear();
        material = sphereMeshRenderer.material;
    }

    public void Release() {
        isReleased = true;
        _game.waveFactory.ReleaseWave();
        waveRigidbidy.simulated = true;
        waveRigidbidy.linearVelocity = velocity;
    }

    private void Update() {
     
        material.SetFloat("StreachValue", velocity.magnitude * 1000f);
        material.SetVector("Direction", velocity.normalized);   
    }

    private void FixedUpdate() {
        MassUpdate();
        ForceFieldUpdate();  
    }

    private void MassUpdate() {  
        velocity = (transform.position - lastPosition) / Time.deltaTime;      
        waveRigidbidy.mass -= massDecayPerDistance * (transform.position - lastPosition).magnitude;

        if (isReleased) 
            ReleasedMassUpdate();
        else 
            ControledMassUpdate();

        lastPosition = transform.position;
        view.localScale = maxScale * waveRigidbidy.mass / maxMass * Vector3.one;
        trail.widthMultiplier = maxScale * waveRigidbidy.mass / maxMass;     
    }

    private void ReleasedMassUpdate() { 
        waveRigidbidy.mass -= Time.deltaTime * releasedDecaySpeed;     
        if (waveRigidbidy.mass < 0) 
            waveRigidbidy.mass = 0;
        if (waveRigidbidy.mass == 0) {
            _game.waveFactory.DestroyWave(this);
        }
    }

    private void ControledMassUpdate() {
        if (velocity.magnitude != 0) 
            waveRigidbidy.mass += massGainSpeed * Time.deltaTime;
    }

    private void ForceFieldUpdate() {
        float waveRadius = view.localScale.x / 2 + 0.5f; 
        foreach (Enemy enemy in _game.enemyFactory.enemies) {
            if (!enemy) continue;
            if (Vector3.Distance(enemy.transform.position, transform.position) > waveRadius) continue;
            Vector3 deltaVelocity = velocity - (Vector3)enemy.enemyRigidbody.linearVelocity;
            enemy.enemyRigidbody.AddForce(waveRigidbidy.mass * forceModifier * deltaVelocity);
            enemy.poise.TakeDamage(deltaVelocity.magnitude);
        }
    }    
}
