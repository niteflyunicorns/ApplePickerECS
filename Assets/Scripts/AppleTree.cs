using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Start is called before the first frame update;
	
    public GameObject applePrefab; // apple prefab
    public GameObject rotApplePrefab; // rotten apple prefab
    public GameObject poisApplePrefab; // poison apple prefab
    public int level = 1; // 1 for easy, 2 for med, 3 for hard
    public float speed = 15f; // speed of the tree
    public float leftAndRightEdge = 25f; // game screen boundaries
    public float changeDirChance = 0.02f;
    public float appleFreq = 1f;
    public float rotAppleChance = 0.1f;
    public float poisAppleChance = 0.05f;
    public string sceneName;
    
    void Start()
    {
		sceneName = SceneManager.GetActiveScene().name;
		if ( sceneName == "MediumMode" ) {
	    	level = 2;
	    	speed += 5;
	    	changeDirChance = 0.03f;
	    	appleFreq = 0.75f;
		}
	    else if ( sceneName == "HardMode" ) {
	        level = 3;
	        speed += 10;
	        changeDirChance = 0.04f;
	        appleFreq = 0.5f;
	    }
	    else {
	        level = 1; // also the default
	    }

	    Invoke( "DropApple", 2f );
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		if (pos.x < -leftAndRightEdge) {
		    speed = Mathf.Abs(speed);
		}
		else if (pos.x > leftAndRightEdge) {
		    speed = -Mathf.Abs(speed);
		}
    }
    
    private void FixedUpdate()
    {
		if (Random.value < changeDirChance) {    
		    speed *= -1; // change direction
		}
    }

    void DropApple()
    {
		float changeApple = Random.value;

		if ( level != 1 && changeApple < rotAppleChance && changeApple > poisAppleChance ) {
		    GameObject rotApple = Instantiate<GameObject>(rotApplePrefab);
		    rotApple.transform.position = transform.position;
		}
		else if ( level != 1 && level != 2 && changeApple < poisAppleChance ) {
		    GameObject poisApple = Instantiate<GameObject>(poisApplePrefab);
		    poisApple.transform.position = transform.position;
		}
		else {
		    GameObject apple = Instantiate<GameObject>(applePrefab);
		    apple.transform.position = transform.position;
		}
	
		Invoke("DropApple", appleFreq);
    }
}
