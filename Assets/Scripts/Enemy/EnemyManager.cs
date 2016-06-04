using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{

    #region Variables
    [SerializeField]
    private Transform _player;

    private int _numObjects = 10;
    [SerializeField]
    private float _waveWait, _spawnWait, _spawnRadius;
    [SerializeField]
    private Enemy _prefab;

    private int _numObjectsDown = 5;
    [SerializeField]
    private float _waveWaitDown, _spawnWaitDown, _spawnRadiusDown;
    [SerializeField]
    private Enemy _prefabDown;

	private int _numObjectsBoss = 5;
	[SerializeField]
	private float _waveWaitBoss, _spawnWaitBoss, _spawnRadiusBoss;
	[SerializeField]
	private Enemy _prefabBoss;
    #endregion

    void Start()
    {
		StartCoroutine (SpawnerUpper ());
		StartCoroutine (SpawnerDown ());
		StartCoroutine (SpawnerBoss ());
    }

    IEnumerator SpawnerUpper()
    {
        yield return new WaitForSeconds(_waveWait);
        Vector3 center = transform.position;
        while (true)
        {
            for (int i = 0; i < _numObjects; i++)
            {
                Vector3 pos = RandomCircle(center, _spawnRadius);
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
                var enemy = Instantiate(_prefab, pos, rot) as Enemy;
                enemy.Go();
                yield return new WaitForSeconds(_spawnWait);
            }
        }
    }

    IEnumerator SpawnerDown()
    {
        yield return new WaitForSeconds(_waveWaitDown);
        Vector3 center = transform.position;
        while (true)
        {
            for (int i = 0; i < _numObjectsDown; i++)
            {
                Vector3 pos = RandomCircle(center, _spawnRadiusDown);
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
                var enemy = Instantiate(_prefabDown, pos, rot) as Enemy;
                enemy.Go();
                yield return new WaitForSeconds(_spawnWaitDown);
            }
        }
    }

	IEnumerator SpawnerBoss()
	{
		yield return new WaitForSeconds(_waveWaitBoss);
		Vector3 center = transform.position;
		while (true)
		{
			for (int i = 0; i < _numObjectsBoss; i++)
			{
				Vector3 pos = RandomCircle(center, _spawnRadiusBoss);
				Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
				var enemy = Instantiate(_prefabBoss, pos, rot) as Enemy;
				enemy.Go();
				yield return new WaitForSeconds(_spawnWaitBoss);
			}
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
