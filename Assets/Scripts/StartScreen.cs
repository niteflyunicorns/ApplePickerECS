using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public Button EasyMode, MediumMode, HardMode, HelpScreen;
    
    void Start()
    {
	EasyMode.onClick.AddListener( Easy );
	MediumMode.onClick.AddListener( Medium );
	HardMode.onClick.AddListener( Hard );
	HelpScreen.onClick.AddListener( HelpMsg );
    }

    void Easy() {
	SceneManager.LoadScene( "EasyMode" );
    }

    void Medium() {
	SceneManager.LoadScene( "MediumMode" );
    }

    void Hard() {
	SceneManager.LoadScene( "HardMode" );
    }

    void HelpMsg() {
	SceneManager.LoadScene( "HelpScreen" );
    }
    
    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
