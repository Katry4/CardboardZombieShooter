using UnityEngine;
using System.Collections;
using System;

public class Gun : MonoBehaviour
{

	[SerializeField] private Transform _spawnPlace;
	[SerializeField] private Bullet _bullet;

	void Update()
	{
		if (Cardboard.SDK.Triggered)
		{
			CardboardHead head = Cardboard.Controller.Head;
			RaycastHit hit;
			bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
			if (isLookedAt)
			{
				Shoot(hit.point);
			}
			else
			{
				Shoot();
			}
		}
		//SetGazedAt(isLookedAt);
	}

	public void Shoot()
	{
		Bullet bullet = Instantiate(_bullet, _spawnPlace.position, _spawnPlace.rotation) as Bullet;
		bullet.Shoot(this);
	}

	private void Shoot(Vector3 targetPos)
	{
		//Quaternion rotation = Quaternion.
		Bullet bullet = Instantiate(_bullet, _spawnPlace.position, _spawnPlace.rotation) as Bullet;
		bullet.Shoot(this, targetPos);
	}
}
