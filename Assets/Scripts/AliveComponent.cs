using UnityEngine;
using System.Collections;
using System;

public class AliveComponent : MonoBehaviour
{

	[SerializeField] private int _maxHealth = 100;
	public int _health;

	void Start()
	{
		_health = _maxHealth;
	}

	public void RemHeath(int damage)
	{
		_health -= damage;
		if (_health < 0)
		{
			Die();
		}
	}

	private void Die()
	{
		Destroy(gameObject);
	}

	public float HealthInPercent()
	{
		return (float)_health / _maxHealth;
	}
}
