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

    public void Init(Game boot) {
        _game = boot;      
        winConfirmButton.onClick.AddListener(OnWinConfirm);  
    }

    public void ShowWinScreen(int score) {
        scoreText.text = score.ToString();
        winScreen.gameObject.SetActive(true);
    }

    public void HideWinScreen() {
        winScreen.gameObject.SetActive(false);
    }

    public void RefreshCounts() {
        savedGemsText.text = _game.session.GetSavelGemsCount().ToString();
        stolenGemsText.text = _game.session.GetStolenGemsCount().ToString();
    }

    private void OnWinConfirm(){
        _game.session.WinConfirm();
    }
}
