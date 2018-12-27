using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public void ToggleObject(GameObject go) { go.SetActive(!go.activeInHierarchy); }

    public void DeactivateObject(GameObject go) { go.SetActive(false); }

    public void ActivateObject(GameObject go) { go.SetActive(true); }

    public void ButtonColorOn(GameObject go)
    {
        go.GetComponent<Image>().color = Color.black;
        go.transform.GetChild(0).GetComponent<Text>().color = Color.white;
    }

    public void ButtonColorOff(GameObject go)
    {
        go.GetComponent<Image>().color = Color.white;
        go.transform.GetChild(0).GetComponent<Text>().color = Color.black;
    }
}
