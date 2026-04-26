using UnityEngine;

public class EnemyDamageAcceptor : MonoBehaviour
{
    private Game _game;
    private Enemy _enemy;

    public void Init(Game game, Enemy enemy) {
        _game = game;
        _enemy = enemy;
    }

    void OnCollisionEnter(Collision collision) {
        
    }

}