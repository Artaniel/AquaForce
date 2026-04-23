using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Game _game;
    private EnemyFactory _factory;

    void Start() {
        if (_factory) return;
        Game.instance.enemyFactory.Register(this);
    }

    public void Init(Game game, EnemyFactory factory) {
        _game = game;
        _factory = factory;
    }
}
