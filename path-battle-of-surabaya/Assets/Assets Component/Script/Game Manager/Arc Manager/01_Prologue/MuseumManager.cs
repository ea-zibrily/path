using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumManager : MonoBehaviour
{
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void Start()
    {
        _audioManager.Stop(SoundEnum.BGM_Bus);
        _audioManager.Play(SoundEnum.BGM_Museum);
    }
    
}
