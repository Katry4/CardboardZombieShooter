using UnityEngine;
using System.Collections;
using System;

public class EnemyMove : MonoBehaviour
{

	[SerializeField] private float _speed;
	[SerializeField] private Transform _targetPos;
	[SerializeField] private float _closestDistance = 0.7f;
	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();
	}

	public void SetTarget(Transform target)
	{
		_targetPos = target;
	}

	// Update is called once per frame
	void Update()
	{
		/*if (_targetPos != null)
			transform.position = Vector3.MoveTowards(transform.position, _targetPos.position, _speed * Time.deltaTime);*/
		Move();
	}

	void Move()
	{
		float dist = Vector3.Distance(_targetPos.position, transform.position);
		if (dist > _closestDistance)
		{
			transform.position = Vector3.MoveTowards(transform.position, _targetPos.position, _speed * Time.deltaTime);
		}
		else
		{
			enemy.HitPlayer();
		}
	}

}
