using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameScreenUI : MonoBehaviour
{
    private Game _game;
    public Button buyFreeze;
    public Button buyWave;
    public Button nextButton;
    public TextMeshProUGUI freezeNumber;
    public TextMeshProUGUI waterBoostNumber;
    
    public void Init(Game game) {
        _game = game;
        nextButton?.onClick.AddListener(NextWithoutAds);
        buyFreeze?.onClick.AddListener(BuyFreeze);
        buyWave?.onClick.AddListener(BuyWave);
    }

    public void Setup() {
        freezeNumber.text = _game.abilityFactory.inventory[_game.abilityFactory.freezeAbility].ToString();
        waterBoostNumber.text = _game.abilityFactory.inventory[_game.abilityFactory.waterBoostAbility].ToString();
    }
    
    private void BuyFreeze() {
    }

    private void BuyWave() {
    
    }
    
    private void NextWithoutAds() {
        _game.session.EndGameConfirm(false);
    }
}
