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
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit(Transform enemy)
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
