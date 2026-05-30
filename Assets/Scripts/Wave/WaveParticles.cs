using Unity.VectorGraphics;
using UnityEngine;

public class WaveParticles : MonoBehaviour
{
    private WaterWave _waterWave;
    public ParticleSystem particles;
    private ParticleSystem.ShapeModule _shape;
    private ParticleSystem.EmissionModule _emission;
    public float emissionRateMultiplier = 10f;
    public float minimalRadius = 0.1f;
    
    public void Init(WaterWave waterWave) {
        _waterWave = waterWave;
        _shape = particles.shape;
        _emission = particles.emission;
    }
    
    public void RefreshParticleCloudRadius(float radius) {
        _shape.radius = radius;
        _emission.rateOverDistance = radius * emissionRateMultiplier - minimalRadius;
    }
}
