using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

    [SerializeField] private AudioClip _clip;

    // Use this for initialization
    void Start () {
        Time.timeScale = 0.00000000001f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        AudioSource.PlayClipAtPoint(_clip, new Vector3(0f, 0f, 0f), 1f);
        Time.timeScale = 1f;
        GetComponentInParent<Canvas>().gameObject.SetActive(false);
        Gun.isPlaying = true;
    }
}
