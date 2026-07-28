using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionUI : MonoBehaviour
{
    private Game _game;
    private UI _ui;
    public List<LevelButtonUI> levelButtons;

    public void Init(Game game, UI ui) {
        _game = game;
        _ui = ui;
        foreach(LevelButtonUI button in levelButtons) {
            button.Init(_game, this);
        }
    }
}
