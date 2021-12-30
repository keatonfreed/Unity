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
    public int startCoins = 0;

    private SceneController sceneCon;
    private GameObject sphereSpawner;

    public GameObject completeLevelUI;
    public GameObject DieScreen;

    // Start is called before the first frame update
    void Start()
    { 
        winScreen = false;
        if(GetComponent<SceneController>() != null){
        sceneCon = GetComponent<SceneController>();
        }
        startCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        sphereSpawner = GameObject.Find("SphereSpawn");
        spawnSphere();
    }


    public void completeLevel() {
        completeLevelUI.SetActive(true);
        winScreen = true;
    }
    public void nextLevel() {
        completeLevelUI.SetActive(false);
        winScreen = false;
        sceneCon.NextScene();
    }
    
    void Update()
    {

        scoreText.text = "Score: " + score.ToString() + "/" + startCoins.ToString();

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
        if(Input.GetKeyDown("h")) {
            startCoins = 0;
        }

        if(winScreen == false && score >= startCoins) {
            completeLevel();
        }
    }


    void spawnSphere() {
        prefab.name = "Sphere";
        // Instantiate(prefab, new Vector3(0f,9f,10f),transform.rotation);
        Instantiate(prefab, sphereSpawner.transform.position, transform.rotation);

    }

    public void Die(GameObject ball) {
        Destroy(ball);
        DieScreen.SetActive(true);
    }

}
