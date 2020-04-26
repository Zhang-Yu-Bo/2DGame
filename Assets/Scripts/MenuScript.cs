using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class MenuScript : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject settingCanvas;
    public Text jumpText;
    public Text backText;
    public Text forwardText;
    public Text attackText;

    private string[] name = new string[4];
    private int[] value = new int[4];
    private bool isOpen = false;
    private bool waitPress = false;
    private int nowIndex = 0;

    private void Awake()
    {
        this.isOpen = this.readFile(name, value);
        this.waitPress = false;
        this.nowIndex = 0;
        if (!this.isOpen)
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
        this.UpdateText();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game.");
    }

    public void Setting()
    {
        this.mainCanvas.SetActive(false);
        this.settingCanvas.SetActive(true);
    }

    private bool readFile(string[] name, int[] value)
    {
        UnityEngine.Object configFile = Resources.Load("Setting Files/keyboard config");
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

    public void KeyCodeSaver()
    {
        string content = "";
        for (int i = 0; i < 4; i++)
        {
            if (i != 3)
            {
                content += (this.name[i] + " " + this.value[i].ToString() + "\n");
            }
            else
            {
                content += (this.name[i] + " " + this.value[i].ToString());
            }
        }
        File.WriteAllText("./Assets/Resources/Setting Files/keyboard config.txt", content);

        PlayerPrefs.SetInt("Jump", value[0]);
        PlayerPrefs.SetInt("Back", value[1]);
        PlayerPrefs.SetInt("Forward", value[2]);
        PlayerPrefs.SetInt("Attack", value[3]);
        PlayerPrefs.Save();

        this.BackToMainCanvas();
    }

    public void BackToMainCanvas()
    {
        this.mainCanvas.SetActive(true);
        this.settingCanvas.SetActive(false);
    }

    public void GetPressKeyCode(int index)
    {
        this.waitPress = true;
        this.nowIndex = index;
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if (this.waitPress && e.isKey)
        {
            if (this.checkDouble((int)e.keyCode))
            {
                Debug.Log("Detected key code: " + e.keyCode.ToString());
                Debug.Log((int)e.keyCode);
                this.name[this.nowIndex] = e.keyCode.ToString();
                this.value[this.nowIndex] = (int)e.keyCode;
            }
            this.waitPress = false;
        }
    }

    private bool checkDouble(int keyCode)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i != this.nowIndex && this.value[i] == keyCode)
                return false;
        }
        return true;
    }

    private void UpdateText()
    {
        this.jumpText.text = "JUMP: " + this.name[0];
        this.backText.text = "BACK: " + this.name[1];
        this.forwardText.text = "FORWARD: " + this.name[2];
        this.attackText.text = "ATTACK: " + this.name[3];
    }
}
