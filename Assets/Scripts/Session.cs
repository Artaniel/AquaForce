using UnityEngine;
using System.Collections.Generic;

public class Session : MonoBehaviour
{
    private Game _game;
    private List<Gem> savedGems;
    private List<Gem> stolenGems;
    private List<SpawnWave> completedWaves;
    private float sessionStartTime;

    public void Init(Game game) {
        _game = game;
    }

    public void SessionStart() {
        _game.map.Init(_game);
        savedGems = _game.map.gems;
        stolenGems = new List<Gem>();
        completedWaves = new();
        sessionStartTime = Time.time;
        _game.ui.RefreshCounts();
    }

    private void Update() {
        foreach (SpawnWave spawWave in _game.map.spawnWaves) {
            if (completedWaves.Contains(spawWave)) continue;
            if (spawWave.launchTime >= Time.time - sessionStartTime) {
                LaunchWave(spawWave);
            }
        }
    }

    private void LaunchWave(SpawnWave spawWave) {
        foreach(Enemy prefab in spawWave.prefabs) {
            _game.enemyFactory.Spawn(prefab);
        }
        completedWaves.Add(spawWave);
    }

    public void SessionEnd() { 
        
    }

    public void StealGem(Gem gem) {
        savedGems.Remove(gem);
        stolenGems.Add(gem);
        _game.ui.RefreshCounts();
        LoseCheck();
    }
    
    public void LoseCheck() {
       if (stolenGems.Count == 0) {
           Lose();
       }
    }

    public void Lose() {
        // Handle game over logic

        SessionEnd();
    }

    public void EnemyKilled() {
        WinCheck();
    }

    public void WinCheck() {
       if (_game.enemyFactory.GetAliveEnemyCount() == 0) {
            Win();
        }
    }
    
    public void Win() {
        int score = savedGems.Count * 100;
        _game.ui.ShowWinScreen(score);
        SessionEnd();
    }

    public int GetSavelGemsCount() => savedGems.Count;
    public int GetStolenGemsCount() => stolenGems.Count;
}
