using UnityEngine;

public class WaveStarter : MonoBehaviour
{   
    private Game _game;
    private WaterWave controledWave => _game.waveFactory.controledWave;

    public void Init(Game game) {
        _game = game;
        _game.input.OnCursorPress += OnCursorPress;
        _game.input.OnCursorRelease += OnCursorRelease;
    }

    public void ManualUpdate() {
        if (!_game.input.cursorIsPressed) return;
        if (!controledWave) return;

        controledWave.transform.position = Vector3.Lerp(controledWave.transform.position, 
            _game.input.cursorWorldPosition, _game.waveFactory.config.positionLerpFactor);
    }

    private void OnCursorPress() {
        _game.waveFactory.StartWave(_game.input.cursorWorldPosition);
        _game.sound.OnPress();
    }

    private void OnCursorRelease() {
        controledWave?.Release(); 
        _game.sound.OnRelease();
    }

    void OnDestroy() {
         _game.input.OnCursorPress -= OnCursorPress;
         _game.input.OnCursorRelease -= OnCursorRelease;
    }
}
