using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementManager : MonoBehaviour
{
    public string[] achivements;

    public static AchivementManager AM;

    private void Awake()
    {
        AM = this;
    }


    private void AllAchivements()
    {
        achivements[0] = "FIRST DUST – Shot Your First Asteroid";
        achivements[1] = "LUCKY SHOT – Bullet Wrapped Screen and Hit an Asteroid";
        achivements[2] = "TRIGGER HAPPY – 1,000 Shots Fired";
        achivements[3] = "ROOKIE PILOT – Score Above 10,000";
        achivements[4] = "EAGLE EYE – 100 Lucky Shots";
        achivements[5] = " SKILLFUL DODGER – Reach Level 5";

    }

    public void FirstDustDone()
    {
        string title = "First Dust";
        string description = "Shot Your First Asteroid";
        AchivementPopup.Ap.PopUp(title, description);
    }

    public void LuckyShot()
    {
        string title = "Lucky Shot";
        string description = "Bullet Wrapped Screen and Hit an Asteroid";
        AchivementPopup.Ap.PopUp(title, description);
    }
    public void EagleEye()
    {
        string title = "EAGLE EYE";
        string description = "100 Lucky Shots";
        AchivementPopup.Ap.PopUp(title, description);
    }
    public void TriggerHappy()
    {
        string title = "TRIGGER HAPPY";
        string description = "1,000 Shots Fired";
        AchivementPopup.Ap.PopUp(title, description);
    }
    public void RookiePilot()
    {
        string title = "Awesome PILOT";
        string description = "Score Above 5,500";
        AchivementPopup.Ap.PopUp(title, description);
    }
    public void SkillfulDodger()
    {
        string title = "SKILLFUL DODGER";
        string description = "Reach Level 5";
        AchivementPopup.Ap.PopUp(title, description);
    }
}
