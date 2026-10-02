using UnityEngine;
using UnityEngine.UI;

public class LevelButtonUI : MonoBehaviour
{
    private Game _game;
    private LevelSelectionUI _levelSelectionUI;
    private FinalScreenUI _finalScreenUI;
    private int _levelIndex;
    public Button button;

    public void Init(Game game, LevelSelectionUI levelSelectionUI, int levelIndex) {
        _game = game;
        _levelSelectionUI = levelSelectionUI;
        _levelIndex = levelIndex;
        button.onClick.AddListener(OnClick);
    }

    public void Init(Game game, FinalScreenUI finalScreenUI, int levelIndex) {
        _game = game;
        _finalScreenUI = finalScreenUI;
        _levelIndex = levelIndex;
        button.onClick.AddListener(OnClick);
    }
    
    public void OnClick() {
        _levelSelectionUI.gameObject.SetActive(false);
        _game.session.SwitchToLevel(_levelIndex);
    }
}
