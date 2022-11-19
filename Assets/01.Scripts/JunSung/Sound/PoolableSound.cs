using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableSound : MonoBehaviour
{
    AudioSource audios;

    private void OnEnable()
    {
        transform.position = Vector3.zero;
        audios = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.Log(audios.isPlaying);

        if(!audios.isPlaying)
        {
            SoundManager.Instance.Push(this.audios);
        }
    }
}
