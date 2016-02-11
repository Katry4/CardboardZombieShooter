using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    public float speed;
    public Transform targetPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed*Time.deltaTime);
	}
}
