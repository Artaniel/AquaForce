using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System;

public class EnemyView : MonoBehaviour
{  
    private Game _game;
    private Enemy _enemy;
    public Dictionary<Type, ViewState> states;
    public ViewState currentState;
    public Animator animator;
    public float poiseFallThreshold = 0.1f;
    public float poiseStruggleThreshold = 0.5f;

    public void Init(Game game, Enemy enemy) {
        _game = game;
        _enemy = enemy;
        states = new Dictionary<Type, ViewState> {
            { typeof(Stand), new Stand() },
            { typeof(Walk), new Walk() },
            { typeof(Fall), new Fall() },
            { typeof(Struggle), new Struggle() }
        };
        foreach (ViewState state in states.Values) {
            state.Init(game, enemy);
        }
        SetState<Walk>();
    }

    public void SetState<T>() where T : ViewState {
        if (currentState?.GetType() == typeof(T)) return;
        currentState?.StopState();
        currentState = states[typeof(T)];
        currentState.StartState();
    }

    public void Refresh(float poise) {
        Debug.Log($"EnemyView.Refresh: {poise}");
        if (!animator.gameObject.activeSelf) return;
        animator.SetInteger("StateId", currentState.GetStateId());        
        currentState.RefreshState(poise);
    }

    private void OnDestroy() {
        animator.transform.DOKill();
    }
}
