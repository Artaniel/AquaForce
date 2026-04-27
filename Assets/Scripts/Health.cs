using UnityEngine;

public class Health : MonoBehaviour
{
	private IHealthy _owner;

	public float maxHP = 100f;
	public float HP = 100f;

	public bool isImmune = false;
	public bool isDead = false;

	public SpriteRenderer[] healthIndecators;

	public void Init(IHealthy owner) {
		_owner = owner;
	}

	public virtual void Damage(float value) {
		if (isImmune || isDead) return;
		HP = Mathf.Clamp(HP - value, 0, maxHP);
		if (HP <= 0)
			Death();
		else
			_owner.NonLetalDamage();
		RefreshHpCounter();
	}

	public void Death() {
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
		else
			_owner.NonLetalDamage();
		RefreshHpCounter();
	}

	public void RefreshHpCounter() {
	}
}

public interface IHealthy
{
	public void NonLetalDamage();
	public void Death();
	public void Heal();
}