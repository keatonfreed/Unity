using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void NextScene() {
       if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings-1) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       }
    }
    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetScene(int index) { 
        if(index <= SceneManager.sceneCountInBuildSettings-1) {
        SceneManager.LoadScene(index);
       }
    }
}
