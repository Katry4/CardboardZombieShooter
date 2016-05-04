using UnityEngine;
using System.Collections;
using System;

public class Bullet : MonoBehaviour
{

    #region
    [SerializeField]
    private float _speed = 5f;
    private Vector3 _targetPos = Vector3.zero;
    [SerializeField]
    private float _maxAliveTime = 5;
    private float _aliveTime = 0;
    #endregion

    internal void Shoot(Gun gun, Vector3? targetPos = null)
    {
        _targetPos = targetPos == null ? Vector3.zero : (Vector3)targetPos;
        transform.rotation = gun.transform.localRotation;
    }

    void Update()
    {
        if (_targetPos != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }


        _aliveTime += Time.deltaTime;
        if (_aliveTime > _maxAliveTime)
        {
            Destroy(gameObject);
        }
    }
}
