using UnityEngine;
using DG.Tweening;

public class EnemyPoise : MonoBehaviour
{  

    private Game _game;
    private Enemy _enemy;
    public float poise = 1;
    public float dragMultiplier = 1f;
    public float recoveryRate = 0.1f;
    public float damagePerSpeed = 1f;
    private int lastStateId = -1;

    public void Init(Game game, Enemy enemy) {
        _game = game;
        _enemy = enemy;
        
        _enemy.animator.SetFloat("Poise", 1f);
    }
    
    public void Update() {
        poise += recoveryRate * Time.deltaTime; 
        poise = Mathf.Clamp01(poise);
        _enemy.enemyRigidbody.linearDamping = poise * dragMultiplier;
        RefreshView();
    }

    public float GetForceMultiplier() {
        float forceMultiplier = Mathf.Lerp(0f, 1f, poise * 2f - 1f);
        forceMultiplier = Mathf.Max(0f, forceMultiplier);
        return forceMultiplier;
    }

    public void TakeDamage(float speed) {
        poise -= speed * damagePerSpeed;
        poise = Mathf.Max(0f, poise);
        RefreshView();
    }

    private void RefreshView() {
        _enemy.mainSprite.rotation = Quaternion.Euler(0, 0, (1 - poise) * 90f);

        if (!_enemy.animator.gameObject.activeSelf) return;
        
        _enemy.animator.SetFloat("Poise", poise);

        AnimatorStateInfo stateInfo = _enemy.animator.GetCurrentAnimatorStateInfo(0);
        int newState = 0;
        if (stateInfo.IsName("Goblin2")) newState = 1;
        if (stateInfo.IsName("Goblin3")) newState = 2;
        if (newState == lastStateId) return;
        lastStateId = newState;
        _enemy.animator.transform.DOKill();    
        _enemy.animator.transform.rotation = Quaternion.identity;
        if (newState == 0) {
            _enemy.animator.transform.DOLocalMoveY(0.15f, 0.3f).SetLoops(-1, LoopType.Yoyo);
        }        
        if (newState == 2) {
            _enemy.animator.transform.DORotate(new Vector3(0, 0, 360), 0.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
        }
    }
}
