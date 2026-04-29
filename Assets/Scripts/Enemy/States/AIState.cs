using UnityEngine;
public abstract class AiState
{
    protected Enemy _owner;
    protected Game _game;
    public abstract void StartState();
    public abstract void StopState();
    public abstract void UpdateState();

    public void Init(Game game, Enemy owner) {
        _game = game;
        _owner = owner;
    }
}