using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class RotateImage : MonoBehaviour
{

    public GameObject player, enemy;
    public Enemy enemyScript;
    private float _angle;
    [SerializeField] private Sprite[] sprites;

    // Use this for initialization
    void Start()
    {
        GetComponent<Image>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];
        StartCoroutine(FadeImage());
        enemyScript = enemy.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.isAlive)
        {
            _angle = GetAngleToObject(player, enemy);
            transform.rotation = Quaternion.Euler(player.transform.eulerAngles.x, player.transform.eulerAngles.y, _angle);
        }
        if (AliveComponent.isDead)
        {
            Destroy(gameObject);
        }
    }

    public void SetTransformEnemy(GameObject _enemy)
    {
        enemy = _enemy;
    }

    IEnumerator FadeIn(float timer)
    {
        Color temp = new Color();
        while (GetComponent<Image>().color.a < 1f)
        {
            temp = GetComponent<Image>().color;
            temp.a += Time.deltaTime / timer;
            GetComponent<Image>().color = temp;
            yield return null;
        }
        GetComponent<Image>().color = temp;
    }

    IEnumerator FadeOut(float timer)
    {
        Color temp = new Color();
        while (GetComponent<Image>().color.a > 0f)
        {
            temp = GetComponent<Image>().color;
            temp.a -= Time.deltaTime / timer;
            GetComponent<Image>().color = temp;
            yield return null;
        }
        GetComponent<Image>().color = temp;
    }

    IEnumerator FadeImage()
    {
        StartCoroutine(FadeIn(0.1f));
        yield return new WaitForSeconds(1f);
        StartCoroutine(FadeOut(0.1f));
    }


    float GetAngleToObject(GameObject startingObject, GameObject targetObject)
    {
        return GetAngleToObject(startingObject.transform, targetObject.transform.position);
    }

    float GetAngleToObject(Transform startTransform, Vector3 targetPosition)
    {
        Vector3 targetPos = new Vector3(targetPosition.x, targetPosition.y + 1, targetPosition.z);
        Vector3 vectorToTarget = targetPos - startTransform.position;

        float angleToTarget = Vector3.Angle(startTransform.forward, vectorToTarget);
        int direction = AngleDir(startTransform.forward, vectorToTarget, startTransform.up);

        return (direction == 1) ? 360f - angleToTarget : angleToTarget;
    }

    int AngleDir(Vector3 forwardVector, Vector3 targetDirection, Vector3 upVector)
    {
        float direction = Vector3.Dot(Vector3.Cross(forwardVector, targetDirection), upVector);

        if (direction > 0f)
        {
            return 1;
        }
        else if (direction < 0f)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
