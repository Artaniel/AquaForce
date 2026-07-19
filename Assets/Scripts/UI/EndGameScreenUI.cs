using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameScreenUI : MonoBehaviour
{
    private Game _game;
    public Button nextWithAds;
    public Button nextWithoutAds;
    public TextMeshProUGUI freezeNumber;
    public TextMeshProUGUI waterBoostNumber;
    
    public void Init(Game game) {
        _game = game;
        nextWithAds?.onClick.AddListener(NextWithAds);
        nextWithoutAds?.onClick.AddListener(NextWithoutAds);
    }

    public void Setup() {
        freezeNumber.text = _game.abilityFactory.inventory[_game.abilityFactory.freezeAbility].ToString();
        waterBoostNumber.text = _game.abilityFactory.inventory[_game.abilityFactory.waterBoostAbility].ToString();
    }
    
    private void NextWithAds() {
        _game.session.OnNextLevelPress(true);
    }
    
    private void NextWithoutAds() {
        _game.session.OnNextLevelPress(false);
    }
}
