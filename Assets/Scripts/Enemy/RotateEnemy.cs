using UnityEngine;
using System.Collections;

public class RotateEnemy : MonoBehaviour
{

    [SerializeField]
    private Vector3 _rotation;
    // Use this for initialization
    void Start()
    {
        gameObject.transform.Rotate(_rotation, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
