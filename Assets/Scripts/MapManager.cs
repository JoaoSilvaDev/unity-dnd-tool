using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public GameObject dmScreen;
    public GameObject playerScreen;

    public GameObject dmMapParent;
    public GameObject playerMapParent;

    public GameObject dmMap;
    public GameObject playerMap;

    public List<Button> dmMapCovers = new List<Button>();
    public List<Button> playerMapCovers = new List<Button>();

    private MainManager mainManager;

    private void Awake()
    {
        mainManager = GetComponent<MainManager>();
    }

    private void DetectMapCovers()
    {
        Debug.Log(dmMap.transform.childCount); 
        for (int i = 0; i < dmMap.transform.childCount; i++)
        {
            Button button = dmMap.transform.GetChild(i).GetComponent<Button>();
            button.onClick.AddListener(delegate { RemoveCover(button.gameObject); });

            dmMapCovers.Add(button);
        }
    }

    private void CreateCoversOnPlayerMap()
    {
        playerMap = Instantiate(dmMap, playerMapParent.transform) as GameObject;
        playerMap.name = "Player Map";

        for (int i = 0; i < playerMap.transform.childCount; i++)
        {
            playerMapCovers.Add(playerMap.transform.GetChild(i).GetComponent<Button>());

            ColorBlock buttonColors = playerMapCovers[i].colors;
            buttonColors.normalColor = Color.black;

            playerMapCovers[i].colors = buttonColors;
        }
    }

    public void RemoveCover(GameObject gameObject)
    {
        int index = gameObject.transform.GetSiblingIndex();
        mainManager.ToggleObject(playerMapCovers[index].gameObject);
    }

    public void NewMap(GameObject map)
    {
        dmMap = Instantiate(map, dmMapParent.transform) as GameObject;
        DetectMapCovers();
        CreateCoversOnPlayerMap();
    }
}
