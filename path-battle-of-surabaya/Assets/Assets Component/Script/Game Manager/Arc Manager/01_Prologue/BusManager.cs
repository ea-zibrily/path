using System;
using UnityEngine;

public class BusManager : MonoBehaviour
{
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    
    private void Start()
    {
        _audioManager.Stop(SoundEnum.BGM_Kelas);
        _audioManager.Play(SoundEnum.BGM_Bus);
        
        // FindObjectOfType<AudioManager>().Stop(SoundEnum.BGM_Kelas);
        // FindObjectOfType<AudioManager>().Play(SoundEnum.BGM_Bus);
    }
}