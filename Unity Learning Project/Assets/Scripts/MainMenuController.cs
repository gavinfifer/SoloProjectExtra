using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load_Scene(string InputScene)
    {
        SceneManager.LoadScene(InputScene);
    }

    public void Quit_Game()
    {
        Application.Quit();
    }
}

