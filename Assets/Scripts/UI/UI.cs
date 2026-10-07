using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Game _game;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI savedGemsText;
    public TextMeshProUGUI stolenGemsText;

    public EndGameScreenUI winScreen;    
    public EndGameScreenUI loseScreen;

    public AbilityUI abilityUi;
    public LevelSelectionUI levelSelectionUI;
    public FinalScreenUI finalScreenUI;
    public Button mapSelectButton;


    public void Init(Game boot) {
        _game = boot;       
        abilityUi.Init(_game, this);
        winScreen.Init(_game);
        loseScreen.Init(_game);
        levelSelectionUI.Init(_game, this);
        finalScreenUI.Init(_game, this);
        mapSelectButton.onClick.AddListener(LevelSelectionOpen);
    }

    public void ShowWinScreen(int score) {
        scoreText.text = score.ToString();
        winScreen.gameObject.SetActive(true);
        winScreen.Setup();
    }

    public void HideEndGameScreen() {
        winScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
    }

    public void ShowLoseScreen() {
        loseScreen.gameObject.SetActive(true);
        loseScreen.Setup();
    }

    public void RefreshCounts() {
        savedGemsText.text = _game.session.GetSavelGemsCount().ToString();
        stolenGemsText.text = _game.session.GetStolenGemsCount().ToString();
    }

    private void LevelSelectionOpen() {
        levelSelectionUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowFinalScreen() {
        finalScreenUI.Open();
    }

    public bool UiAllowsWave() {
        if (winScreen.gameObject.activeSelf) return false;
        if (loseScreen.gameObject.activeSelf) return false;
        if (finalScreenUI.gameObject.activeSelf) return false;
        return true;
    }
}
