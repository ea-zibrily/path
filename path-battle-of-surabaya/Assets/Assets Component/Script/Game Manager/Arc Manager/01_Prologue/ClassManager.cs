using System;
using UnityEngine;

public class ClassManager : MonoBehaviour
{
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void Start()
    {
        _audioManager.Stop(SoundEnum.BGM_MainMenu);
        _audioManager.Play(SoundEnum.BGM_Kelas);
    }
}