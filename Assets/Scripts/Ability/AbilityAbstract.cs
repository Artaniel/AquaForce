using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    protected Game _game;

    public int maxCharges = 1;
    public float channelTime = 1f;
    public float cooldown = 0f;

    public int charges = 0;

    protected float lastActivation;

    public void Init(Game game) {
        _game = game;
    }

    public void TryActivate() {
        //_game.ui.hud.abilityUi.RefreshOne(this);
        if (charges <= 0) return;
        if (Time.time < lastActivation + cooldown) return;
        charges--;
        lastActivation = Time.time;
        Activate();
    }

    protected abstract void Activate();

    public abstract void ManualFixedUpdate();

    public virtual void Reset() {
        charges = 0;
        lastActivation = 0f;
    }
}
