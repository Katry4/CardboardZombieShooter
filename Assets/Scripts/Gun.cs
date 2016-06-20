using UnityEngine;
using System.Collections;
using System;

public class Gun : MonoBehaviour
{

	[SerializeField] private Transform _spawnPlace;
	[SerializeField] private Bullet _bullet;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator gunAnimator;
    public static bool isPlaying;
	[SerializeField] private GameController gameController;

    void Update()
	{
		if (Cardboard.SDK.Triggered)
		{
			CardboardHead head = Cardboard.Controller.Head;
			RaycastHit hit;
			bool isLookedAt = Physics.Raycast(head.Gaze, out hit, Mathf.Infinity);
			if (isLookedAt)
			{
				Shoot(hit.point);
			}
			else
			{
				Shoot();
			}
		}
	}

	private void Shoot(Vector3? targetPos = null)
	{
		if (isPlaying && gameController.isShootActive)
        {
            Bullet bullet = Instantiate(_bullet, _spawnPlace.position, _spawnPlace.rotation) as Bullet;
            bullet.Shoot(this, targetPos);
            audioSource.PlayOneShot(audioClip);
            gunAnimator.SetBool("isShoot", true);
            gameController.DegreaseAmmo ();
        }
    }
}
