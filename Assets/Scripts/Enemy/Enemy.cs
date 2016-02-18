using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour
{
	[SerializeField] Player player;
	[SerializeField] private int _damage = 3;
	[SerializeField] private float _recharge = 2f;
	private float timeSinceLastHit = 100;

	void Awake()
	{
		player = FindObjectOfType<GameController>().Player;
	}


	internal void Go()
	{
		GetComponent<EnemyMove>().SetTarget(player.transform);
	}

	void Update()
	{
		timeSinceLastHit += Time.deltaTime;
	}

	public void OnTriggerStay(Collider other)
	{
		Debug.Log(other.name + " " + other.gameObject.tag);
		if (other.tag == "Bullet")
		{
			Destroy(gameObject);
			Destroy(other.gameObject);
		}
		else if (other.tag == "Player")
		{
			//other.GetComponent<Player>().Hit(_damage);
		}
	}

	internal void HitPlayer()
	{
		if (timeSinceLastHit > _recharge)
		{
			player.Hit(_damage);
			timeSinceLastHit = 0;
		}
	}
}
