 using UnityEngine;

public class WaterWave : MonoBehaviour
{
    private Game _game;
    public Transform sphere;

    public void Init(Game game) {
        _game = game;
    }

    private void Update() {
        //Vector3 cursorPosition = _game.mainCamera.ScreenToWorldPoint( Input.mousePosition);
    }
}
