using UnityEngine;

public class VoidZone : MonoBehaviour
{
    private Game _game;

    public void Init(Game game){
        _game = game;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (!enemy) return;
        enemy.health.Kill();
        _game.sound.OnVoidZoneDeath();
    }
}
