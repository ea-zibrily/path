using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class teleporterDummy : MonoBehaviour
{
    public GameObject onDevelopments;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onDevelopments.SetActive(true);
        }
    }
}
