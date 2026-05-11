using UnityEngine;
public class Idle : AiState
{
    private float scanInterval = 0.5f;
    private float lastScanTime = 0f;

    public override void StartState() {
        lastScanTime = Time.time;
    }

    public override void StopState() {
        
    }

    public override void UpdateState() {
        if (Time.time - lastScanTime < scanInterval) return;
        lastScanTime = Time.time;
        
        foreach (Gem gem in _game.map.gems) {
            if (gem.isCarried) continue;
            if (gem.IsDelivered) continue;
            if (gem.isReserved) continue;
            _ai.targetGem = gem;
            gem.isReserved = true;
            _ai.SetState<MoveToGem>();
            return;
        } 
    }
}