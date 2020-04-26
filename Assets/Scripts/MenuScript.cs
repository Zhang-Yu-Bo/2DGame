using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    private string[] name = new string[4];
    private int[] value = new int[4];

    private void Awake()
    {
        
        if (!this.readFile(name, value))
        {
            Debug.Log("read file error");
            PlayerPrefs.SetInt("Jump", (int)KeyCode.W);
            PlayerPrefs.SetInt("Back", (int)KeyCode.A);
            PlayerPrefs.SetInt("Forward", (int)KeyCode.D);
            PlayerPrefs.SetInt("Attack", (int)KeyCode.J);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("read file success");
            PlayerPrefs.SetInt("Jump", value[0]);
            PlayerPrefs.SetInt("Back", value[1]);
            PlayerPrefs.SetInt("Forward", value[2]);
            PlayerPrefs.SetInt("Attack", value[3]);
            PlayerPrefs.Save();
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game.");
    }

    public void Setting()
    {
        
    }

    private bool readFile(string[] name, int[] value)
    {
        Object configFile = Resources.Load("Setting Files/keyboard config");
        if (configFile == null)
            return false;
        string[] lines = configFile.ToString().Split('\n');
        if (lines.Length != 4)
            return false;

        int index = 0;
        foreach (string line in lines)
        {
            string[] temp = line.Split(' ');
            if (temp.Length != 2)
                return false;
            name[index] = temp[0];
            value[index] = int.Parse(temp[1]);
            index++;
        }
        return true;
    }
}
