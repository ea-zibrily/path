using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterEventHandler : MonoBehaviour
{
    public event Action OnTeleportEnter;
    public event Action OnFaderDone;
    
    public void TeleportEnter() => OnTeleportEnter?.Invoke();
    public void FaderDone() => OnFaderDone?.Invoke();
}
