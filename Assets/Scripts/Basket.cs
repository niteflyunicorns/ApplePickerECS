using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header( "Set Dynamically" )]

    public Text scoreGT;
    public GameObject splatterPrefab;
    public bool poisonSlowFlag = false;
    public float delay = 1f;
    float timer = 0f;
    
    void Start()
    {
        GameObject scoreGO = GameObject.Find( "ScoreCounter" );
	scoreGT = scoreGO.GetComponent<Text>();
	scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
	if( !poisonSlowFlag ) {
	    Vector3 mousePos2D = Input.mousePosition;
	    mousePos2D.z = -Camera.main.transform.position.z;
	    Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
	    Vector3 pos = this.transform.position;
	    pos.x = mousePos3D.x;
	    this.transform.position = pos;
	}
	else {
	    timer += Time.deltaTime;
	    if( timer > delay ) {
		poisonSlowFlag = false;
	    }
	}
    }

    private void OnCollisionEnter(Collision collision) {
	GameObject collider = collision.gameObject;
	int score = int.Parse( scoreGT.text );
	
	if( collider.CompareTag( "Apple" ) ) {
	    Destroy( collider );
	    score += 100;
	}
	else if( collider.CompareTag( "RottenApple" ) ) {
	    Destroy( collider );
	    score -= 50;
	    Invoke( "RottenSplatter", 1f );
	}
	else if( collider.CompareTag( "PoisonApple" ) ) {
	    poisonSlowFlag = true;
	    timer = 0f;
	    Destroy( collider );
	    score += 300;
	}

	// update score text from score integer
	scoreGT.text = score.ToString();

	// update high score as it's set
	if( score > HighScore.score ) {
	    HighScore.score = score;
	}
    }

    void RottenSplatter() {
	// splatter on screen for 3 seconds
	float timer = Time.deltaTime;
	GameObject splatter = Instantiate<GameObject>(splatterPrefab);
	Vector3 pos = splatter.transform.position;
	pos.x = Random.Range( -150, 150 );
	pos.y = Random.Range( -100, 100 );
	pos.z = 0;
	splatter.transform.position = pos;
	//Color opacity = splatter.GetComponent<RawImage>().material.color;
	// if( timer > 1 ) {
	//     opacity.a = 0.75f;
	// }
	// else if( timer > 2 ) {
	//     opacity.a = 0.5f;
	// }
	// else if(timer > 3 ) {
	//     opacity.a = 0.25f;
	// }
	// else {
	//     opacity.a = 0f;
	// }
    }
}
