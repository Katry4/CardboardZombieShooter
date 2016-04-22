﻿using UnityEngine;
using System.Collections;
using System;

public class EnemyMove : MonoBehaviour
{

    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform _targetPos;
    [SerializeField]
    private float _closestDistance = 0.7f;
    private Enemy enemy;
	private Vector3 distance;

    void Start()
    {
        enemy = GetComponent<Enemy>();
		distance = new Vector3 (_targetPos.position.x, _targetPos.position.y / 2f, _targetPos.position.z);
    }

    public void SetTarget(Transform target)
    {
        _targetPos = target;
        Debug.Log(_targetPos.position);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
		float dist = Vector3.Distance(distance, transform.position);
        if (dist > _closestDistance)
        {
            //anim move
			transform.position = Vector3.MoveTowards(transform.position, distance, _speed * Time.deltaTime);
        }
        else
        {
            enemy.HitPlayer();
            //anim hit
        }
    }

}
