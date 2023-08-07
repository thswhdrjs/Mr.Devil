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

    #region Canvas_Main

    public GameObject canvasMain;
    public GameObject background,
                        backgroundPlay,
                            backgroundImageFrontBackground,
                            backgroundImageRearBackground;
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
                        statImageAttack,
                            statAttackImageAttack,
                            statAttackTmpLevel,
                            statAttackTmpValue,
                            statAttackButtonUp,
                                statAttackButtonUpCost,
                                statAttackButtonUpCostTmpCost,
                        statImageSpeed,
                            statSpeedImageSpeed,
                            statSpeedTmpLevel,
                            statSpeedTmpValue,
                            statSpeedButtonUp,
                                statSpeedButtonUpCost,
                                statSpeedButtonUpCostTmpCost,
                        statImageCritical,
                            statCriticalImageCritical,
                            statCriticalTmpLevel,
                            statCriticalTmpValue,
                            statCriticalButtonUp,
                                statCriticalButtonUpCost,
                                statCriticalButtonUpCostTmpCost,
                        statImageDefense,
                            statDefenseImageDefense,
                            statDefenseTmpLevel,
                            statDefenseTmpValue,
                            statDefenseButtonUp,
                                statDefenseButtonUpCost,
                                statDefenseButtonUpCostTmpCost,
                        statImageHealth,
                            statHealthImageHealth,
                            statHealthTmpLevel,
                            statHealthTmpValue,
                            statHealthButtonUp,
                                statHealthButtonUpCost,
                                statHealthButtonUpCostTmpCost;
    public GameObject contents,
                        contentsButtonDevil,
                        contentsButtonCoworker,
                        contentsButtonShop;
    public GameObject loading,
                        loadingImageLoading;

    #endregion

    #region Canvas_Popup

    public GameObject canvasPopup;

    #endregion

    public Singleton()
    {
        camera = GameObject.Find("Main Camera");

        #region Canvas_Main

        canvasMain = GameObject.Find("Canvas_Main");

        #region Background

        background = canvasMain.transform.Find("Background").gameObject;
        backgroundPlay = background.transform.Find("Play").gameObject;
        backgroundImageFrontBackground = backgroundPlay.transform.Find("Image_FrontBackground").gameObject;
        backgroundImageRearBackground = backgroundPlay.transform.Find("Image_RearBackground").gameObject;

        #endregion

        #region Level

        level = canvasMain.transform.Find("Level").gameObject;
        levelTmpLevel = level.transform.Find("Text (TMP)_Level").gameObject;

        #endregion

        #region Coin

        coin = canvasMain.transform.Find("Coin").gameObject;
            coinTmpCoin = coin.transform.Find("Text (TMP)_Coin").gameObject;

        #endregion

        #region Gem

        gem = canvasMain.transform.Find("Gem").gameObject;
            gemTmpCoin = gem.transform.Find("Text (TMP)_Gem").gameObject;

        #endregion

        #region Setting

        setting = canvasMain.transform.Find("Setting").gameObject;
        settingButtonSetting = setting.transform.Find("Button_Setting").gameObject;

        #endregion

        #region Skill

        skill = canvasMain.transform.Find("Skill").gameObject;
            skillButtonSkiilName = skill.transform.Find("Button_SkillName").gameObject;

        #endregion

        #region Stat

        stat = canvasMain.transform.Find("Stat").gameObject;

        #region Attack

        statImageAttack = stat.transform.Find("Image_AttackFrame").gameObject;
        statAttackImageAttack = statImageAttack.transform.Find("Image_Attack").gameObject;
        statAttackTmpLevel = statAttackImageAttack.transform.Find("Text (TMP)_Level").gameObject;

        statAttackTmpValue = statImageAttack.transform.Find("Text (TMP)_Value").gameObject;
        statAttackButtonUp = statImageAttack.transform.Find("Button_Up").gameObject;
        statAttackButtonUpCost = statAttackButtonUp.transform.Find("Cost").gameObject;
        statAttackButtonUpCostTmpCost = statAttackButtonUpCost.transform.Find("Text (TMP)_Cost").gameObject;

        #endregion

        #region Speed

        statImageSpeed = stat.transform.Find("Image_SpeedFrame").gameObject;
        statSpeedImageSpeed = statImageSpeed.transform.Find("Image_Speed").gameObject;
        statSpeedTmpLevel = statSpeedImageSpeed.transform.Find("Text (TMP)_Level").gameObject;

        statSpeedTmpValue = statImageSpeed.transform.Find("Text (TMP)_Value").gameObject;
        statSpeedButtonUp = statImageSpeed.transform.Find("Button_Up").gameObject;
        statSpeedButtonUpCost = statSpeedButtonUp.transform.Find("Cost").gameObject;
        statSpeedButtonUpCostTmpCost = statSpeedButtonUpCost.transform.Find("Text (TMP)_Cost").gameObject;

        #endregion

        #region Critical

        statImageCritical = stat.transform.Find("Image_CriticalFrame").gameObject;
        statCriticalImageCritical = statImageCritical.transform.Find("Image_Critical").gameObject;
        statCriticalTmpLevel = statCriticalImageCritical.transform.Find("Text (TMP)_Level").gameObject;

        statCriticalTmpValue = statImageCritical.transform.Find("Text (TMP)_Value").gameObject;
        statCriticalButtonUp = statImageCritical.transform.Find("Button_Up").gameObject;
        statCriticalButtonUpCost = statCriticalButtonUp.transform.Find("Cost").gameObject;
        statCriticalButtonUpCostTmpCost = statCriticalButtonUpCost.transform.Find("Text (TMP)_Cost").gameObject;

        #endregion

        #region Defense

        statImageDefense = stat.transform.Find("Image_DefenseFrame").gameObject;
        statDefenseImageDefense = statImageDefense.transform.Find("Image_Defense").gameObject;
        statDefenseTmpLevel = statDefenseImageDefense.transform.Find("Text (TMP)_Level").gameObject;

        statDefenseTmpValue = statImageDefense.transform.Find("Text (TMP)_Value").gameObject;
        statDefenseButtonUp = statImageDefense.transform.Find("Button_Up").gameObject;
        statDefenseButtonUpCost = statDefenseButtonUp.transform.Find("Cost").gameObject;
        statDefenseButtonUpCostTmpCost = statDefenseButtonUpCost.transform.Find("Text (TMP)_Cost").gameObject;

        #endregion

        #region Health

        statImageHealth = stat.transform.Find("Image_HealthFrame").gameObject;
        statHealthImageHealth = statImageHealth.transform.Find("Image_Health").gameObject;
        statHealthTmpLevel = statHealthImageHealth.transform.Find("Text (TMP)_Level").gameObject;

        statHealthTmpValue = statImageHealth.transform.Find("Text (TMP)_Value").gameObject;
        statHealthButtonUp = statImageHealth.transform.Find("Button_Up").gameObject;
        statHealthButtonUpCost = statHealthButtonUp.transform.Find("Cost").gameObject;
        statHealthButtonUpCostTmpCost = statHealthButtonUpCost.transform.Find("Text (TMP)_Cost").gameObject;

        #endregion

        #endregion

        #region Contents

        contents = canvasMain.transform.Find("Contents").gameObject;
        contentsButtonDevil = contents.transform.Find("Button_Devil").gameObject;
        contentsButtonCoworker = contents.transform.Find("Button_Coworker").gameObject;
        contentsButtonShop = contents.transform.Find("Button_Shop").gameObject;

        #endregion

        #region Loading

        loading = canvasMain.transform.Find("Loading").gameObject;
        loadingImageLoading = loading.transform.Find("Image_Loading").gameObject;

        #endregion

        #endregion

        #region Canvas_Popup

        canvasPopup = GameObject.Find("Canvas_Popup");

        #endregion
    }
}