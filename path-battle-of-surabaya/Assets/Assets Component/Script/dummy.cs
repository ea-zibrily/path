using System;
using UnityEngine;

namespace Tsukuyomi.Assets_Component.Script
{
    public class dummy : MonoBehaviour
    {
        
        public GameObject[] objTaskList;
        public int counto;

        private void OnTriggerEnter2D(Collider2D col)
        {
            for (int i = 0; i < objTaskList.Length; i++)
            {
                if (col.gameObject == objTaskList[i])
                {
                    Debug.Log("task");
                    counto++;
                    col.gameObject.GetComponentInChildren<Collider2D>().enabled = false;
                    if (counto >= objTaskList.Length)
                    {
                        Debug.Log("completed");
                    }
                }
            }
            // if (col.gameObject.CompareTag("Item"))
            // {
            //     Debug.Log("item");
            //     col.gameObject.GetComponentInChildren<Collider2D>().enabled = false;
            //     
            // }
        }
    }
}