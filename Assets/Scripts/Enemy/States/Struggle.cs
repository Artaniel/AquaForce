using UnityEngine;
using DG.Tweening;

public class Struggle : ViewState
{
    public override void StartState() {
        
    }

    public override void StopState() {
        
    }

    public override void RefreshState(float poise) {
        if (poise < _view.poiseFallThreshold) {
            _view.SetState<Fall>();
        } else if (poise > _view.poiseStruggleThreshold) {
            _view.SetState<Walk>();
        }
    }

    public override int GetStateId() => 2;

    public override void FixedUpdateState() {}
}