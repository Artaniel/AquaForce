using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private Game _game;
    public List<Enemy> enemies;    

    public void Init(Game game) {
        _game = game;
    }

    public void Register(Enemy enemy) {
        enemies.Add(enemy);
        enemy.Init(_game, this);
    }

    public void Destroy(Enemy enemy) {
        enemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }

    public int GetAliveEnemyCount() {
        return enemies.FindAll(enemy => enemy.health.isDead == false).Count;
    }

    public void Spawn(Enemy prefab) {
        Enemy enemy = Instantiate(prefab, _game.map.spawner.transform.position, Quaternion.identity);
        enemies.Add(enemy);
        enemy.Init(_game, this);
        enemy.transform.SetParent(_game.map.transform);
    }
}
