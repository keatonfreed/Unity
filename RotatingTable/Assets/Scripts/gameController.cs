using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{

    public GameObject prefab;
    public GameObject[] coins;
    public bool winScreen = false;

    public Text scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    { 
        spawnSphere();
        winScreen = false;
    }

    public GameObject completeLevelUI;

    public void completeLevel() {
        completeLevelUI.SetActive(true);
        winScreen = true;
    }
    public void nextLevel() {
        completeLevelUI.SetActive(false);
        winScreen = false;
    }
    
    // Update is called once per frame
    void Update()
    {

                scoreText.text = "Score: " + score.ToString();

        // if(Input.GetKeyDown("a")) {
        // spawnSphere();
        // }
        if(Input.GetMouseButtonDown(0)) {
            // spawnSphere();
        }
        if(Input.GetKey("t")) {
            spawnSphere();
        }
        if(Input.GetKeyDown("g")) {
            spawnSphere();
        }

        coins = GameObject.FindGameObjectsWithTag("Coin");
        if(winScreen == false && coins.Length <= 0) {
            completeLevel();
        }
    }


    void spawnSphere() {
        prefab.name = "test";
        Instantiate(prefab, new Vector3(0f,9f,10f),transform.rotation);
    }

    public void die() {
        // Debug.Log("test");
    }

}
