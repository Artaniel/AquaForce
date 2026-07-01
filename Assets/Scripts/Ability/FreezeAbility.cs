using UnityEngine;

public class FreezeAbility : Ability
{   
    public bool isActive = false;
    public float timescale = 0.1f;

    public override void Activate() {
        isActive = true;
        _game.enemyFactory.enemyTimescale = timescale;        
    }

    public override void ManualFixedUpdate() {
        if (!isActive) return;
        if (Time.time >= lastActivation + channelTime) {
            isActive = false;
            _game.enemyFactory.enemyTimescale = 1f;
        }
    }
}
