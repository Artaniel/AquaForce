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
    public Image waterBoostProgressBar;    

    public void Init(Game game, UI ui) {
        _game = game;
        _ui = ui;
        freezeButton.onClick.AddListener(() => TryUseFreeze());
        waterBoostButton.onClick.AddListener(() => TryUseWaterBoost());
    }
    
    public void Update() {
        freezeProgressBar.fillAmount = _game.abilityFactory.freezeAbility.GetProgress();
        waterBoostProgressBar.fillAmount = _game.abilityFactory.waterBoostAbility.GetProgress();
    }
    
    private void TryUseFreeze() {
        _game.abilityFactory.TryUseFreeze();
    }
    
    private void TryUseWaterBoost() {
        _game.abilityFactory.TryUseWaterBoost();
    }

    public void RefreshNumbers() {
        freezeButtonText.text = _game.abilityFactory.inventory[_game.abilityFactory.freezeAbility].ToString();
        waterBoostButtonText.text = _game.abilityFactory.inventory[_game.abilityFactory.waterBoostAbility].ToString();        
    }
}
