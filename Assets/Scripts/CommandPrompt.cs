using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CommandPrompt : MonoBehaviour
{
    private List<GameObject> listeners = new List<GameObject>();
    private MapManager mapManager;
    private AudioManager audioManager;

    void Start()
    {
        AddListener(gameObject);
        mapManager = FindObjectOfType<MapManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    public void AddListener(GameObject listener)
    {
        if(!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void Command(InputField input)
    {
        string[] parts = input.text.Split('.');
        input.text = "";

        GameObject go = listeners.Where(obj => obj.name == "Manager").SingleOrDefault();

        if (go)
            go.SendMessage(parts[0], parts[1]);
    }

    public void loadmap(string input)
    {
        GameObject m = Resources.Load<GameObject>("Maps/" + input);
        mapManager.NewMap(m);
    }

    public void loadscene(string input)
    {
        SceneManager.LoadScene(input);
        Debug.Log("Loaded Scene: " + input);
    }
}
