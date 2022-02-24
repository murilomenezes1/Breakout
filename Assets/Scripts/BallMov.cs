using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMov : MonoBehaviour
{

	[Range(1,15)]
	public float velocity = 5.0f;

	private Vector3 direction;

	GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);

        direction = new Vector3(dirX, dirY).normalized;

        gm = GameManager.GetInstance();
    }



    // Update is called once per frame
    void Update()
    {
    	if (gm.gameState != GameManager.GameState.GAME) return;

        transform.position += direction * Time.deltaTime * velocity;

        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (ViewportPosition.x < 0 || ViewportPosition.x > 1)
        {
        	direction = new Vector3(-direction.x, direction.y);
        }

        if ( ViewportPosition.y > 1 )
        {

        	direction = new Vector3 (direction.x, -direction.y);
        }

        if(ViewportPosition.y< 0)
		{

			Reset();
		}
    }

      private void Reset()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = playerPosition + new Vector3(0, 0.5f, 0);

        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(2.0f, 5.0f);

        direction = new Vector3(dirX, dirY).normalized;
        gm.vidas--;

        if(gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
		{
    		gm.ChangeState(GameManager.GameState.ENDGAME);
		}        


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
    	if(col.gameObject.CompareTag("Player"))
    	{
    		float dirX = Random.Range(-5.0f, 5.0f);
    		float dirY = Random.Range(1.0f, 5.0f);


    		direction = new Vector3(dirX, dirY).normalized;
    	}

    	else if(col.gameObject.CompareTag("Block"))
    	{

    		direction = new Vector3(direction.x, -direction.y);
			gm.pontos++;    	
    	}

    	

    	

    }
}
