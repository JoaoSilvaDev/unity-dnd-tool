using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    public List<string> humanMale = new List<string>();
    public List<string> humanFemale = new List<string>();

    public List<string> elfMale = new List<string>();
    public List<string> elfFemale = new List<string>();

    public List<string> dwarfMale = new List<string>();
    public List<string> dwarfFemale = new List<string>();

    public List<string> orcMale = new List<string>();
    public List<string> orcFemale = new List<string>();

    public List<string> tieflingMale = new List<string>();
    public List<string> tieflingFemale = new List<string>();

    public List<string> goliathMale = new List<string>();
    public List<string> goliathFemale = new List<string>();

    public List<string> halflingMale = new List<string>();
    public List<string> halflingFemale = new List<string>();

    public Text textDisplay;
    string race;
    string gender;

    public void SetRace(string input) { race = input;  }
    public void SetGender(string input) { gender = input; }

    public void NewName()
    {
        string name = "";

        switch(gender)
        {
            case "male":
                switch(race)
                {
                    case "human":
                        name = humanMale[Random.Range(0, humanMale.Count-1)];
                        break;

                    case "elf":
                        name = elfMale[Random.Range(0, elfMale.Count - 1)];
                        break;

                    case "dwarf":
                        name = dwarfMale[Random.Range(0, dwarfMale.Count - 1)];
                        break;

                    case "orc":
                        name = orcMale[Random.Range(0, orcMale.Count - 1)];
                        break;

                    case "tiefling":
                        name = tieflingMale[Random.Range(0, tieflingMale.Count - 1)];
                        break;

                    case "goliath":
                        name = goliathMale[Random.Range(0, goliathMale.Count - 1)];
                        break;

                    case "halfling":
                        name = halflingMale[Random.Range(0, halflingMale.Count - 1)];
                        break;
                }
                break;

            case "female":
                switch (race)
                {
                    case "human":
                        name = humanFemale[Random.Range(0, humanFemale.Count - 1)];
                        break;

                    case "elf":
                        name = elfFemale[Random.Range(0, elfFemale.Count - 1)];
                        break;

                    case "dwarf":
                        name = dwarfFemale[Random.Range(0, dwarfFemale.Count - 1)];
                        break;

                    case "orc":
                        name = orcFemale[Random.Range(0, orcFemale.Count - 1)];
                        break;

                    case "tiefling":
                        name = tieflingFemale[Random.Range(0, tieflingFemale.Count - 1)];
                        break;

                    case "goliath":
                        name = goliathFemale[Random.Range(0, goliathFemale.Count - 1)];
                        break;

                    case "halfling":
                        name = halflingFemale[Random.Range(0, halflingFemale.Count - 1)];
                        break;
                }
                break;
        }

        textDisplay.text = name;
    }
}
