using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMov : MonoBehaviour
{
	[Range(1,15)]
	public float velocity = 5.0f;
	GameManager gm;
    public AudioSource Music;

    // Start is called before the first frame update
    void Start()
    {
       gm = GameManager.GetInstance(); 
    }

    // Update is called once per frame
    void Update()
    {
    	if (gm.gameState != GameManager.GameState.GAME) return;
        float inputX = Input.GetAxis("Horizontal");

        transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocity;

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.PAUSE);
            Music.Pause();
    	}


        }
    }
