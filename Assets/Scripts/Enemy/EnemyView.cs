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
    public SpriteRenderer mainSprite;
    public float poiseFallThreshold = 0.1f;
    public float poiseStruggleThreshold = 0.5f;
    public bool isLookingLeft = false;

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
        SetState<Stand>();
    }

    public void SetState<T>() where T : ViewState {
        if (currentState?.GetType() == typeof(T)) return;
        currentState?.StopState();
        currentState = states[typeof(T)];
        currentState.StartState();
    }

    public void ManualFixedUpdate(float deltaTime) {
        currentState?.FixedUpdateState(deltaTime);
    }

    public void ManualUpdate(float deltaTime) {
        currentState?.UpdateState(deltaTime);                
        transform.localScale = new Vector3(
            isLookingLeft ? -1 : 1, 
            1,
            1);
    }

    public void Refresh(float poise) {
        currentState.RefreshState(poise);
        if (!animator.gameObject.activeSelf) {    
            _enemy.view.mainSprite.transform.rotation = Quaternion.Euler(0, 0, (1 - poise) * 90f);  
            return;
        }
        animator.SetInteger("StateId", currentState.GetStateId());  
    }

    private void OnDestroy() {
        animator.transform.DOKill();
        currentState = null;
    }

    public bool IsWalkableAIState(){
        return _enemy.ai.currentState is MoveToGem or MoveToSpawn;
    }

    public void HitVfx() {        
        mainSprite.DOColor(Color.red, 0.1f).SetLoops(2, LoopType.Yoyo);
    }
}
