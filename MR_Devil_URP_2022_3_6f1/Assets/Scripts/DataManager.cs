using System;
using TMPro;
using UnityEngine;

[Serializable]
public class UserData
{
    public string nickname;

    public int level;

    public int coin;
    public int gem;

    public int attackLevel;
    public int speedLevel;
    public int criticalLevel;
    public int defenseLevel;
    public int healthLevel;

    public UserData()
    {
        nickname = string.Empty;

        level = 0;

        coin = 0;
        gem = 0;

        attackLevel = 0;
        speedLevel = 0;
        criticalLevel = 0;
        defenseLevel = 0;
        healthLevel = 0;
    }

    public UserData(string _nickname, int _level, int _coin, int _gem, int _attackLevel, int _speedLevel, int _criticalLevel, int _defenseLevel, int _healthLevel)
    {
        nickname = _nickname;

        level = _level;

        coin = _coin;
        gem = _gem;

        attackLevel = _attackLevel;
        speedLevel = _speedLevel;
        criticalLevel = _criticalLevel;
        defenseLevel = _defenseLevel;
        healthLevel = _healthLevel;
    }
}

public class DataManager : Singleton<DataManager>
{
    public UserData data;

    public void SaveData<T>(string key, T value)
    {
        switch (value.GetType().ToString())
        {
            case "System.Int32":
                {
                    PlayerPrefs.SetInt(key, int.Parse(value.ToString()));
                    break;
                }
            case "System.Single[]":
                {
                    PlayerPrefs.SetFloat(key, float.Parse(value.ToString()));
                    break;
                }
            case "System.String[]":
                {
                    PlayerPrefs.SetString(key, value.ToString());
                    break;
                }
        }
    }

    public void SaveData(string nickname, int level, int coin, int gem, int attackLevel, int speedLevel, int criticalLevel, int defenseLevel, int healthLevel)
    {
        PlayerPrefs.SetString("NickName", nickname);
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.SetInt("Gem", gem);
        PlayerPrefs.SetInt("AttackLevel", attackLevel);
        PlayerPrefs.SetInt("SpeedLevel", speedLevel);
        PlayerPrefs.SetInt("CriticalLevel", criticalLevel);
        PlayerPrefs.SetInt("DefenseLevel", defenseLevel);
        PlayerPrefs.SetInt("HealthLevel", healthLevel);
    }

    public int LoadIntData(string key)
    {
        if (!PlayerPrefs.HasKey(key))
            return 1;

        return PlayerPrefs.GetInt(key);
    }

    public float LoadFloatData(string key)
    {
        if (!PlayerPrefs.HasKey(key))
            return 1f;

        return PlayerPrefs.GetFloat(key);
    }

    public string LoadStringData(string key)
    {
        if (!PlayerPrefs.HasKey(key))
            return "Temp";

        return PlayerPrefs.GetString(key);
    }

    public void LoadData()
    {
        string nickname = LoadStringData("Nickname");

        int level = LoadIntData("Level");

        int coin = LoadIntData("Coin");
        int gem = LoadIntData("Gem");

        int attackLevel = LoadIntData("AttackLevel");
        int speedLevel = LoadIntData("SpeedLevel");
        int criticalLevel = LoadIntData("CriticalLevel");
        int defenseLevel = LoadIntData("DefenseLevel");
        int healthLevel = LoadIntData("HealthLevel");

        data = new UserData(nickname, level, coin, gem, attackLevel, speedLevel, criticalLevel, defenseLevel, healthLevel);
    }

    public void UpdateData()
    {
        LoadData();

        //Singleton.Instance.nickname.GetComponent<TextMeshProUGUI>().text = data.nickname;

        Singleton.Instance.levelTmpLevel.GetComponent<TextMeshProUGUI>().text = data.level.ToString();

        Singleton.Instance.coinTmpCoin.GetComponent<TextMeshProUGUI>().text = data.coin.ToString();
        Singleton.Instance.gemTmpCoin.GetComponent<TextMeshProUGUI>().text = data.gem.ToString();

        Singleton.Instance.statAttackTmpLevel.GetComponent<TextMeshProUGUI>().text = "Lv." + data.attackLevel.ToString();
        Singleton.Instance.statAttackTmpValue.GetComponent<TextMeshProUGUI>().text = (data.attackLevel * 5f).ToString();
        Singleton.Instance.statAttackButtonUpCostTmpCost.GetComponent<TextMeshProUGUI>().text = (data.attackLevel * 50f).ToString();

        Singleton.Instance.statSpeedTmpLevel.GetComponent<TextMeshProUGUI>().text = "Lv." + data.speedLevel.ToString();
        Singleton.Instance.statSpeedTmpValue.GetComponent<TextMeshProUGUI>().text = (1 + data.speedLevel * 0.001f).ToString();
        Singleton.Instance.statSpeedButtonUpCostTmpCost.GetComponent<TextMeshProUGUI>().text = (data.speedLevel * 50f).ToString();

        Singleton.Instance.statCriticalTmpLevel.GetComponent<TextMeshProUGUI>().text = "Lv." + data.criticalLevel.ToString();
        Singleton.Instance.statCriticalTmpValue.GetComponent<TextMeshProUGUI>().text = (data.criticalLevel).ToString();
        Singleton.Instance.statCriticalButtonUpCostTmpCost.GetComponent<TextMeshProUGUI>().text = (data.criticalLevel * 50f).ToString();

        Singleton.Instance.statDefenseTmpLevel.GetComponent<TextMeshProUGUI>().text = "Lv." + data.defenseLevel.ToString();
        Singleton.Instance.statDefenseTmpValue.GetComponent<TextMeshProUGUI>().text = (data.defenseLevel * 5f).ToString();
        Singleton.Instance.statDefenseButtonUpCostTmpCost.GetComponent<TextMeshProUGUI>().text = (data.defenseLevel * 50f).ToString();

        Singleton.Instance.statHealthTmpLevel.GetComponent<TextMeshProUGUI>().text = "Lv." + data.healthLevel.ToString();
        Singleton.Instance.statHealthTmpValue.GetComponent<TextMeshProUGUI>().text = (data.healthLevel * 10f).ToString();
        Singleton.Instance.statHealthButtonUpCostTmpCost.GetComponent<TextMeshProUGUI>().text = (data.healthLevel * 50f).ToString();

    }
}
