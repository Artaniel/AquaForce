using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Map : MonoBehaviour
{
    private Game _game;
    public List<Gem> gems;
    public Spawner[] spawners;    
    public Transform gemDropZone;

    public void Init(Game game) {
        _game = game;
    }

    private void OnValidate() {
        gems = GetComponentsInChildren<Gem>().ToList();
        spawners = GetComponentsInChildren<Spawner>();
        if (!gemDropZone && spawners.Length>0) gemDropZone = spawners[0].transform;
    }
}
