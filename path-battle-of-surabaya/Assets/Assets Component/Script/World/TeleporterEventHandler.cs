using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterEventHandler : MonoBehaviour
{
    public event Action OnFaderDone;
    
    public void FaderDone() => OnFaderDone?.Invoke();
}
