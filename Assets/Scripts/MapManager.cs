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
    private string currentMapName = "";

    private void Awake()
    {
        mainManager = GetComponent<MainManager>();
    }

    private void DetectMapCovers()
    {
        dmMapCovers.Clear();

        print(dmMap.transform.childCount);
        for (int i = 0; i < dmMap.transform.childCount; i++)
        {
            Button button = dmMap.transform.GetChild(i).GetComponent<Button>();
            button.onClick.AddListener(delegate { RemoveCover(button.gameObject); });

            ColorBlock buttonColors = button.colors;
            buttonColors.normalColor = new Color(0, 0, 0, .85f);
            buttonColors.highlightedColor = new Color(0, 0, 0, 0.7f);
            buttonColors.pressedColor = new Color(0, 0, 0, 0.6f);
            button.colors = buttonColors;

            print(button.colors.normalColor);

            dmMapCovers.Add(button);
        }
    }

    private void CreateCoversOnPlayerMap()
    {
        if (playerMapParent.transform.childCount > 0)
        {
            Destroy(playerMap);
            playerMap = Instantiate(dmMap, playerMapParent.transform) as GameObject;
        }
        else
        {
            playerMap = Instantiate(dmMap, playerMapParent.transform) as GameObject;
        }

        playerMapCovers.Clear();


        for (int i = 0; i < playerMap.transform.childCount; i++)
        {
            Button button = playerMap.transform.GetChild(i).GetComponent<Button>();

            ColorBlock buttonColors = button.colors;
            buttonColors.normalColor = new Color(0, 0, 0, 1f);
            buttonColors.highlightedColor = new Color(0, 0, 0, 1f);
            buttonColors.pressedColor = new Color(0, 0, 0, 1f);
            button.colors = buttonColors;

            playerMapCovers.Add(button);
        }
    }

    public void RemoveCover(GameObject gameObject)
    {
        int index = gameObject.transform.GetSiblingIndex();
        mainManager.ToggleObject(playerMapCovers[index].gameObject);
    }

    public void LoadMap(string input)
    {
        GameObject map = Resources.Load<GameObject>("Maps/" + input);

        if(dmMapParent.transform.childCount > 0)
        {
            RemoveMap();
            dmMap = Instantiate(map, dmMapParent.transform) as GameObject;
        }
        else
        {
            dmMap = Instantiate(map, dmMapParent.transform) as GameObject;
        }

        dmMap.name = "DM Map";

        DetectMapCovers();
        CreateCoversOnPlayerMap();
    }

    public void RemoveMap()
    {
        if(dmMap)
            Destroy(dmMap);
        if(playerMap)
            Destroy(playerMap);
    }
}
