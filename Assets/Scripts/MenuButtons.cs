using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
   
   public void PlayGame ()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
   }
   public void QuitGame()
   {
       Debug.Log("Quit!");
       Application.Quit();
   }

   public void BackMainMenu ()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
   }
}
