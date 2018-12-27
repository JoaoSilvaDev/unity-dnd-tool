using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    public Image image;
    private string currentSpriteName = " ";

    public void SetImage(string input)
    {
        Sprite sprite  = Resources.Load<Sprite>("Gallery/" + input);

        if (input == currentSpriteName)
        {
            currentSpriteName = "";
            HideImage();
        }
        else
        {
            image.sprite = sprite;
            currentSpriteName = input;
            ShowImage();
        }
    }

    public void ShowImage() { image.enabled = true; }
    public void HideImage() { image.enabled = false; currentSpriteName = ""; }
}
 