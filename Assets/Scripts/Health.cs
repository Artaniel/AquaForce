using UnityEngine;

public class Health : MonoBehaviour
{
	private IHealthy _owner;

	public float maxHP = 100f;
	public float HP = 100f;
	public float cooldown = 0.3f;
	private float lastDamageTime = - Mathf.Infinity;

	public bool isImmune = false;
	public bool isDead = false;

	public SpriteRenderer[] healthIndecators;

	public Color healthyIndicatorColor = Color.green;
	public Color damagedIndicatorColor = Color.red;

	public void Init(IHealthy owner) {
		_owner = owner;
		RefreshHpCounter();
	}

	public virtual void Damage(float value) {
		if (isImmune || isDead) return;
		if (Time.time < lastDamageTime + cooldown) return;
		HP = Mathf.Clamp(HP - value, 0, maxHP);
		lastDamageTime = Time.time;
		if (HP <= 0)
			Death();
		else
			_owner.NonLetalDamage();
		RefreshHpCounter();
	}

	public void Kill() {
		if (isImmune || isDead) return;
		HP = 0;
		lastDamageTime = Time.time;
		Death();
		RefreshHpCounter();        
    }

	private void Death() {
		isDead = true;
		_owner.Death();
	}

	public void Resurrect() {
		isDead = false;
		HP = maxHP;
		RefreshHpCounter();
	}

	public void ChangeHP(float value) {
		if (isDead) return;
		HP = Mathf.Clamp(HP + value, 0, maxHP);
		if (HP <= 0)
			Death();
		RefreshHpCounter();
	}

	public void RefreshHpCounter() {
		for (int i = 0; i < maxHP; i++) {
            healthIndecators[i].color = HP > i? healthyIndicatorColor : damagedIndicatorColor;
        }
	}
}

public interface IHealthy
{
	public void NonLetalDamage();
	public void Death();
}