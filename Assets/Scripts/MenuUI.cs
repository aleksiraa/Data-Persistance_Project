using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public InputField PlayerNameField;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        // Get the value entered into the InputField
        
        string playerName = PlayerNameField.text;
        
        // Log or pass the playerName as required
        Debug.Log("Player Name: " + playerName);
        
        SceneManager.LoadScene(1);
        
        DataManager.Instance.AddPlayerName(playerName);

    }
    
    public void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
    
}
