using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    public static CameraShake Instance;

    private float _amplitude = 0.1f;

    private Vector3 initialPosition;
    private bool isShaking = false;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        initialPosition = transform.position;
    }

    public void Shake(float amplitude, float duration)
    {
        _amplitude = amplitude;
        isShaking = true;
        CancelInvoke();
        Invoke("StopShaking", duration);
    }

    public void StopShaking()
    {
        isShaking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            /*transform.localPosition = new Vector3(initialPosition.x + Random.insideUnitSphere.x * _amplitude,
                0f, initialPosition.z + Random.insideUnitSphere.z * _amplitude);*/
            iTween.ShakeRotation(gameObject, new Vector3(1, 1, 1), 0.1f);
            
        }
        if (AliveComponent.isDead)
        {
            /*CancelInvoke();
            Invoke("StopShaking", 0.00000000001f);*/
            iTween.Stop();
        }
    }
}