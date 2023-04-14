using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public float regenTimer;
    public bool isAttack;
    public bool isStartTimer;
    
    private void Update()
    {
        if (!isAttack)
        {
            if (!isStartTimer)
            {
                isStartTimer = true;
                regenTimer = 0.0f;
            }
            else
            {
                regenTimer += Time.deltaTime;
                if (regenTimer >= 0.5f)
                {
                    PlayerManager.Instance.IncreaseHealth();
                    isStartTimer = false;
                    regenTimer = 0.0f;
                }
            }
        }
        else
        {
            isStartTimer = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerManager.Instance.DecreaseHealth(1.5f);
    }
}
