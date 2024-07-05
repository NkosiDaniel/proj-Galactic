using UnityEngine.Audio;
using UnityEngine;
using System.ComponentModel;
using Unity.Collections;

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;
    public bool loop;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    [Unity.Collections.ReadOnly]
    public AudioSource source;
}
