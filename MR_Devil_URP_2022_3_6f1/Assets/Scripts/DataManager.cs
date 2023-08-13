using System;
using TMPro;
using UnityEngine;

[Serializable]
public class UserData
{
    public string nickname;

    public int sound,
               music,
               notification;

    public int level;

    public int coin,
               gem;

    public int attackLevel,
               speedLevel,
               criticalLevel,
               defenseLevel,
               healthLevel;

    public UserData()
    {
        nickname = string.Empty;

        sound = 0;
        music = 0;
        notification = 0;

        level = 0;

        coin = 0;
        gem = 0;

        attackLevel = 0;
        speedLevel = 0;
        criticalLevel = 0;
        defenseLevel = 0;
        healthLevel = 0;
    }

    public UserData(string _nickname, int _sound, int _music, int _notification, int _level, int _coin, int _gem, int _attackLevel, int _speedLevel, int _criticalLevel, int _defenseLevel, int _healthLevel)
    {
        nickname = _nickname;

        sound = _sound;
        music = _music;
        notification = _notification;

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

    #region Save

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

    public void SaveData(string nickname, int sound, int music, int notification, int level, int coin, int gem, int attackLevel, int speedLevel, int criticalLevel, int defenseLevel, int healthLevel)
    {
        PlayerPrefs.SetString("NickName", nickname);

        PlayerPrefs.SetInt("Sound", sound);
        PlayerPrefs.SetInt("Music", music);
        PlayerPrefs.SetInt("Notification", notification);

        PlayerPrefs.SetInt("Level", level);

        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.SetInt("Gem", gem);

        PlayerPrefs.SetInt("AttackLevel", attackLevel);
        PlayerPrefs.SetInt("SpeedLevel", speedLevel);
        PlayerPrefs.SetInt("CriticalLevel", criticalLevel);
        PlayerPrefs.SetInt("DefenseLevel", defenseLevel);
        PlayerPrefs.SetInt("HealthLevel", healthLevel);
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("NickName", data.nickname);

        PlayerPrefs.SetInt("Sound", data.sound);
        PlayerPrefs.SetInt("Music", data.music);
        PlayerPrefs.SetInt("Notification", data.notification);

        PlayerPrefs.SetInt("Level", data.level);

        PlayerPrefs.SetInt("Coin", data.coin);
        PlayerPrefs.SetInt("Gem", data.gem);

        PlayerPrefs.SetInt("AttackLevel", data.attackLevel);
        PlayerPrefs.SetInt("SpeedLevel", data.speedLevel);
        PlayerPrefs.SetInt("CriticalLevel", data.criticalLevel);
        PlayerPrefs.SetInt("DefenseLevel", data.defenseLevel);
        PlayerPrefs.SetInt("HealthLevel", data.healthLevel);
    }

    #endregion

    #region Load

    public int LoadIntData(string key)
    {
        if (!PlayerPrefs.HasKey(key))
            return 0;

        return PlayerPrefs.GetInt(key);
    }

    public float LoadFloatData(string key)
    {
        if (!PlayerPrefs.HasKey(key))
            return 0f;

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

        int sound = LoadIntData("Sound");
        int music = LoadIntData("Music");
        int notification = LoadIntData("Notification");

        int level = LoadIntData("Level");

        int coin = LoadIntData("Coin");
        int gem = LoadIntData("Gem");

        int attackLevel = LoadIntData("AttackLevel") == 0 ? 1 : LoadIntData("AttackLevel");
        int speedLevel = LoadIntData("SpeedLevel") == 0 ? 1 : LoadIntData("SpeedLevel");
        int criticalLevel = LoadIntData("CriticalLevel") == 0 ? 1 : LoadIntData("CriticalLevel");
        int defenseLevel = LoadIntData("DefenseLevel") == 0 ? 1 : LoadIntData("DefenseLevel");
        int healthLevel = LoadIntData("HealthLevel") == 0 ? 1 : LoadIntData("HealthLevel");

        data = new UserData(nickname, sound, music, notification, level, coin, gem, attackLevel, speedLevel, criticalLevel, defenseLevel, healthLevel);
    }

    #endregion

    public void UpdateData()
    {
        LoadData();

        //Singleton.Instance.nickname.GetComponent<TextMeshProUGUI>().text = data.nickname;

        Singleton.Instance.settingsButtonSound.transform.GetChild(0).gameObject.SetActive(data.sound == 0);
        Singleton.Instance.settingsButtonSound.transform.GetChild(1).gameObject.SetActive(data.sound == 1);

        Singleton.Instance.settingsButtonMusic.transform.GetChild(0).gameObject.SetActive(data.music == 0);
        Singleton.Instance.settingsButtonMusic.transform.GetChild(1).gameObject.SetActive(data.music == 1);

        Singleton.Instance.settingsButtonNotification.transform.GetChild(0).gameObject.SetActive(data.notification == 0);
        Singleton.Instance.settingsButtonNotification.transform.GetChild(1).gameObject.SetActive(data.notification == 1);

        Singleton.Instance.levelTmpLevel.GetComponent<TextMeshProUGUI>().text = data.level.ToString();

        Singleton.Instance.coinTmpCoin.GetComponent<TextMeshProUGUI>().text = data.coin.ToString();
        Singleton.Instance.gemTmpGem.GetComponent<TextMeshProUGUI>().text = data.gem.ToString();

        Singleton.Instance.statAttackTmpLevel.GetComponent<TextMeshProUGUI>().text = "Lv." + data.attackLevel.ToString();
        Singleton.Instance.statAttackTmpValue.GetComponent<TextMeshProUGUI>().text = (data.attackLevel * 5f).ToString();
        Singleton.Instance.statAttackButtonUpCostTmpCost.GetComponent<TextMeshProUGUI>().text = (data.attackLevel * 50f).ToString();

        Singleton.Instance.statSpeedTmpLevel.GetComponent<TextMeshProUGUI>().text = "Lv." + data.speedLevel.ToString();
        Singleton.Instance.statSpeedTmpValue.GetComponent<TextMeshProUGUI>().text = (0.999f + data.speedLevel * 0.001f).ToString("F3");
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
