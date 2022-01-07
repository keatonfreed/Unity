using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeController : MonoBehaviour
{
    bool timerActive;
    float currentTime;
    public Text timeText;
    public float timeLimit = 10;
    gameController controller;
    public int score;
    public float multiplier = 5;
    Animator animator;
     
    void Start()
    {   
        controller = GameObject.Find("GameController").GetComponent<gameController>();
        timerActive = true;
        timeText = GameObject.Find("Timer").GetComponent<Text>();
        currentTime = timeLimit+1;
        animator = timeText.GetComponent<Animator>();
    }

    void Update()
    {
        if(timerActive) {
            currentTime -= Time.deltaTime;
            animator.SetBool("flashing", (currentTime <= 10));
            if(currentTime <= 0) {
                stopCountDown();
                controller.Die();
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        if(time.Minutes >= 1) {
        timeText.text = time.ToString("m':'ss");
        } else {
        timeText.text = time.Seconds.ToString();
        }
    }

    public void stopCountDown() {
        animator.SetBool("flashing", false);
        timerActive = false;
    }
    public void changeCount(int count) {
        currentTime += count;
    }

    public int getTimeScore() { 
        return Mathf.RoundToInt(currentTime * multiplier);
    }
    public int getTimeScoreMax() { 
        return Mathf.RoundToInt(timeLimit*multiplier);
    }
    
}
