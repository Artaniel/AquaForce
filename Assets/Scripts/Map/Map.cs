using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    private Game _game;
    public List<Gem> gems;
    public Spawner spawner;

    public void Init(Game game) {
        _game = game;
    }
}
