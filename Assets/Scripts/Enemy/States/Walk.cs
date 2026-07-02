using UnityEngine;
using DG.Tweening;

public class Walk : ViewState
{
    private Tween shakeTween;

    public override void StartState() {
        shakeTween = _view.animator.transform.DOLocalMoveY(0.15f, 0.3f).SetLoops(-1, LoopType.Yoyo).SetUpdate(UpdateType.Manual);        
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

    public override void UpdateState(float deltaTime) {
        Debug.Log($"UpdateState {deltaTime})");
        shakeTween.ManualUpdate(deltaTime, deltaTime);
    }
}