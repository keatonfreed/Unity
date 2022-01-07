using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{

    public GameObject prefab;

    public Text collectedText;
    public int collected = 0;
    public int coinsCount = 0;

    private SceneController sceneController;
    private GameObject sphereSpawner;

    public GameObject completeLevelUI;
    public GameObject DieScreen;
    public bool winScreen = false;
    public bool dieScreen = false;
    public Text scoreText;

    private TimeController timeController;

    void Start()
    { 
        timeController = GetComponent<TimeController>();
        winScreen = false;
        dieScreen = false;
        if(GetComponent<SceneController>() != null){
        sceneController = GetComponent<SceneController>();
        }
        coinsCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        sphereSpawner = GameObject.Find("SphereSpawn");
        collectedText = GameObject.Find("Collected").GetComponent<Text>();
        spawnSphere();
    }


    public void completeLevel() {
        if(winScreen == false && dieScreen == false) {
        completeLevelUI.SetActive(true);
        winScreen = true;
        timeController.stopCountDown();
        scoreText.text = "Score: " + timeController.getTimeScore() + "/" + timeController.getTimeScoreMax();
        }
    }

    public void nextLevel() {
        completeLevelUI.SetActive(false);
        winScreen = false;
        sceneController.NextScene();
    }
    
    void Update()
    {
        collectedText.text = "Collected: " + collected.ToString() + "/" + coinsCount.ToString();

        if(Input.GetKey("t")) {
            // spawnSphere();
        }
        if(Input.GetKeyDown("g")) {
            // spawnSphere();
        }
        if(Input.GetKeyDown("q")) {
            completeLevel();
        }
        if(Input.GetKeyDown("r")) {
            Die();
        }
        
        if(Input.GetKeyDown("l")) {
            // timeController.changeCount(-1);
        }
        if(Input.GetKeyDown("o")) {
            // timeController.changeCount(1);
        }
        


        if(collected >= coinsCount) {
            completeLevel();
        }
    }


    void spawnSphere() {
        prefab.name = "Sphere";
        Instantiate(prefab, sphereSpawner.transform.position, transform.rotation);
    }

    public void Die(GameObject ball = null) {
        if(ball != null) {
        Destroy(ball);
        }
        if(!winScreen) {
        timeController.stopCountDown();
        DieScreen.SetActive(true);
        dieScreen = true;
        }
    }

}
