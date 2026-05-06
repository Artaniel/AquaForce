using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Map : MonoBehaviour
{
    private Game _game;
    public List<Gem> gems;
    public Spawner spawner;
    public SpawnWave[] spawnWaves;

    public void Init(Game game) {
        _game = game;
    }

    private void OnValidate() {
        gems = GetComponentsInChildren<Gem>().ToList();
        spawner = GetComponentInChildren<Spawner>();
    }
}
