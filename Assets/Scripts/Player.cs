using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

	[SerializeField] private AliveComponent _alive;
    [SerializeField] private ManagerAngle manager;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	internal void Hit(int damage, Transform enemyTransform)
	{
		_alive.RemHeath(damage);
        manager.Hit(enemyTransform);
	}
}
