using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerManager.Instance.IncreaseExperience(10f);
    }
}
