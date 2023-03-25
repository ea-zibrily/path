using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningArcAnimationHandler : MonoBehaviour
{
    public event Action OnOpeningEnd;

    public void OpeningEnd()
    {
        OnOpeningEnd?.Invoke();
    } 
    
}
