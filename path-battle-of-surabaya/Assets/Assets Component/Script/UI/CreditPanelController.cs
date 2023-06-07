using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPanelController : MonoBehaviour
{
    private Animator myAnim;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<AudioManager>().Play(SoundEnum.SFX_Clicked);
            myAnim.SetTrigger("Close");
            StartCoroutine(CloseCreditPanel());
        }
    }
    
    private IEnumerator CloseCreditPanel()
    {
        yield return new WaitForSeconds(0.30f);
        gameObject.SetActive(false);
    }
}