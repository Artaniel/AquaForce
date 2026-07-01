using UnityEngine;

public abstract class AiState
{
    protected Enemy _owner;
    protected Game _game;
    protected EnemyAI _ai;
    public abstract void StartState();
    public abstract void StopState();
    public abstract void UpdateState(float deltaTime);

    public void Init(Game game, Enemy owner) {
        _game = game;
        _owner = owner;
        _ai = _owner.ai;
    }
}