using UnityEngine;
using System.Collections.Generic;

public class Session : MonoBehaviour
{
    private Game _game;
    private List<Gem> savedGems;
    private List<Gem> stolenGems;

    public void Init(Game game) {
        _game = game;
    }

    public void SessionStart() {
        savedGems = _game.map.gems;
        stolenGems = new List<Gem>();
    }

    public void SessionEnd() { 
        
    }

    public void StealGem(Gem gem) {
        savedGems.Remove(gem);
        stolenGems.Add(gem);
        LoseCheck();
    }
    
    public void LoseCheck() {
       if (stolenGems.Count == 0) {
           Lose();
       }
    }

    public void Lose() {
        // Handle game over logic
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
        // Handle win logic
    }
}
