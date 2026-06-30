using UnityEngine;

public class FreezeAbility : Ability
{   
    private bool isActive = false;
    public float timescale = 0.1f;

    protected override void Activate() {
        isActive = true;
        Time.timeScale = timescale;
    }

    public override void ManualFixedUpdate() {
        if (!isActive) return;
        if (Time.time >= lastActivation + channelTime) {
            isActive = false;
            Time.timeScale = 1f;
        }
    }
}
