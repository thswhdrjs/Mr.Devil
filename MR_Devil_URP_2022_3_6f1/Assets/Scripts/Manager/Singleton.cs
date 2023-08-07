using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static MonoBehaviour instance = null;

    public static T Instance { get { return (T)instance; } }

    protected virtual void Awake()
    {
        if (instance == null)
            instance = this;
        else if (!instance == this)
            DestroyImmediate(gameObject);
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }
}

public class Singleton
{
    private static Singleton instance;

    public static Singleton Instance
    {
        get
        {
            if (null == instance)
                instance = new Singleton();

            return instance;
        }
        set { instance = value; }
    }

    public GameObject camera;

    public GameObject canvas;
    public GameObject level,
                        levelTmpLevel;
    public GameObject coin,
                        coinTmpCoin;
    public GameObject gem,
                        gemTmpCoin;
    public GameObject setting,
                        settingButtonSetting;
    public GameObject skill,
                        skillButtonSkiilName;
    public GameObject stat,
                        statAttack,
                            statAttackTmpLevel,
                            statAttackTmpValue,
                            statAttackButtonUp,
                        statSpeed,
                            statSpeedTmpLevel,
                            statSpeedTmpValue,
                            statSpeedButtonUp,
                        statCritical,
                            statCriticalTmpLevel,
                            statCriticalTmpValue,
                            statCriticalButtonUp,
                        statDefense,
                            statDefenseTmpLevel,
                            statDefenseTmpValue,
                            statDefenseButtonUp,
                        statHealth,
                            statHealthTmpLevel,
                            statHealthTmpValue,
                            statHealthButtonUp;
    public GameObject contents,
                        contentsButtonDevil,
                        contentsButtonCoworker,
                        contentsButtonShop;

    public Singleton()
    {
        camera = GameObject.Find("Main Camera");

        canvas = GameObject.Find("Canvas");

        #region Level

        level = canvas.transform.Find("Level").gameObject;
        levelTmpLevel = level.transform.Find("Text (TMP)_Level").gameObject;

        #endregion

        #region Coin

        coin = canvas.transform.Find("Coin").gameObject;
            coinTmpCoin = coin.transform.Find("Text (TMP)_Coin").gameObject;

        #endregion

        #region Gem

        gem = canvas.transform.Find("Gem").gameObject;
            gemTmpCoin = gem.transform.Find("Text (TMP)_Gem").gameObject;

        #endregion

        #region Setting

        setting = canvas.transform.Find("Setting").gameObject;
        settingButtonSetting = setting.transform.Find("Button_Setting").gameObject;

        #endregion

        #region Skill

        skill = canvas.transform.Find("Skill").gameObject;
            skillButtonSkiilName = skill.transform.Find("Button_SkillName").gameObject;

        #endregion

        #region Stat

        stat = canvas.transform.Find("Stat").gameObject;

        #region Attack

        statAttack = stat.transform.Find("Attack").gameObject;
        statAttackTmpLevel = statAttack.transform.Find("Text (TMP)_Level").gameObject;
        statAttackTmpValue = statAttack.transform.Find("Text (TMP)_Value").gameObject;
        statAttackButtonUp = statAttack.transform.Find("Button_Up").gameObject;

        #endregion

        #region Spped

        statSpeed = stat.transform.Find("Speed").gameObject;
        statSpeedTmpLevel = statSpeed.transform.Find("Text (TMP)_Level").gameObject;
        statSpeedTmpValue = statSpeed.transform.Find("Text (TMP)_Value").gameObject;
        statSpeedButtonUp = statSpeed.transform.Find("Button_Up").gameObject;

        #endregion

        #region Critical

        statCritical = stat.transform.Find("Critical").gameObject;
        statCriticalTmpLevel = statCritical.transform.Find("Text (TMP)_Level").gameObject;
        statCriticalTmpValue = statCritical.transform.Find("Text (TMP)_Value").gameObject;
        statCriticalButtonUp = statCritical.transform.Find("Button_Up").gameObject;

        #endregion

        #region Defense

        statDefense = stat.transform.Find("Defense").gameObject;
        statDefenseTmpLevel = statDefense.transform.Find("Text (TMP)_Level").gameObject;
        statDefenseTmpValue = statDefense.transform.Find("Text (TMP)_Value").gameObject;
        statDefenseButtonUp = statDefense.transform.Find("Button_Up").gameObject;

        #endregion

        #region Health

        statHealth = stat.transform.Find("Health").gameObject;
        statHealthTmpLevel = statHealth.transform.Find("Text (TMP)_Level").gameObject;
        statHealthTmpValue = statHealth.transform.Find("Text (TMP)_Value").gameObject;
        statHealthButtonUp = statHealth.transform.Find("Button_Up").gameObject;

        #endregion

        #endregion

        #region Contents

        contents = canvas.transform.Find("Contents").gameObject;
        contentsButtonDevil = contents.transform.Find("Button_Devil").gameObject;
        contentsButtonCoworker = contents.transform.Find("Button_Coworker").gameObject;
        contentsButtonShop = contents.transform.Find("Button_Shop").gameObject;

        #endregion
    }
}