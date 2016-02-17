using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{

	[SerializeField] private float _speed;
	[SerializeField] private Transform _targetPos;


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
        if (dist>0.7)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos.position, _speed * Time.deltaTime);
        }
        else
        {

        }
    }
}
