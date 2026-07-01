using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Game _game;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI savedGemsText;
    public TextMeshProUGUI stolenGemsText;

    public Transform winScreen;    
    public Button winConfirmButton;
    public Transform loseScreen;
    public Button loseConfirmButton;

    public AbilityUI abilityUi;

    public void Init(Game boot) {
        _game = boot;      
        winConfirmButton.onClick.AddListener(OnWinConfirm);  
        loseConfirmButton.onClick.AddListener(OnLoseConfirm);        
        abilityUi.Init(_game, this);
    }

    public void ShowWinScreen(int score) {
        scoreText.text = score.ToString();
        winScreen.gameObject.SetActive(true);
    }

    public void HideWinScreen() {
        winScreen.gameObject.SetActive(false);
    }

    public void ShowLoseScreen() {
        loseScreen.gameObject.SetActive(true);
    }

    public void HideLoseScreen() {
        loseScreen.gameObject.SetActive(false);
    }

    public void RefreshCounts() {
        savedGemsText.text = _game.session.GetSavelGemsCount().ToString();
        stolenGemsText.text = _game.session.GetStolenGemsCount().ToString();
    }

    private void OnWinConfirm(){
        _game.session.WinConfirm();
    }
    
    private void OnLoseConfirm(){
        _game.session.LoseConfirm();
    }
}
