using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Load_SampleScene()
    {
        Application.LoadLevel("SampleScene");
    }

    public void Load_MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
