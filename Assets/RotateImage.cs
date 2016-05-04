using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class RotateImage : MonoBehaviour
{

    public Transform player, enemy, plane;
    private float _angle;
    float dirNum;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FadeImage());
    }

    // Update is called once per frame
    void Update()
    {
        _angle = AngleSigned(enemy.position, player.position, new Vector3(0f, 30f, 0f));
        /*dirNum = AngleDir(player.forward, enemy.position, player.up);
        if (dirNum > 0)
        {
            _angle = AngleSigned(enemy.position, player.position, new Vector3(0f, 30f, 0f));
        }
        else if (dirNum < 0)
        {
            _angle = 360 - AngleSigned(enemy.position, player.position, new Vector3(0f, 30f, 0f));
        }*/
        transform.rotation = Quaternion.Euler(player.transform.eulerAngles.x, player.transform.eulerAngles.y, _angle);
    }

    public float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
    {
        return Mathf.Atan2(
            Vector3.Dot(n, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
    }

    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        return dir;
    }

    public void SetTransformEnemy(Transform _enemy)
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
}
