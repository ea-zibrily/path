using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoSingleton<ObjectManager>
{
    public List<GameObject> objectList;
    
    public void SetObjectActive(int index) => objectList[index].SetActive(true);
}