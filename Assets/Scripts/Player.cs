using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

	[SerializeField] private AliveComponent _alive;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	internal void Hit(int damage)
	{
		_alive.RemHeath(damage);
	}
}
