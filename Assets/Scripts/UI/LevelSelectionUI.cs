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

    public void Init(Game game, UI ui) {
        _game = game;
        _ui = ui;
        foreach(LevelButtonUI button in levelButtons) {
            button.Init(_game, this);
        }

        buyFreezeButton.onClick.AddListener(BuyFreeze);
        buyWaterButton.onClick.AddListener(BuyWater);
    }

    private void BuyFreeze(){
        _game.sdkAdapter.RewardedAdsStart((withReward) => {
            if (withReward) {
                //_game.abilityFactory.inventory
            }
        });
    }

    private void BuyWater(){
        _game.sdkAdapter.RewardedAdsStart((withReward) => {
            if (withReward) {
                // TODO: Buy water
            }
        });
    }
}
