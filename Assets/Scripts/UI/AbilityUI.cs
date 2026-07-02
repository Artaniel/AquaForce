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
    public Scrollbar freezeProgressBar;

    public void Init(Game game, UI ui) {
        _game = game;
        _ui = ui;
        freezeButton.onClick.AddListener(() => TryUseFreeze());
        waterBoostButton.onClick.AddListener(() => TryUseWaterBoost());
    }
    
    public void Refresh() {
        if (_game.abilityFactory.freezeAbility.isActive) {
            freezeProgressBar.size = _game.abilityFactory.freezeAbility.GetProgress();
            return;
        }
        freezeProgressBar.size = 0;
    }
    
    private void TryUseFreeze() {
        Debug.Log("TryUseFreeze");
        _game.abilityFactory.TryUseFreeze();
    }
    
    private void TryUseWaterBoost() {
        Debug.Log("TryUseWaterBoost");
        _game.abilityFactory.TryUseWaterBoost();
    }
}
