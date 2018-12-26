using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public void ToggleObject(GameObject go) { go.SetActive(!go.activeInHierarchy); }
}
