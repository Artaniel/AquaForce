using System;
using UnityEngine;

public class SdkAdapter : MonoBehaviour
{
    private Game _game;    

    public void Init(Game game) {
        _game = game;
        PokiUnitySDK.Instance.gameLoadingFinished();
    }

    public void GameplayStart() {
        PokiUnitySDK.Instance.gameplayStart();        
    }

    public void GameplayStop() {
        PokiUnitySDK.Instance.gameplayStop();
    }

    public void CommercialBreakStart() {
        PokiUnitySDK.Instance.commercialBreakCallBack = CommercialBreakEnd;
        PokiUnitySDK.Instance.commercialBreak();
    }

    private void CommercialBreakEnd() {
        
    }
    
    public void RewardedAdsStart() {
        PokiUnitySDK.Instance.rewardedBreakCallBack = RewardedAdsEnd;
        PokiUnitySDK.Instance.commercialBreak();
    }

    private void RewardedAdsEnd(bool withReward) {
        _game.session.AdsReturned(withReward);
    }
}