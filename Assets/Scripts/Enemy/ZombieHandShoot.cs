using UnityEngine;
using System.Collections;

public class ZombieHandShoot : MonoBehaviour {

	[SerializeField] private float _speed;
	[SerializeField] private Player _player;

	// Use this for initialization
	void Awake()
	{
		_player = FindObjectOfType<GameController>().Player;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (gameObject.transform.position, 
			_player.transform.position, _speed * Time.deltaTime);
	}
}
