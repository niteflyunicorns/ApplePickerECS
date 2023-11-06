using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePickerEasy : MonoBehaviour
{
    [ Header( "Set in Inspector" ) ]
    
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -8f;
    public float basketSpacingY = 1.5f;
    public List<GameObject> basketList;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
	// get current scene name - used for difficulty selection and reload
	sceneName = SceneManager.GetActiveScene().name;

	// generate baskets
	basketList = new List<GameObject>();
        for( int i = 0; i < numBaskets; i++ ) {
	    GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
	    Vector3 pos = Vector3.zero;
	    pos.y = basketBottomY + ( basketSpacingY * i );
	    tBasketGO.transform.position = pos;
	    basketList.Add( tBasketGO );
	}
    }

    public void AppleDestroyed() {
	GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag( "Apple" );
	foreach( GameObject tGO in tAppleArray ) {
	    Destroy( tGO );
	}

	int basketIndex = basketList.Count - 1;
	GameObject tBasketGO = basketList[ basketIndex ];
	basketList.RemoveAt( basketIndex );
	Destroy( tBasketGO );

	// restart game if no baskets left
	if( basketList.Count == 0 ) {
	    SceneManager.LoadScene( sceneName );
	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
