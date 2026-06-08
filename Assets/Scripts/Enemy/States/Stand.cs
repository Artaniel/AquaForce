using UnityEngine;
using DG.Tweening;

public class Stand : ViewState
{
    public override void StartState() {
        
    }

    public override void StopState() {
        
    }

    public override void RefreshState(float poise) {
        if (poise < _view.poiseStruggleThreshold) {
            _view.SetState<Struggle>();
        }
    }

    public override int GetStateId() => 0;

    public override void FixedUpdateState() {
        if (_view.IsWalkableAIState()) {
            _view.SetState<Walk>();
        }
    }
}