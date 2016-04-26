using UnityEngine;
using System.Collections;

public class EnemySoundManager : MonoBehaviour {

    #region Variables
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private AudioClip Dead;

    /*public bool isWalking = false,
        isHiting = false, isDead = false, isSpawn = false;*/
    #endregion

    // Use this for initialization
    void Start () {
        audioSources = GetComponents<AudioSource>();
        Debug.Log("Start: "+audioSources + " " + audioSources[0]);
    }

    // Update is called once per frame
    void Update()
    {
       // if (!audioSources[1].isPlaying) {
         /*   if (isSpawn)
            {
                audioSources[1].Play();
            }
            if (isWalking)
            {
                audioSources[2].Play();
            }
            if (isHiting)
            {
                ///audioSources[0].Play();
            }
            if (isDead)
            {
                audioSources[3].Play();
            }*/
        //}
    }

    public void isSpawn()
    {
        Debug.Log(audioSources + " " + audioSources[0]);
        audioSources[0].Play();
        Debug.Log("isSpawn");
    }

    public void isWalking()
    {
        Debug.Log("isWalking");
        audioSources[1].Play();
    }

    public void isHitting()
    {
        audioSources[2].Play();
        Debug.Log("isHitting");
    }

    public void isDead()
    {
        AudioSource.PlayClipAtPoint(Dead, gameObject.transform.position, 0.5f);
        Debug.Log("isDead");
    }
}
