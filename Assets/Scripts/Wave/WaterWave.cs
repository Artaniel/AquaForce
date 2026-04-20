 using UnityEngine;

public class WaterWave : MonoBehaviour
{
    private Game _game;
    public Transform sphere;
    public float positionLerpFactor = 0.1f;
    private Vector3 lastPosition;
    private bool isReleased;
    public Vector3 velocity;
    public Rigidbody waveRigidbidy;
    public float maxMass = 100f;
    public float optimalSpeed = 10f;
    public float maxScale = 10f;
    public float sigmaSharpness = 2f;
    public float massLerpFactor = 0.1f;

    public void Init(Game game) {
        _game = game;
    }

    public void Release() {
        isReleased = true;
        _game.waveFactory.ReleaseWave();
        waveRigidbidy.isKinematic = false;
        waveRigidbidy.linearVelocity = velocity;
    }

    private void Update() {
        if (isReleased) return;
        velocity = (transform.position - lastPosition) / Time.deltaTime; 
        SetMassByVelocity(velocity);
        lastPosition = transform.position;
    }

    public void SetMassByVelocity(Vector3 newVelocity) {
        float targetMass = maxMass * (1f - 1f / (1f + Mathf.Exp(-sigmaSharpness * (newVelocity.magnitude - optimalSpeed))));
        waveRigidbidy.mass = Mathf.Lerp(waveRigidbidy.mass, targetMass, massLerpFactor * Time.deltaTime);
        sphere.localScale = maxScale * waveRigidbidy.mass / maxMass * Vector3.one;
    }
}
