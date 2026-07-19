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


    public void Init(Game boot) {
        _game = boot;       
        abilityUi.Init(_game, this);
        winScreen.Init(_game);
        loseScreen.Init(_game);
    }

    public void ShowWinScreen(int score) {
        scoreText.text = score.ToString();
        winScreen.gameObject.SetActive(true);
        winScreen.Setup();
    }

    public void HideWinScreen() {
        winScreen.gameObject.SetActive(false);
    }

    public void ShowLoseScreen() {
        loseScreen.gameObject.SetActive(true);
        loseScreen.Setup();
    }

    public void HideLoseScreen() {
        loseScreen.gameObject.SetActive(false);
    }

    public void RefreshCounts() {
        savedGemsText.text = _game.session.GetSavelGemsCount().ToString();
        stolenGemsText.text = _game.session.GetStolenGemsCount().ToString();
    }
}
