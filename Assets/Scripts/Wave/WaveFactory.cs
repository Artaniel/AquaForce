using System.Collections.Generic;
using UnityEngine;

public class WaveFactory : MonoBehaviour
{
    private Game _game;
    public List<WaterWave> waves;

    public void Init(Game game) {
        _game = game;
    }
}
