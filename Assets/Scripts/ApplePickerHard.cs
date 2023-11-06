using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePickerHard : MonoBehaviour
{
    [ Header( "Set in Inspector" ) ]
    
    public GameObject basketPrefab;
    public int numBaskets = 1;
    public float basketBottomY = -8f;
    public float basketSpacingY = 1.5f;
    public List<GameObject> basketList;
    public string sceneName;
    //public List<GameObject> obstacles;
    //public int difficulty = 0;
    //public int numObstacles = 0;

    // obstacles to use:
    // poison apple - slows user down (introduce a delay for x amount of time)
    //                but gives bonus points
    // rotten apple - when caught, splatters on screen & reduces visibility
    // wind         - occasionally blows apples around on the screen
    // bird         - steals baskets from user unless they dodge the bird
    //              - just travels in straight diagonal lines in v shape (ie. mousetrap)
    // other fruit  - bananas, different color apples, peaches, pears, etc... each do
    //              - different things / give different points

    // void DifficultyAdjustments( int difficulty ) {
    // 	// method that determines #obstacles for current level

    // 	// if difficulty == medium
    // 	// randomly select 1 obstacle from list for each restart of game

    // 	// if difficulty == hard
    // 	// put all obstacles in the game at the same time
    // }
    
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

	// obstacles = new List<GameObject>();
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

    public void RottenAppleDestroyed() {
	GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag( "RottenApple" );
	foreach( GameObject tGO in tAppleArray ) {
	    Destroy( tGO );
	}
    }

    public void PoisonAppleDestroyed() {
	GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag( "PoisonApple" );
	foreach( GameObject tGO in tAppleArray ) {
	    Destroy( tGO );
	}
    }

    public void BirdDestroyed() {
	GameObject[] tBirdArray = GameObject.FindGameObjectsWithTag( "Bird" );
	foreach( GameObject birdGO in tBirdArray ) {
	    Destroy( birdGO );
	}
    }
    
    // private void OnCollisionEnter(Collision collision) {
    // 	GameObject collider = collision.gameObject;
    // 	int basketIndex = basketList.Count - 1;
    // 	GameObject tBasketGO = basketList[ basketIndex ];
	
    // 	if( collider.CompareTag( "Bird" ) ) {
    // 	    basketList.RemoveAt( basketIndex );
    // 	    Destroy( tBasketGO );
    // 	    }
	
    // 	if( basketList.Count == 0) {
    // 	    SceneManager.LoadScene( sceneName );
    // 	}
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
