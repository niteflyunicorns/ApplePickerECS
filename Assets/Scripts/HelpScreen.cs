using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpScreen : MonoBehaviour
{
    public Button BackBtn;
    
    void Start()
    {
	BackBtn.onClick.AddListener( Back );
    }

    void Back() {
	SceneManager.LoadScene( "StartScreen" );
    }
}
