using Unity.VectorGraphics;
using UnityEngine;

public class WaveParticles : MonoBehaviour
{
    private WaterWave _waterWave;
    public ParticleSystem foamParticles;
    private ParticleSystem.ShapeModule _foamShape;
    private ParticleSystem.EmissionModule _foamEmission;
    public float emissionRateMultiplier = 10f;
    public float minimalRadius = 0.1f;

    public ParticleSystem intakeParticles;
    private ParticleSystem.ShapeModule _intakeShape;
    private ParticleSystem.EmissionModule _intakeEmission;
    private ParticleSystem.MainModule _intakeMain;
    public float intakeRingPadding = 0.5f;
    public float intakeMinRadius = 0.3f;
    public float intakeMaxRadius = 20f;
    public float intakeRatePerIntakeSpeed = 40f;
    public float intakeRateBase = 0f;
    public float intakeMaxRate = 400f;
    private float _intakeSpeed;
    private float _currentRadius;
    
    public void Init(WaterWave waterWave) {
        _waterWave = waterWave;

        _foamShape = foamParticles.shape;
        _foamEmission = foamParticles.emission;

        _intakeShape = intakeParticles.shape;
        _intakeEmission = intakeParticles.emission;
        _intakeMain = intakeParticles.main;
    }
    
    public void RefreshParticleCloudRadius(float radius) {
        _foamShape.radius = radius;
        _foamEmission.rateOverDistance = radius * emissionRateMultiplier - minimalRadius;
    }

    public void SetIntakeSpeed(float intakeSpeed) {
        _intakeSpeed = Mathf.Max(0f, intakeSpeed);
        ApplyIntakeEmission();
    }

    private void ApplyIntakeEmission() {
        _intakeEmission.rateOverTime = Mathf.Min(_intakeSpeed * intakeRatePerIntakeSpeed, intakeMaxRate);
    }
}
