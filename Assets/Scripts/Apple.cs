using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    public static string sceneName;

    // using to check difficulty
    void Awake() {
	sceneName = SceneManager.GetActiveScene().name;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( transform.position.y < bottomY ) {
	    Destroy( this.gameObject );

	    if ( sceneName == "MediumMode" ) {
		ApplePickerMed apScript = Camera.main.GetComponent<ApplePickerMed>();
		if( this.gameObject.CompareTag( "Apple" ) ) {
		    apScript.AppleDestroyed();
		}
	    }
	    else if ( sceneName == "HardMode" ) {
		ApplePickerHard apScript = Camera.main.GetComponent<ApplePickerHard>();
		if( this.gameObject.CompareTag( "RottenApple" ) ) {
		    apScript.RottenAppleDestroyed();
		}
		else if( this.gameObject.CompareTag( "PoisonApple" ) ) {
		    apScript.PoisonAppleDestroyed();
		}
		else {
		    apScript.AppleDestroyed();
		}
	    }
	    else {
		ApplePickerEasy apScript = Camera.main.GetComponent<ApplePickerEasy>();
		apScript.AppleDestroyed();
	    }
	}
    }
}
