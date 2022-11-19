using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public List<AudioSource> soundPrefabs = new List<AudioSource> ();

    private Dictionary<string, SoundPool> poolDictionary = new Dictionary<string, SoundPool>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        for(int i = 0; i < soundPrefabs.Count; i++)
        {
            SoundPool _pool = new SoundPool(soundPrefabs[i], transform);
            poolDictionary.Add(soundPrefabs[i].name, _pool);
        }
    }

    public void Push(AudioSource _source)
    {
        if(poolDictionary.TryGetValue(_source.name, out SoundPool pool))
        {
            Debug.Log("push");
            pool.Push(_source);
        }
    }

    public AudioSource Pop(string name)
    {
        AudioSource _source = null;

        if (poolDictionary.TryGetValue(name, out SoundPool pool))
        {
            _source = pool.Pop();
        }

        return _source;
    }
}
