using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
   public GameObject Bloco;
   GameManager gm;

   void Start()
   {
       gm = GameManager.GetInstance();
       GameManager.changeStateDelegate += Construir;
       Construir();
   }

   void Construir()
   {
       
       if (gm.gameState == GameManager.GameState.GAME)
       {
           foreach (Transform child in transform) {
               GameObject.Destroy(child.gameObject);
           }
           for(int i = 0; i < 12; i++)
           {
               for(int j = 0; j < 4; j++){
                   Vector3 posicao = new Vector3(-9 + 1.55f * i, 4 - 0.55f * j);

                   Instantiate(Bloco, posicao, Quaternion.identity, transform).GetComponent<Renderer>().material.color = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f)); //adaptado de https://stackoverflow.com/questions/53032974/instantiate-a-prefab-with-a-random-color?rq=1
               }
           }
       }
   }

   void Update()
   {
       if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
       {
           gm.ChangeState(GameManager.GameState.ENDGAME);

       }
   }

}