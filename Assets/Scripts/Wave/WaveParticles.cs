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
    public ParticleSystem sparcleParticles;
    private ParticleSystem.ShapeModule _sparcleShape;
    private ParticleSystem.EmissionModule _sparcleEmission;


    
    public void Init(WaterWave waterWave) {
        _waterWave = waterWave;
        _foamShape = foamParticles.shape;
        _foamEmission = foamParticles.emission;
        _sparcleShape = sparcleParticles.shape;
        _sparcleEmission = sparcleParticles.emission;
    }
    
    public void RefreshParticleCloudRadius(float radius) {
        _foamShape.radius = radius;
        _foamEmission.rateOverDistance = radius * emissionRateMultiplier - minimalRadius;
        _sparcleShape.radius = 0.2f * radius;
        _sparcleEmission.rateOverTime = 5f * radius;
    }
}
