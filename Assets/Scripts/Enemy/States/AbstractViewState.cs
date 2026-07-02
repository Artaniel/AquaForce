using UnityEngine;

public abstract class ViewState
{
    protected Enemy _owner;
    protected Game _game;
    protected EnemyView _view;
    public abstract void StartState();
    public abstract void StopState();
    public abstract void RefreshState(float poise);
    public abstract void FixedUpdateState(float deltaTime);
    public virtual void UpdateState(float deltaTime){}
    public abstract int GetStateId();

    public void Init(Game game, Enemy owner) {
        _game = game;
        _owner = owner;
        _view = _owner.view;
    }
}