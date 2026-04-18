 using UnityEngine;

public class WaterWave : MonoBehaviour
{
    private Game _game;
    public Transform sphere;

    public void Init(Game game) {
        _game = game;
    }

    public void ManualUpdate() {
        if (!_game.input.cursorIsPressed) return;
        transform.position = _game.input.cursorWorldPosition;
    }
}
