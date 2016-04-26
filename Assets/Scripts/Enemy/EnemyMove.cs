using UnityEngine;
using System.Collections;
using System;

public class EnemyMove : MonoBehaviour
{

    #region Variables
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform _targetPos;
    [SerializeField]
    private float _closestDistance = 0.7f;
    private Enemy enemy;
	private Vector3 distance;
    [SerializeField] private EnemySoundManager enemySounds;
    #endregion

    void Start()
    {
        enemy = GetComponent<Enemy>();
		distance = new Vector3 (_targetPos.position.x, _targetPos.position.y / 2f, _targetPos.position.z);
        enemySounds = GetComponent<EnemySoundManager>();
    }

    public void SetTarget(Transform target)
    {
        _targetPos = target;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //enemySounds.isWalking = true;
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
