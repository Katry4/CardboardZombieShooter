using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class AliveComponent : MonoBehaviour
{

	[SerializeField] private int _maxHealth = 100;
	private int _health;
	private int targetHealth;

	void Start()
	{
		targetHealth = _health = _maxHealth;
	}

	public void RemHeath(int damage)
	{
		targetHealth -= damage;
		if (targetHealth < 0)
		{
			Die();
		}
	}

	void Update()
	{
		if (targetHealth < _health)
		{
			_health--;
		}
	}

	private void Die()
	{
		if (gameObject.tag != "Player")
		{
			Destroy(gameObject);
		}
		else
		{
			Debug.Log("GAME OVER!");
			SceneManager.LoadScene("GameScene");
		}
	}

	public float HealthInPercent()
	{
		return (float)_health / _maxHealth;
	}
}
