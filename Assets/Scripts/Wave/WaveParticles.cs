using Unity.VectorGraphics;
using UnityEngine;

public class WaveParticles : MonoBehaviour
{
    private WaterWave _waterWave;
    public ParticleSystem particles;
    private ParticleSystem.ShapeModule _shape;
    
    public void Init(WaterWave waterWave) {
        _waterWave = waterWave;
        _shape = particles.shape;
    }
    
    public void RefreshParticleCloudRadius(float radius) {
        _shape.radius = radius;
    }
}
