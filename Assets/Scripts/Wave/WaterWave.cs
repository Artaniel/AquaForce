 using UnityEngine;

public class WaterWave : MonoBehaviour
{
    private Game _game;
    public Transform view;
    public TrailRenderer trail;
    private Vector3 lastPosition;
    private bool isReleased;
    public Vector3 velocity;
    public Rigidbody2D waveRigidbidy;
    [HideInInspector] public WaveConfig config => _game.waveFactory.config;
    public WaveParticles waveParticles;

    public WaveView waveView;

    public void Init(Game game) {
        _game = game;
        lastPosition = transform.position;
        trail.Clear();
        waveParticles.Init(this);
        waveView.Init(this);
    }

    public void Release() {
        isReleased = true;
        _game.waveFactory.ReleaseWave();
        waveRigidbidy.simulated = true;
        waveRigidbidy.linearVelocity = velocity;
    }

    private void Update() {
      
    }

    private void FixedUpdate() {
        MassUpdate();
        ForceFieldUpdate();  
    }

    private void MassUpdate() {  
        velocity = (transform.position - lastPosition) / Time.deltaTime;      
        waveRigidbidy.mass -= config.massDecayPerDistance * (transform.position - lastPosition).magnitude;

        if (isReleased) 
            ReleasedMassUpdate();
        else 
            ControledMassUpdate();

        lastPosition = transform.position;
        view.localScale = config.maxScale * waveRigidbidy.mass / config.maxMass * Vector3.one;
        trail.widthMultiplier = config.maxScale * waveRigidbidy.mass / config.maxMass;   
        waveParticles.RefreshParticleCloudRadius(view.localScale.x / 2f);
    }

    private void ReleasedMassUpdate() { 
        waveRigidbidy.mass -= Time.deltaTime * config.releasedDecaySpeed;     
        if (waveRigidbidy.mass < 0) 
            waveRigidbidy.mass = 0;
        if (waveRigidbidy.mass == 0) {
            _game.waveFactory.DestroyWave(this);
        }
    }

    private void ControledMassUpdate() {
        waveRigidbidy.linearVelocity = velocity;
        waveParticles.transform.rotation = Quaternion.LookRotation(Vector3.forward, -velocity);
        if (velocity.magnitude != 0) 
            waveRigidbidy.mass += config.massGainSpeed * Time.deltaTime;
        
        if (waveRigidbidy.mass > config.maxMass)
            waveRigidbidy.mass = config.maxMass;
    }

    private void ForceFieldUpdate() {
        float waveRadius = view.localScale.x / 2 + 0.5f; 
        foreach (Enemy enemy in _game.enemyFactory.enemies) {
            if (!enemy) continue;
            if (Vector3.Distance(enemy.transform.position, transform.position) > waveRadius) continue;
            Vector3 deltaVelocity = velocity - (Vector3)enemy.enemyRigidbody.linearVelocity;
            enemy.enemyRigidbody.AddForce(waveRigidbidy.mass * config.forceModifier * deltaVelocity);
            enemy.poise.TakeDamage(deltaVelocity.magnitude, waveRigidbidy.mass, config.poiseDamageModifier);
        }
        
        foreach (Prop prop in _game.propFactory.props) {
            if (!prop) continue;
            if (Vector3.Distance(prop.transform.position, transform.position) > waveRadius) continue;
            Vector3 deltaVelocity = velocity - (Vector3)prop.propRigidbody.linearVelocity;
            prop.propRigidbody.AddForce(waveRigidbidy.mass * config.forceModifier * deltaVelocity * prop.velocityFraction);
        }
    }    
}
