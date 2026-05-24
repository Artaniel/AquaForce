using System.Collections.Generic;
using UnityEngine;

public class WaveFactory : MonoBehaviour
{
    private Game _game;
    public WaveConfig config;
    public List<WaterWave> waves;
    public WaterWave controledWave;
    public WaterWave wavePrfab;    

    public void Init(Game game) {
        _game = game;
    }

    public void ManualUpdate(){
        
    }

    public WaterWave StartWave(Vector3 position) {
        controledWave = Instantiate(wavePrfab, position, Quaternion.identity);
        waves.Add(controledWave);
        controledWave.Init(_game);
        return controledWave;
    }

    public void ReleaseWave() {
        controledWave = null;
    }

    public void DestroyWave(WaterWave wave) {
        waves.Remove(wave);
        Destroy(wave.gameObject);
    }
}
