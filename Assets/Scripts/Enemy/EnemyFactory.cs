using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private Game _game;
    public List<Enemy> enemies;    
    public float enemyTimescale = 1f;

    public void Init(Game game) {
        _game = game;
    }

    public void Register(Enemy enemy) {
        enemies.Add(enemy);
        enemy.Init(_game, this);
    }

    public void ManualFixedUpdate(float deltaTime) {
        foreach (Enemy enemy in enemies) {
            enemy?.ManualFixedUpdate(deltaTime * enemyTimescale);
        }
    }

    public void ManualUpdate(float deltaTime) {
        foreach (Enemy enemy in enemies) {
            enemy?.ManualUpdate(deltaTime * enemyTimescale);
        }        
    }

    public void Destroy(Enemy enemy) {
        enemies.Remove(enemy);
        enemy.view.gameObject.SetActive(false);
        //Destroy(enemy.gameObject);
    }

    public int GetAliveEnemyCount() {
        return enemies.FindAll(enemy => enemy.health.isDead == false).Count;
    }

    public void Spawn(Enemy prefab, Spawner spawner) {
        Vector2 offset = Random.insideUnitCircle * spawner.radius;
        Vector3 spawnPosition = spawner.transform.position + new Vector3(offset.x, offset.y, 0f);

        Enemy enemy = Instantiate(prefab, spawnPosition, Quaternion.identity);
        enemies.Add(enemy);
        enemy.Init(_game, this);
        enemy.transform.SetParent(_game.map.transform);
    }

    public void DestroyAll() {
        while (enemies.Count > 0) {
            Enemy enemy = enemies[0];
            enemies.Remove(enemy);
            Destroy(enemy.gameObject);
        }
    }
}
