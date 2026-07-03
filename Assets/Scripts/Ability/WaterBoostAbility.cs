using UnityEngine;

public class waterBoostAbility : Ability
{   
    public bool isActive = false;

    public override void Activate() {
        if (Time.time < lastActivation + channelTime + cooldown) return;
        isActive = true;
        lastActivation = Time.time;     

        _game.abilityFactory.isBoostedMassGain = true;
    }

    public override void ManualFixedUpdate() {
        if (!isActive) return;
        if (Time.time >= lastActivation + channelTime) {
            isActive = false;
            _game.abilityFactory.isBoostedMassGain = false;            
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