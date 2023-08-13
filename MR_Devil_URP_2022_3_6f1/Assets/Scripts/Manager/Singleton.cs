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
                        gemTmpGem;
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
    public GameObject settings,
                        settingsButtonSound,
                        settingsButtonMusic,
                        settingsButtonNotification,
                        settingsButtonFacebook,
                        settingsButtonTwitter,
                        settingsButtonGoogle,
                        settingsButtonClose;
    public GameObject devil,
                        devilButtonLevel,
                        devilButtonSkill,
                        devilButtonChange,
                        devilButtonClose;
    public GameObject coworker,
                        coworkerInfo,
                            coworkerInfoButtonInfo,
                            coworkerInfoSpec,
                                coworkerInfoSpecTmpName,
                                coworkerInfoSpecTmpLevel,
                                coworkerInfoSpecTmpEffect,
                                coworkerInfoSpecTmpSkill,
                        coworkerButtonCall,
                        coworkerButtonUpgrade,
                        coworkerButtonClose;
    public GameObject shop,
                        shopCoin,
                            shopCoinTab,
                                shopCoinTabButtonCoin,
                                shopCoinTabButtonGem,
                                shopCoinTabButtonLife,
                            shopCoinButtonGem,
                            shopCoinButtonGem2,
                            shopCoinButtonGem3,
                            shopCoinButtonGem4,
                        shopGem,
                            shopGemTab,
                                shopGemTabButtonCoin,
                                shopGemTabButtonGem,
                                shopGemTabButtonLife,
                            shopGemButtonUS,
                            shopGemButtonUS2,
                            shopGemButtonUS3,
                            shopGemButtonUS4,
                        shopLife,
                            shopLifeTab,
                                shopLifeTabButtonCoin,
                                shopLifeTabButtonGem,
                                shopLifeTabButtonLife,
                            shopLifeButtonUS,
                            shopLifeButtonUS2,
                            shopLifeButtonUS3,
                            shopLifeButtonUS4,
                        shopButtonClose;

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

        #region Money

        coin = canvasMain.transform.Find("Coin").gameObject;
        coinTmpCoin = coin.transform.Find("Text (TMP)_Coin").gameObject;

        gem = canvasMain.transform.Find("Gem").gameObject;
        gemTmpGem = gem.transform.Find("Text (TMP)_Gem").gameObject;

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

        #region Settings

        settings = canvasPopup.transform.Find("Settings").gameObject;
        settingsButtonSound = settings.transform.Find("Button_Sound").gameObject;
        settingsButtonMusic = settings.transform.Find("Button_Music").gameObject;
        settingsButtonNotification = settings.transform.Find("Button_Notification").gameObject;
        settingsButtonFacebook = settings.transform.Find("Button_Facebook").gameObject;
        settingsButtonTwitter = settings.transform.Find("Button_Twitter").gameObject;
        settingsButtonGoogle = settings.transform.Find("Button_Google").gameObject;
        settingsButtonClose = settings.transform.Find("Button_Close").gameObject;

        #endregion

        #region Devil

        devil = canvasPopup.transform.Find("Devil").gameObject;
        devilButtonLevel = devil.transform.Find("Button_Level").gameObject;
        devilButtonSkill = devil.transform.Find("Button_Skill").gameObject;
        devilButtonChange = devil.transform.Find("Button_Change").gameObject;
        devilButtonClose = devil.transform.Find("Button_Close").gameObject;

        #endregion

        #region Coworker

        coworker = canvasPopup.transform.Find("Coworker").gameObject;
        coworkerInfo = coworker.transform.Find("Info").gameObject;
        coworkerInfoButtonInfo = coworkerInfo.transform.Find("Button_Info").gameObject;

        coworkerInfoSpec = coworkerInfo.transform.Find("Spec").gameObject;
        coworkerInfoSpecTmpName = coworkerInfoSpec.transform.Find("Text (TMP)_Name").gameObject;
        coworkerInfoSpecTmpLevel = coworkerInfoSpec.transform.Find("Text (TMP)_Level").gameObject;
        coworkerInfoSpecTmpEffect = coworkerInfoSpec.transform.Find("Text (TMP)_Effect").gameObject;
        coworkerInfoSpecTmpSkill = coworkerInfoSpec.transform.Find("Text (TMP)_Skill").gameObject;

        coworkerButtonCall = coworker.transform.Find("Button_Call").gameObject;
        coworkerButtonUpgrade = coworker.transform.Find("Button_Upgrade").gameObject;
        coworkerButtonClose = coworker.transform.Find("Button_Close").gameObject;

        #endregion

        #region Shop

        shop = canvasPopup.transform.Find("Shop").gameObject;
        shopCoin = shop.transform.Find("Coin").gameObject;
        shopCoinTab = shopCoin.transform.Find("Tab").gameObject;
        shopCoinTabButtonCoin = shopCoinTab.transform.Find("Button_Coin").gameObject;
        shopCoinTabButtonGem = shopCoinTab.transform.Find("Button_Gem").gameObject;
        shopCoinTabButtonLife = shopCoinTab.transform.Find("Button_Life").gameObject;

        shopCoinButtonGem = shopCoin.transform.Find("Button_Gem").gameObject;
        shopCoinButtonGem2 = shopCoin.transform.Find("Button_Gem2").gameObject;
        shopCoinButtonGem3 = shopCoin.transform.Find("Button_Gem3").gameObject;
        shopCoinButtonGem4 = shopCoin.transform.Find("Button_Gem4").gameObject;

        shopGem = shop.transform.Find("Gem").gameObject;
        shopGemTab = shopGem.transform.Find("Tab").gameObject;
        shopGemTabButtonCoin = shopGemTab.transform.Find("Button_Coin").gameObject;
        shopGemTabButtonGem = shopGemTab.transform.Find("Button_Gem").gameObject;
        shopGemTabButtonLife = shopGemTab.transform.Find("Button_Life").gameObject;

        shopGemButtonUS = shopGem.transform.Find("Button_US").gameObject;
        shopGemButtonUS2 = shopGem.transform.Find("Button_US2").gameObject;
        shopGemButtonUS3 = shopGem.transform.Find("Button_US3").gameObject;
        shopGemButtonUS4 = shopGem.transform.Find("Button_US4").gameObject;

        shopLife = shop.transform.Find("Life").gameObject;
        shopLifeTab = shopLife.transform.Find("Tab").gameObject;
        shopLifeTabButtonCoin = shopLifeTab.transform.Find("Button_Coin").gameObject;
        shopLifeTabButtonGem = shopLifeTab.transform.Find("Button_Gem").gameObject;
        shopLifeTabButtonLife = shopLifeTab.transform.Find("Button_Life").gameObject;

        shopLifeButtonUS = shopLife.transform.Find("Button_US").gameObject;
        shopLifeButtonUS2 = shopLife.transform.Find("Button_US2").gameObject;
        shopLifeButtonUS3 = shopLife.transform.Find("Button_US3").gameObject;
        shopLifeButtonUS4 = shopLife.transform.Find("Button_US4").gameObject;

        shopButtonClose = shop.transform.Find("Button_Close").gameObject;

        #endregion

        #endregion
    }
}
