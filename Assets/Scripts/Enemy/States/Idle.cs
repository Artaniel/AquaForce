using UnityEngine;
public class Idle : AiState
{
    private float scanInterval = 0.5f;
    private float lastScanTime = 0f;
    private float wanderStartTime;  
    private bool isWandering = false;
    private Vector2 wanderDir;
    private float wanderCooldown = 1f;
    private float wanderDuration = 1f;
    private float wanderSpeed = 1f;

    public override void StartState() {
        lastScanTime = Time.time;
        wanderStartTime = Time.time;
    }

    public override void StopState() {
        
    }

    public override void UpdateState(float deltaTime) {
        float now = Time.time;

        if (!isWandering) {
            if (now >= wanderStartTime + wanderCooldown) {
                isWandering = true;
                wanderStartTime = now;
                wanderDir = Random.insideUnitCircle.normalized;
            }
        } else {
            if (now >= wanderStartTime + wanderDuration) {
                isWandering = false;
                wanderStartTime = now;
            } else {
                _ai.MoveInDirrection(wanderDir * wanderSpeed);
                _owner.view.isLookingLeft = wanderDir.x < 0;
            }
        }

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