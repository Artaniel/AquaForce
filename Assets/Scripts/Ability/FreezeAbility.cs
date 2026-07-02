using UnityEngine;

public class FreezeAbility : Ability
{   
    public bool isActive = false;
    public float timescale = 0.1f;

    public override void Activate() {
        if (Time.time < lastActivation + channelTime + cooldown) return;
        isActive = true;
        _game.enemyFactory.enemyTimescale = timescale;    
        lastActivation = Time.time;     
    }

    public override void ManualFixedUpdate() {
        if (!isActive) return;
        if (Time.time >= lastActivation + channelTime) {
            isActive = false;
            _game.enemyFactory.enemyTimescale = 1f;
        }
    }

    public override float GetProgress() {
        if (Time.time < lastActivation + channelTime) {
            return (Time.time - lastActivation) / channelTime;
        } else if (Time.time < lastActivation + channelTime + cooldown) {
            return 1f - (Time.time - (lastActivation + channelTime)) / cooldown;
        }
        return 0f;
    }
}
