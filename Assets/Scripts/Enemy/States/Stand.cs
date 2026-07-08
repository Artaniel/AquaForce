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
            _owner.sound.Struggle();            
            _owner.ai.DropGem();
        }
    }

    public override int GetStateId() => 0;

    public override void FixedUpdateState(float deltaTime) {
        if (_view.IsWalkableAIState()) {
            _view.SetState<Walk>();
        }
    }
}