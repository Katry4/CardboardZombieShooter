using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public int numObjects = 10;
    public float waveWait, spawnWait, spawnRadius;
    public GameObject prefab;

    void Start()
    {
        StartCoroutine(Spawner());
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

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(waveWait);
        Vector3 center = transform.position;
        for (int i = 0; i < numObjects; i++)
        {
            Vector3 pos = RandomCircle(center, spawnRadius);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(prefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
