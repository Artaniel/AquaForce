using UnityEngine;

public class WaveView : MonoBehaviour
{
    private WaterWave _wave;
    public Transform spriteTransform;

    public void Init(WaterWave wave) {
        _wave = wave;
    }

    private void Update() {
        spriteTransform.Rotate(Vector3.forward, (_wave.config.rotationSpeedBase + _wave.waveRigidbidy.mass * _wave.config.rotationSpeedPerMass) * Time.deltaTime);
    }

}
