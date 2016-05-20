using UnityEngine;
using System.Collections;
using System;

public class EnemyMove : MonoBehaviour
{

    #region Variables
    [SerializeField] public float _speed;
    [SerializeField] private Transform _targetPos;
    [SerializeField] private float _closestDistance = 0.7f;
    private Enemy enemy;
    Vector3 distance;
    [SerializeField] private EnemySoundManager enemySounds;
    #endregion

    void Start()
    {
        _speed = 1f;
        enemy = GetComponent<Enemy>();
        enemySounds = GetComponent<EnemySoundManager>();
        distance = new Vector3(_targetPos.position.x, _targetPos.position.y - 1f, _targetPos.position.z);
    }

    public void SetTarget(Transform target)
    {
        _targetPos = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isMove)
            Move();
    }

    void Move()
    {
        float dist = Vector3.Distance(_targetPos.position, transform.position);
        if (dist > _closestDistance)
        {
            //anim move
            transform.position = Vector3.MoveTowards(transform.position, distance, _speed * Time.deltaTime);
        }
        else
        {
            enemy.IsHit();
            enemySounds.audioSources[1].Stop();
        }
    }
}
