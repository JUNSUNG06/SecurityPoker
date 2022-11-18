using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPool
{
    private Stack<AudioSource> pool;
    private AudioSource sourcePrefab;

    public SoundPool(AudioSource _source)
    {
        sourcePrefab = _source;
        pool = new Stack<AudioSource>();

        for(int i = 0; i < 10; i++)
        {
            AudioSource source = GameObject.Instantiate(sourcePrefab) as AudioSource;
            pool.Push(source);
        }
    }

    public void Push(AudioSource _source)
    {
        _source.Pause();
        _source.gameObject.SetActive(false);
        pool.Push(_source);
    }

    public AudioSource Pop()
    {
        AudioSource _source = null;

        if (pool.Count <= 0)
        {
            _source = GameObject.Instantiate(sourcePrefab) as AudioSource;
            _source.gameObject.SetActive(false);
            pool.Push(_source);
        }

        _source = pool.Pop();
        _source.gameObject.SetActive(true);
        _source.Play();

        return _source;
    }
}
