﻿using UnityEngine;
using System.Collections;
using System;

public class Bullet : MonoBehaviour {

	public Rigidbody _rigidbody;
	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	internal void Shoot()
	{
		//_rigidbody.AddForce(Vector3.forward);
	}
}
