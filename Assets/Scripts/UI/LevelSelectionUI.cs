using UnityEngine;

public class LevelSelectionUI : MonoBehaviour
{
    private Game _game;
    private UI _ui;

    public void Init(Game game, UI ui) {
        _game = game;
        _ui = ui;
    }
}
