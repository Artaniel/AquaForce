using UnityEngine;
using System.Collections.Generic;

public class Session : MonoBehaviour
{
    private Game _game;
    private List<Gem> savedGems;
    private List<Gem> stolenGems;
    private List<SpawnWave> wavesToSpawn;
    private float sessionStartTime;
    private int currentMapIndex = 0;
    
    public void Init(Game game) {
        _game = game;
    }

    public void SessionStart() {
        _game.map = Instantiate(_game.library.maps[currentMapIndex]);
        _game.map.Init(_game);
        savedGems = _game.map.gems;
        stolenGems = new List<Gem>();
        wavesToSpawn = new List<SpawnWave>(_game.map.spawnWaves);
        sessionStartTime = Time.time;
        _game.ui.RefreshCounts();
        Time.timeScale = 1;
        _game.sdkAdapter.GameplayStart();
    }

    private void Update() {
        foreach (SpawnWave spawWave in wavesToSpawn) {
            if (Time.time - sessionStartTime >= spawWave.launchTime) {
                LaunchWave(spawWave);
                wavesToSpawn.Remove(spawWave);
                break;
            }
        }
    }

    private void LaunchWave(SpawnWave spawWave) {
        foreach(Enemy prefab in spawWave.prefabs) {
            _game.enemyFactory.Spawn(prefab);
        }
    }

    public void SessionEnd() { 
        _game.enemyFactory.DestroyAll();
        Destroy(_game.map.gameObject);
        _game.waveFactory.DestroyAll();
        Time.timeScale = 0;
        _game.sdkAdapter.GameplayStop();
    }

    public void StealGem(Gem gem) {
        savedGems.Remove(gem);
        stolenGems.Add(gem);
        _game.ui.RefreshCounts();
    }
    
    public void LoseCheck() {
        if (Time.timeScale == 0) return;
        if (savedGems.Count == 0) {
           Lose();
        }
    }

    public void Lose() {
        _game.ui.ShowLoseScreen();
        _game.sound.OnLose();
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
        currentMapIndex++;
        int score = savedGems.Count * 100;
        _game.ui.ShowWinScreen(score);
        _game.sound.OnWin();
        SessionEnd();
    }

    public int GetSavelGemsCount() => savedGems.Count;
    public int GetStolenGemsCount() => stolenGems.Count;

    public void EndGameConfirm(bool withAds) {
        if (!withAds) {
            NextMap();
            return;
        }
        _game.sdkAdapter.RewardedAdsStart();
    }

    public void AdsReturned(bool sussess) {
        NextMap();
    }

    private void NextMap() {
        _game.ui.HideEndGameScreen();
        SessionStart();                
    }
}
