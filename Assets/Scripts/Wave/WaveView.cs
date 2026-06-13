using UnityEngine;

public class WaveView : MonoBehaviour
{
    private WaterWave _wave;
    public Transform spriteTransform;
    public float rotationSpeedBase = 1f;
    public float rotationSpeedPerMass = 1f;

    public void Init(WaterWave wave) {
        _wave = wave;
    }

    private void Update() {
        spriteTransform.Rotate(Vector3.forward, (rotationSpeedBase + _wave.waveRigidbidy.mass * rotationSpeedPerMass) * Time.deltaTime);
    }

}
