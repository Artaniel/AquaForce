using UnityEngine;
using System.Collections.Generic;
using System;

public class EnemyAI : MonoBehaviour
{   
    private Game _game;
    private Enemy _enemy;

    public UnityEngine.AI.NavMeshAgent agent;
    public Gem targetGem;
    public Dictionary<Type, AiState> states;
    private AiState currentState;

    public void Init(Game game, Enemy enemy) {
        _game = game;
        _enemy = enemy;
        
        states = new Dictionary<Type, AiState> {
            { typeof(Idle), new Idle() },
            { typeof(MoveToGem), new MoveToGem() },
            { typeof(MoveToSpawn), new MoveToSpawn() },
            { typeof(Dead), new Dead() }
        };
        
        foreach (AiState state in states.Values) {
            state.Init(game, _enemy);
        }
    }

    public void SetState<T>() where T : AiState {
        AiState state = states[typeof(T)];
        currentState?.StopState();
        state.StartState();
        currentState = state;
    }
    
}
