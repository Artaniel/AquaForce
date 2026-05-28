 using UnityEngine;

public class WaveParticles : MonoBehaviour
{
    private WaterWave _waterWave;
    public ParticleSystem particleSystem;
    
    public void Init(WaterWave waterWave) {
        _waterWave = waterWave;
    }
    
    private void Update() {
        // TODO: Update particle system based on wave properties        
    }
}
