using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{

	private int _numObjects = 10;
	[SerializeField] private float _waveWait, _spawnWait, _spawnRadius;
	[SerializeField] private EnemyMove _prefab;
	[SerializeField] private Transform _player;

	void Start()
	{
		StartCoroutine(Spawner());
	}

	IEnumerator Spawner()
	{
		yield return new WaitForSeconds(_waveWait);
		Vector3 center = transform.position;
		for (int i = 0; i < _numObjects; i++)
		{
			Vector3 pos = RandomCircle(center, _spawnRadius);
			Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
			var enemy = Instantiate(_prefab, pos, Quaternion.identity) as EnemyMove;
			enemy.SetTarget(_player);
			yield return new WaitForSeconds(_spawnWait);
		}
	}

	Vector3 RandomCircle(Vector3 center, float radius)
	{
		float ang = Random.value * 360;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.y = center.y;
		pos.z = center.z + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		return pos;
	}
}
