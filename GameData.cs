using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class GameData
{
    public double credits;

    // Income Multiplier Variables
    public double clickMultiplier;
    public double clickMultiCost;

    public double modsCollected;
    public double modsToCollect;
    public double modsCost;

    public int clickMultiRank;
    public int clickMultiProgress;
    public int clickMultiRankUp;

    public double idleMultiplier;
    public double idleMultiCost;
    public int idleMultiRank;
    public int idleMultiProgress;
    public int idleMultiRankUp;
    public int menuSwitcher;

    // Initialize income upgrade variables
    public double clickUpgrade;
    public double clickPower;
    public double clickCost;

    public double idleUpgrade;
    public double idlePower;
    public double idleCost;
    
    public bool checkOfflineProduction;


    public GameData()
    {
        // Sets all values from game back to beginning values
        credits = 0;
        clickCost = 0.3;
        clickPower = .5;
        clickUpgrade = .5;
        idleCost = .8;
        idlePower = 0;
        idleUpgrade = .3;
        clickMultiplier = 2;
        idleMultiplier = 2;
        clickMultiCost = 5;
        clickMultiProgress = 1;
        clickMultiRank = 1;
        clickMultiRankUp = 5;
        idleMultiCost = 10;
        idleMultiplier = 1.7;
        idleMultiProgress = 1;
        idleMultiRankUp = 5;
        modsCost = 140000000;
        modsCollected = 0;
        modsToCollect = 0;
        checkOfflineProduction = false;
    }
    public void FullReset()
    {
        // Sets all values from game back to beginning values
        credits = 0;
        clickCost = 0.3;
        clickPower = .5;
        clickUpgrade = .5;
        idleCost = .8;
        idlePower = 0;
        idleUpgrade = .3;
        clickMultiplier = 2;
        idleMultiplier = 2;
        clickMultiCost = 5;
        clickMultiProgress = 1;
        clickMultiRank = 1;
        clickMultiRankUp = 5;
        idleMultiCost = 10;
        idleMultiplier = 1.7;
        idleMultiProgress = 1;
        idleMultiRank = 1;
        idleMultiRankUp = 5;
        modsCost = 140000000;
        modsCollected = 0;
        modsToCollect = 0;
        checkOfflineProduction = false;
    }
}
