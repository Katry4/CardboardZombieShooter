using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManagerAngle : MonoBehaviour
{

    [SerializeField]
    private Transform player;
    public static float angle;
    [SerializeField]
    private GameObject image;
    public RotateImage rotateImage;

    public void Hit(GameObject enemy)
    {
        rotateImage.SetTransformEnemy(enemy);
        AddImage();
    }

    void AddImage()
    {
        GameObject childObject = Instantiate(image) as GameObject;
        childObject.transform.SetParent(gameObject.transform, false);
        childObject.SetActive(true);
        Destroy(childObject, 1.2f);
    }
}
