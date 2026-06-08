using UnityEngine;
using DG.Tweening;

public class Fall : ViewState
{
    public override void StartState() {
        _view.animator.transform.DORotate(new Vector3(0, 0, 360), 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
    }

    public override void StopState() {
        _view.animator.transform.DOKill();
        _view.animator.transform.rotation = Quaternion.identity;
    }

    public override void RefreshState(float poise) {
        if (poise > _view.poiseFallThreshold) {
            _view.SetState<Struggle>();
        }
    }

    public override int GetStateId() => 3;

    public override void FixedUpdateState() {}
}