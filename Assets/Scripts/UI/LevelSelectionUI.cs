using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionUI : MonoBehaviour
{
    private Game _game;
    private UI _ui;
    public List<LevelButtonUI> levelButtons;
    public Button buyFreezeButton;
    public Button buyWaterButton;
    public Button closeButton;

    public void Init(Game game, UI ui) {
        _game = game;
        _ui = ui;
        for (int i = 0; i < levelButtons.Count; i++) {
            levelButtons[i].Init(_game, this, i);
        }

        buyFreezeButton.onClick.AddListener(BuyFreeze);
        buyWaterButton.onClick.AddListener(BuyWater);
        closeButton.onClick.AddListener(Close);
    }

    private void BuyFreeze(){
        _game.sdkAdapter.RewardedAdsStart((withReward) => {
            if (withReward) {
                _game.abilityFactory.inventory[_game.abilityFactory.freezeAbility]++;
                _game.ui.abilityUi.RefreshNumbers();
            }
        });
    }

    private void BuyWater(){
        _game.sdkAdapter.RewardedAdsStart((withReward) => {
            if (withReward) {
                _game.abilityFactory.inventory[_game.abilityFactory.waterBoostAbility]++;
                _game.ui.abilityUi.RefreshNumbers();
            }
        });
    }

    private void Close() {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
