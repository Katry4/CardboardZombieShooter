using UnityEngine;
using System.Collections;
using System;

public class AliveComponent : MonoBehaviour {

	[SerializeField] private int _health = 100;
	
	public void RemHeath(int damage)
	{
		_health -= damage;
		if (_health<0)
		{
			Die();
		}
	}

	private void Die()
	{
		Destroy(gameObject);
	}
}
