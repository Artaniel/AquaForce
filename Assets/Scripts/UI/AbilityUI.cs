using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    private Game _game;
    private UI _ui;    
    public Button freezeButton;
    public Button waterBoostButton;
    public TextMeshProUGUI freezeButtonText;
    public TextMeshProUGUI waterBoostButtonText;
    public Image freezeProgressBar;

    public void Init(Game game, UI ui) {
        _game = game;
        _ui = ui;
        freezeButton.onClick.AddListener(() => TryUseFreeze());
        waterBoostButton.onClick.AddListener(() => TryUseWaterBoost());
    }
    
    public void Update() {
        freezeProgressBar.fillAmount = _game.abilityFactory.freezeAbility.GetProgress();
    }
    
    private void TryUseFreeze() {
        _game.abilityFactory.TryUseFreeze();
    }
    
    private void TryUseWaterBoost() {
        _game.abilityFactory.TryUseWaterBoost();
    }
}
