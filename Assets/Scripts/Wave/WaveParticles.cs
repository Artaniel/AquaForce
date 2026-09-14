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
    
    public void Init(WaterWave waterWave) {
        _waterWave = waterWave;
        _foamShape = foamParticles.shape;
        _foamEmission = foamParticles.emission;
    }
    
    public void RefreshParticleCloudRadius(float radius) {
        _foamShape.radius = radius;
        _foamEmission.rateOverDistance = radius * emissionRateMultiplier - minimalRadius;
    }
}
