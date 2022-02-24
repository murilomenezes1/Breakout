using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{

   GameManager gm;
   public AudioSource Music;

   private void OnEnable()
   {
       gm = GameManager.GetInstance();
   }
  
   public void Retornar()
   {
       gm.ChangeState(GameManager.GameState.GAME);
       Music.UnPause();
   }

   public void Inicio()
   {
       gm.ChangeState(GameManager.GameState.MENU);
   }

}
