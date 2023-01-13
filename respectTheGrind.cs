using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class respectTheGrind : MonoBehaviour
{
    public GameObject offlinePopup;
    public GameData data;
    public TMP_Text creditsText;
    public TMP_Text clickText;
    public TMP_Text idleText;



    public TMP_Text modsText;
    public TMP_Text modsButtonText;

    public TMP_Text resetText;



    // Initialize Canvas Group (Alternate menu) variables
    public CanvasGroup mainScreen;
    public CanvasGroup upgradeScreen;
    public CanvasGroup settingsScreen;
    public CanvasGroup uiOverlay;

    // INITIALIZE AWAY REWARDS TEXTS
    public TMP_Text awayText;
    public TMP_Text awayCreditsText;
    public TMP_Text awayHourText;

    public bool isOffline;
    public double awayCredits;

        // Initialize Progress Bars
    public GameObject hourClaimButton;
    public Image clickPB;
    public TMP_Text clickPBText;

    public Image hourlyRewardsPB;
    public TMP_Text hourlyRewardsPBText;
    public bool hourPassed;
    public int rewardProgressStart;
    public int minutes;

    public TMP_Text multiplierText;
    public TMP_Text clickUpgradeText;
    public TMP_Text idleUpgradeText;

    public TMP_Text clickMultiText;
    public TMP_Text idleMultiText;

    DateTime oldDate;
    DateTime currentDate;

    public void collectRewards() {
        hourPassed = false;
        hourClaimButton.gameObject.SetActive(false);
        data.credits *= 5;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LAST_LOGIN",DateTime.Now.ToString());
    }
    public void Start() {
        oldDate = System.DateTime.Now;

        if (PlayerPrefs.HasKey("LAST_LOGIN"))
            {
            data.idlePower = double.Parse(PlayerPrefs.GetString("idlePower", "0"));
            isOffline = true;
            DateTime lastLogin = DateTime.Parse(PlayerPrefs.GetString("LAST_LOGIN"));
            TimeSpan ts = DateTime.Now - lastLogin;
            awayCredits = data.idlePower * ts.TotalSeconds;
            if (ts.Hours > 0) {
                hourPassed = true;
            }

            awayText.text = string.Format("You were away for\n{0}D {1}H {2}M {3}S", ts.Days,ts.Hours,ts.Minutes,ts.Seconds);
            
            data.credits += awayCredits;

            if (awayCredits > 1000) {
            var exponent = (Math.Floor(Math.Log10(Math.Abs(awayCredits))));
            var mantissa = (awayCredits / Math.Pow(10, exponent));
            awayCreditsText.text = "Meanwhile, you have earned\n" + mantissa.ToString("F2") + "e" + exponent + " Credits";
        } else {
            awayCreditsText.text = "Meanwhile, you have earned\n" + awayCredits.ToString("F2") + " Credits";
        }
        }
        else
        {
            awayText.text = "WELCOME";
            awayCreditsText.text = "0 Credits";
        }

        mainScreen.gameObject.SetActive(false);
        Application.targetFrameRate = 60;
        data.menuSwitcher = 0;
        resetText.text = "Reset Game";
        Load();
    }
    public void CloseOffline(){

        data.credits += awayCredits;
        mainScreen.gameObject.SetActive(true);
        offlinePopup.gameObject.SetActive(false);

    }

    public void Load(){
        data.credits = double.Parse(PlayerPrefs.GetString("credits", "0"));
        data.clickCost = double.Parse(PlayerPrefs.GetString("clickCost", "0"));
        data.clickPower = double.Parse(PlayerPrefs.GetString("clickPower", "0.5"));
        data.clickUpgrade = double.Parse(PlayerPrefs.GetString("clickUpgrade", "0"));
        data.idleCost = double.Parse(PlayerPrefs.GetString("idleCost", "0"));
        data.idlePower = double.Parse(PlayerPrefs.GetString("idlePower", "0"));
        data.idleUpgrade = double.Parse(PlayerPrefs.GetString("idleUpgrade", "0"));
        data.clickMultiplier = double.Parse(PlayerPrefs.GetString("clickMultiplier", "0"));
        data.idleMultiplier = double.Parse(PlayerPrefs.GetString("idleMultiplier", "0"));
        data.clickMultiCost = double.Parse(PlayerPrefs.GetString("clickMultiCost", "0"));
        data.clickMultiProgress = PlayerPrefs.GetInt("clickMultiProgress", 0);
        data.clickMultiRank = PlayerPrefs.GetInt("clickMultiRank", 0);
        data.clickMultiRankUp = PlayerPrefs.GetInt("clickMultiRankUp", 0);
        data.idleMultiRank = PlayerPrefs.GetInt("idleMultiRank", 0);

        data.idleMultiCost = double.Parse(PlayerPrefs.GetString("idleMultiCost", "0"));
        data.idleMultiplier = double.Parse(PlayerPrefs.GetString("idleMultiplier", "0"));
        data.idleMultiProgress = PlayerPrefs.GetInt("idleMultiProgress", 0);
        data.idleMultiRankUp = PlayerPrefs.GetInt("idleMultiRankUp", 0);
        data.modsCost = double.Parse(PlayerPrefs.GetString("modsCost", "0"));
        data.modsCollected = PlayerPrefs.GetInt("modsCollected", 0);
        data.modsToCollect = PlayerPrefs.GetInt("modsToCollect", 0);
        data.checkOfflineProduction = false;
    }


    public void Save(){
        PlayerPrefs.SetString("credits", data.credits.ToString());
        PlayerPrefs.SetString("clickPower", data.clickPower.ToString());
        PlayerPrefs.SetString("idlePower", data.idlePower.ToString());
        PlayerPrefs.SetString("modsCollected", data.modsCollected.ToString());
        PlayerPrefs.SetString("modsToCollect", data.modsToCollect.ToString());
        PlayerPrefs.SetString("modsCost", data.modsCost.ToString());
        PlayerPrefs.SetString("clickUpgrade", data.clickUpgrade.ToString());
        PlayerPrefs.SetString("idleUpgrade", data.idleUpgrade.ToString());
        PlayerPrefs.SetString("idleCost", data.idleCost.ToString());
        PlayerPrefs.SetString("idleMultiplier", data.idleMultiplier.ToString());
        PlayerPrefs.SetString("clickMultiplier", data.clickMultiplier.ToString());
        PlayerPrefs.SetString("clickCost", data.clickCost.ToString());
        PlayerPrefs.SetString("clickMultiCost", data.clickMultiCost.ToString());
        PlayerPrefs.SetString("idleMultiCost", data.idleMultiCost.ToString());

        PlayerPrefs.SetInt("idleMultiRank", data.idleMultiRank);
        PlayerPrefs.SetInt("idleMultiProgress", data.idleMultiProgress);
        PlayerPrefs.SetInt("clickMultiRank", data.clickMultiRank);
        PlayerPrefs.SetInt("clickMultiProgress", data.clickMultiProgress);
        PlayerPrefs.SetInt("clickMultiRankUp", data.clickMultiRankUp);
        PlayerPrefs.SetInt("idleMultiRankUp", data.idleMultiRankUp);
    }

    public void Update() {
        currentDate = System.DateTime.Now;
        minutes = currentDate.Minute - oldDate.Minute;

        data.credits += data.idlePower * Time.deltaTime;

        // Update Progress Bars + Text Objects attached
        clickPB.fillAmount = (data.clickMultiProgress * 1.0f / data.clickMultiRankUp);
        clickPBText.text = data.clickMultiProgress + "/" + data.clickMultiRankUp;
        
        hourlyRewardsPB.fillAmount = (currentDate.Minute * 1.0f / 60);
        hourlyRewardsPBText.text = (60 - currentDate.Minute) + "M " + (60 - currentDate.Second) + "S Until Payout";

        if (currentDate.Minute == 59)
        {
            hourPassed = true;
        }
        if (hourPassed)
        {
            hourClaimButton.gameObject.SetActive(true);
            hourlyRewardsPBText.text = "Payout Ready!!!";
            awayHourText.gameObject.SetActive(true);
        }
        else
        {
            hourClaimButton.gameObject.SetActive(false);
            awayHourText.gameObject.SetActive(false);
        }


        if (data.credits > 1000) {
            var exponent = (Math.Floor(Math.Log10(Math.Abs(data.credits))));
            var mantissa = (data.credits / Math.Pow(10, exponent));
            creditsText.text = "$" + mantissa.ToString("F2") + "e" + exponent;
        } else {
            creditsText.text = "$" + data.credits.ToString("F2");
        }

        if (data.credits > 1000) {
            var exponent = (Math.Floor(Math.Log10(Math.Abs(data.credits))));
            var mantissa = (data.credits / Math.Pow(10, exponent));
            creditsText.text = "$" + mantissa.ToString("F2") + "e" + exponent;
        } else {
            creditsText.text = "$" + data.credits.ToString("F2");
        }

        if (data.clickPower > 1000) {
            var exponent = (Math.Floor(Math.Log10(Math.Abs(data.clickPower))));
            var mantissa = (data.clickPower / Math.Pow(10, exponent));
            clickText.text = "+$" + mantissa.ToString("F2") + "e" + exponent;
        } else {
            clickText.text = "+$" + data.clickPower.ToString("F2");
        }

        if (data.idlePower > 1000) {
            var exponent = (Math.Floor(Math.Log10(Math.Abs(data.idlePower))));
            var mantissa = (data.idlePower / Math.Pow(10, exponent));
            idleText.text = "$" + mantissa.ToString("F2") + "e" + exponent + "/Sec";
        } else {
            idleText.text = "$" + data.idlePower.ToString("F2") + " Credits/Sec";
        }

        if (data.idleCost > 1000) {
            var exponent = (Math.Floor(Math.Log10(Math.Abs(data.idleCost))));
            var mantissa = (data.idleCost / Math.Pow(10, exponent));
            idleUpgradeText.text = "+$" + Math.Round(data.idleUpgrade, 2) + " CPS\nCost: $" + mantissa.ToString("F2") + "e" + exponent; 
        } else {
            idleUpgradeText.text = "+$" + Math.Round(data.idleUpgrade, 2) + " CPS\nCost: $" + data.idleCost.ToString("F2"); 
        }
        if (data.clickCost > 1000) {
            var exponent = (Math.Floor(Math.Log10(Math.Abs(data.clickCost))));
            var mantissa = (data.clickCost / Math.Pow(10, exponent));
            clickUpgradeText.text = "+$" + Math.Round(data.clickUpgrade, 2) + " Per Click\nCost: $" + mantissa.ToString("F2") + "e" + exponent; 
        } else {
            clickUpgradeText.text = "+$" + Math.Round(data.clickUpgrade, 2) + " Per Click\nCost: $" + data.clickCost.ToString("F2"); 
        }
        // Displays Income Multiplier Buttons
        if (data.clickMultiCost > 1000) {
            var exponent = (Math.Floor(Math.Log10(Math.Abs(data.clickMultiCost))));
            var mantissa = (data.clickMultiCost / Math.Pow(10, exponent));
            clickMultiText.text = "x" + Math.Round(data.clickMultiplier, 2) + " Clicker Rank " + data.clickMultiRank + "\n(" + data.clickMultiProgress + "/" + data.clickMultiRankUp + ")\nCost: $" + mantissa.ToString("F2") + "e" + exponent; 
        } else {
            clickMultiText.text = "x" + Math.Round(data.clickMultiplier, 2) + " Clicker Rank " + data.clickMultiRank + "\n(" + data.clickMultiProgress + "/" + data.clickMultiRankUp + ")\nCost: $" + data.clickMultiCost.ToString("F2"); 
        }
        if (data.idleMultiCost > 1000) {
            var exponent = (Math.Floor(Math.Log10(Math.Abs(data.idleMultiCost))));
            var mantissa = (data.idleMultiCost / Math.Pow(10, exponent));
            idleMultiText.text = "x" + Math.Round(data.idleMultiplier, 2) + " Idle SPD Rank " + data.idleMultiRank + "\n(" + data.idleMultiProgress + "/" + data.idleMultiRankUp + ")\nCost: $" + mantissa.ToString("F2") + "e" + exponent; 
        } else {
            idleMultiText.text = "x" + Math.Round(data.idleMultiplier, 2) + " Idle SPD Rank " + data.idleMultiRank + "\n(" + data.idleMultiProgress + "/" + data.idleMultiRankUp + ")\nCost: $" + data.idleMultiCost.ToString("F2"); 
        }



        // Displays Module (Prestige) Info
        if (data.modsCost > 1000) {
            var exponent = (Math.Floor(Math.Log10(Math.Abs(data.modsCost))));
            var mantissa = (data.modsCost / Math.Pow(10, exponent));
            modsButtonText.text = "+" + data.modsToCollect + " On Reboot\nNext Mod: $" + mantissa.ToString("F2") + "e" + exponent;
        } else {
            modsButtonText.text = "+" + data.modsToCollect + " On Reboot\nNext Mod: $" + data.modsCost.ToString("F2");
        }
        if (data.modsCollected > 1000) {
            var exponent = (Math.Floor(Math.Log10(Math.Abs(data.modsCollected))));
            var mantissa = (data.modsCollected / Math.Pow(10, exponent));
            modsText.text = mantissa.ToString("F2") + "e" + exponent + " Mods";
        } else {
            modsText.text = data.modsCollected.ToString("F0") + " Mods";
        }
        if (data.credits > data.modsCost) {
            data.modsToCollect ++;
            data.modsCost *= 5;
        }



        Save();

        // Check for Button Press, closes application
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Escape Pressed");
        }
    }
    public void Click() {
        data.credits += data.clickPower;
    }

    public void screenSwitch(bool x, CanvasGroup y) {
        if (x) {
            y.alpha = 1;
            y.interactable = true;
            y.blocksRaycasts = true;
            return;
        }
            y.alpha = 0;
            y.interactable = false;
            y.blocksRaycasts = false;
    }

    public void switchMenu(string id) {
        switch (id) {
            case "upgrades":
                screenSwitch(false, mainScreen);
                screenSwitch(true, uiOverlay);
                screenSwitch(true, upgradeScreen);
                data.menuSwitcher = 1;
                break;
            case "main":
                screenSwitch(true, mainScreen);
                screenSwitch(false, uiOverlay);
                screenSwitch(false, upgradeScreen);
                screenSwitch(false, settingsScreen);
                data.menuSwitcher = 0;
                break;
            case "settings":
                screenSwitch(false, mainScreen);
                screenSwitch(false, upgradeScreen);
                screenSwitch(true, uiOverlay);
                screenSwitch(true, settingsScreen);
                break;
        }

    }
    public void upgradeClick() 
    {
    if (data.credits > data.clickCost) {
        data.credits -= data.clickCost;
        data.clickPower += data.clickUpgrade;
        data.clickCost *= 1.20;
        data.clickUpgrade *= 1.15;
    }
    }   
        public void upgradeIdle() 
    {
    if (data.credits > data.idleCost) 
    {
        data.credits -= data.idleCost;
        data.idlePower += data.idleUpgrade;
        data.idleCost *= 1.20;
        data.idleUpgrade *= 1.15;
    }
    }
    public void multiplyIdle() {
        if (data.credits > data.idleMultiCost) {
            data.credits -= data.idleMultiCost;
            data.idlePower *= data.idleMultiplier;
            data.idleMultiplier += .01;
            data.idleMultiCost *= 15;
            data.idleMultiProgress++;
        }
        if (data.idleMultiProgress == data.idleMultiRankUp) {
            data.idleMultiplier *= 1.75;
            data.idleMultiCost *= 30;
            data.idleMultiRankUp += 5;
            data.idleMultiProgress = 1;
            data.idleMultiRank++;
        } 
    }
    public void Reset() 
    {
        data.FullReset();
        screenSwitch(true, mainScreen);
        screenSwitch(false, upgradeScreen);
        screenSwitch(false, uiOverlay);
        screenSwitch(false, settingsScreen);
    }

    // Infinite Upgrade Buttons

    // On-Click For Multipliers
    public void multiplyClick() {
        if (data.credits > data.clickMultiCost) {
            data.credits -= data.clickMultiCost;
            data.clickPower *= data.clickMultiplier;
            data.clickMultiplier += .01;
            data.clickMultiCost *= 10;
            data.clickMultiProgress++;
        }
        if (data.clickMultiProgress == data.clickMultiRankUp) {
            data.clickMultiplier *= 1.75;
            data.clickMultiCost *= 20;
            data.clickMultiProgress = 1;
            data.clickMultiRank++;
            data.clickMultiRankUp += 3;
        }
    }

    public void Prestige() {
        if (data.credits > data.modsCost || data.modsToCollect > 0) {
            data.credits = 0;
            data.modsCollected += data.modsToCollect;
            data.modsToCollect = 0;
            data.modsCost = 140000000;
            data.idleCost = 3;
            data.idleUpgrade = .1;
            data.idleMultiCost = 10;
            data.clickCost = .5;
            data.clickMultiplier = 2;
            data.idleMultiplier = 1.75;
            data.clickUpgrade = .05;
            data.clickPower = .5 * (data.modsCollected * 1.2);
            data.clickMultiCost = 5;
            data.idlePower = 0;

            data.clickMultiRank = 1;
            data.clickMultiProgress = 1;
            data.clickMultiRankUp = 5;

            data.idleMultiRank = 1;
            data.idleMultiProgress = 1;
            data.idleMultiRankUp = 5;
        }
    }

    public void rankUp() {
    if (data.clickMultiProgress == data.clickMultiRankUp) {
        data.clickMultiplier *= 2;
        data.clickMultiCost *= 5;            
        data.clickMultiProgress = 1;
        data.clickMultiRank++;
        }
    }
}
