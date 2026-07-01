using UnityEngine;
using DG.Tweening;

public class Walk : ViewState
{
    public override void StartState() {
        _view.animator.transform.DOLocalMoveY(0.15f, 0.3f).SetLoops(-1, LoopType.Yoyo);        
    }

    public override void StopState() {
        _view.animator.transform.DOKill();
    }

    public override void RefreshState(float poise) {
        if (poise < _view.poiseStruggleThreshold) {
            _view.SetState<Struggle>();
        }
    }

    public override int GetStateId() => 1;

    public override void FixedUpdateState(float deltaTime) {
        if (!_view.IsWalkableAIState()) {
            _view.SetState<Stand>();
        }
    }
}