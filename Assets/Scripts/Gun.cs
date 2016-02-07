using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

	[SerializeField] private Transform _spawnPlace;
	[SerializeField] private Bullet _bullet;

	public void Shoot()
	{
		Bullet bullet = Instantiate(_bullet);
		bullet.transform.position = _spawnPlace.position;
		bullet.Shoot();
	}

	void Update()
	{
		//CardboardHead head = Cardboard.Controller.Head;
		//RaycastHit hit;
		//bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		//SetGazedAt(isLookedAt);
		if (Cardboard.SDK.Triggered)
		{
			Shoot();
		}
	}
}
