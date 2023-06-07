using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
   private AudioManager _audioManager;

   private void Awake()
   {
      _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         _audioManager.Stop(SoundEnum.BGM_Museum);
         _audioManager.Play(SoundEnum.BGM_RuangManekin);
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         gameObject.GetComponent<BoxCollider2D>().enabled = false;
      }
   }
}