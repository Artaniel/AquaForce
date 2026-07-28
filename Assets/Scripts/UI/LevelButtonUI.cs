using UnityEngine;

public class LevelButtonUI : MonoBehaviour
{
    private Game _game;
    private LevelSelectionUI _levelSelectionUI;

    public void Init(Game game, LevelSelectionUI levelSelectionUI) {
        _game = game;
        _levelSelectionUI = levelSelectionUI;
    }
}
