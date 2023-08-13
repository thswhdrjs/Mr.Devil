using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    private GameObject[] buttonObj;

    private void Start()
    {
        AddButtonEvent();
        AddDropdownEvent();
        AddSliderEvent();
        AddEventTriggerEvent();
    }

    #region Event

    // Button OnClick Add
    private void AddButtonOnClickEvent(GameObject obj, UnityAction func)
    {
        obj.GetComponent<Button>().onClick.AddListener(func);
    }

    // Button OnClick Remove
    private void RemoveButtonOnClickEvent(GameObject obj)
    {
        obj.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    // Button OnClick Remove
    private void RemoveButtonOnClickEvent(GameObject obj, UnityAction func)
    {
        obj.GetComponent<Button>().onClick.RemoveListener(func);
    }

    // Slider OnValueChanged Add
    private void AddSliderOnValueChangedEvent(GameObject obj, UnityAction<float> func)
    {
        obj.GetComponent<Slider>().onValueChanged.AddListener(func);
    }

    // EventTrigger Entity Add
    private void AddEventTriggerEntityEvent(GameObject evnetObj, EventTriggerType type, UnityAction func)
    {
        EventTrigger trigger = evnetObj.GetComponent<EventTrigger>() == null ? evnetObj.AddComponent<EventTrigger>() : evnetObj.GetComponent<EventTrigger>();
        EventTrigger.Entry entity = new EventTrigger.Entry();
        entity.eventID = type;
        entity.callback.AddListener((data) => func());
        trigger.triggers.Add(entity);
    }

    #endregion

    #region Add Event

    // Add Button Event
    private void AddButtonEvent()
    {
        // Setting
        AddButtonOnClickEvent(Singleton.Instance.settingButtonSetting, ClickedSetting);

        // Skill
        AddButtonOnClickEvent(Singleton.Instance.skillButtonSkiilName, ClickedSkillName);

        // Stat
        AddButtonOnClickEvent(Singleton.Instance.statAttackButtonUp, ClickedStatAttackUp);
        AddButtonOnClickEvent(Singleton.Instance.statSpeedButtonUp, ClickedStatSpeedUp);
        AddButtonOnClickEvent(Singleton.Instance.statCriticalButtonUp, ClickedStatCriticalUp);
        AddButtonOnClickEvent(Singleton.Instance.statDefenseButtonUp, ClickedStatDefenseUp);
        AddButtonOnClickEvent(Singleton.Instance.statHealthButtonUp, ClickedStatHealthUp);

        // Contents
        AddButtonOnClickEvent(Singleton.Instance.contentsButtonDevil, ClickedContentsDevil);
        AddButtonOnClickEvent(Singleton.Instance.contentsButtonCoworker, ClickedContentsCoworker);
        AddButtonOnClickEvent(Singleton.Instance.contentsButtonShop, ClickedContentsShop);

        //Popup Settings
        AddButtonOnClickEvent(Singleton.Instance.settingsButtonSound, ClickedSettingsPopupSound);
        AddButtonOnClickEvent(Singleton.Instance.settingsButtonMusic, ClickedSettingsPopupMusic);
        AddButtonOnClickEvent(Singleton.Instance.settingsButtonNotification, ClickedSettingsPopupNotification);
        AddButtonOnClickEvent(Singleton.Instance.settingsButtonFacebook, ClickedSettingsPopupFacebook);
        AddButtonOnClickEvent(Singleton.Instance.settingsButtonTwitter, ClickedSettingsPopupTwitter);
        AddButtonOnClickEvent(Singleton.Instance.settingsButtonGoogle, ClickedSettingsPopupGoogle);
        AddButtonOnClickEvent(Singleton.Instance.settingsButtonClose, ClickedSettingsPopupClose);

        //Popup Devil
        AddButtonOnClickEvent(Singleton.Instance.devilButtonLevel, ClickedDevilPopupLevel);
        AddButtonOnClickEvent(Singleton.Instance.devilButtonSkill, ClickedDevilPopupSkill);
        AddButtonOnClickEvent(Singleton.Instance.devilButtonChange, ClickedDevilPopupChange);
        AddButtonOnClickEvent(Singleton.Instance.devilButtonClose, ClickedDevilPopupClose);

        //Popup Coworker
        AddButtonOnClickEvent(Singleton.Instance.coworkerInfoButtonInfo, ClickedCoworkerPopupInfo);
        AddButtonOnClickEvent(Singleton.Instance.coworkerButtonCall, ClickedCoworkerPopupCall);
        AddButtonOnClickEvent(Singleton.Instance.coworkerButtonUpgrade, ClickedCoworkerPopupUpgrade);
        AddButtonOnClickEvent(Singleton.Instance.coworkerButtonClose, ClickedCoworkerPopupClose);

        //Popup Shop
        #region Coin

        AddButtonOnClickEvent(Singleton.Instance.shopCoinTabButtonCoin, ClickedShopPopupCoinTabCoin);
        AddButtonOnClickEvent(Singleton.Instance.shopCoinTabButtonGem, ClickedShopPopupCoinTabGem);
        AddButtonOnClickEvent(Singleton.Instance.shopCoinTabButtonLife, ClickedShopPopupCoinTabLife);

        AddButtonOnClickEvent(Singleton.Instance.shopCoinButtonGem, ClickedShopPopupCoinGem);
        AddButtonOnClickEvent(Singleton.Instance.shopCoinButtonGem2, ClickedShopPopupCoinGem2);
        AddButtonOnClickEvent(Singleton.Instance.shopCoinButtonGem3, ClickedShopPopupCoinGem3);
        AddButtonOnClickEvent(Singleton.Instance.shopCoinButtonGem4, ClickedShopPopupCoinGem4);

        #endregion

        #region Gem

        AddButtonOnClickEvent(Singleton.Instance.shopGemTabButtonCoin, ClickedShopPopupGemTabCoin);
        AddButtonOnClickEvent(Singleton.Instance.shopGemTabButtonGem, ClickedShopPopupGemTabGem);
        AddButtonOnClickEvent(Singleton.Instance.shopGemTabButtonLife, ClickedShopPopupGemTabLife);

        AddButtonOnClickEvent(Singleton.Instance.shopGemButtonUS, ClickedShopPopupGemUS);
        AddButtonOnClickEvent(Singleton.Instance.shopGemButtonUS2, ClickedShopPopupGemUS2);
        AddButtonOnClickEvent(Singleton.Instance.shopGemButtonUS3, ClickedShopPopupGemUS3);
        AddButtonOnClickEvent(Singleton.Instance.shopGemButtonUS4, ClickedShopPopupGemUS4);

        #endregion

        #region Life

        AddButtonOnClickEvent(Singleton.Instance.shopLifeTabButtonCoin, ClickedShopPopupLifeTabCoin);
        AddButtonOnClickEvent(Singleton.Instance.shopLifeTabButtonGem, ClickedShopPopupLifeTabGem);
        AddButtonOnClickEvent(Singleton.Instance.shopLifeTabButtonLife, ClickedShopPopupLifeTabLife);

        AddButtonOnClickEvent(Singleton.Instance.shopLifeButtonUS, ClickedShopPopupLifeUS);
        AddButtonOnClickEvent(Singleton.Instance.shopLifeButtonUS2, ClickedShopPopupLifeUS2);
        AddButtonOnClickEvent(Singleton.Instance.shopLifeButtonUS3, ClickedShopPopupLifeUS3);
        AddButtonOnClickEvent(Singleton.Instance.shopLifeButtonUS4, ClickedShopPopupLifeUS4);

        #endregion

        AddButtonOnClickEvent(Singleton.Instance.shopButtonClose, ClickedShopPopupClose);
    }

    // Add Dropdown Event
    private void AddDropdownEvent()
    {
        //Singleton.Instance.settingCalibrationDropdownOriginal.GetComponent<TMP_Dropdown>().onValueChanged.AddListener(ChangedSettingOriginalContents);
    }

    // Add Slider Event
    private void AddSliderEvent()
    {
        //AddSliderOnValueChangedEvent(Singleton.Instance.bottomPlayPlaybarSliderTimebar, ClickedBottomPlayTimebar);
    }

    // Add EventTrigger Event
    private void AddEventTriggerEvent()
    {
        //AddEventTriggerEntityEvent(Singleton.Instance.menuLightColorImageColorPicker, EventTriggerType.Drag, ColorPicker);
        //AddEventTriggerEntityEvent(Singleton.Instance.menuLightColorImageColorPicker, EventTriggerType.PointerDown, ColorPicker);
    }

    #endregion

    private void SetSprite(Sprite[] sprites, GameObject obj, int order)
    {
        Image image = obj.GetComponent<Image>();
        image.sprite = sprites[order];
    }

    private void ColorPicker(GameObject currColorObj, GameObject colorPickerObj)
    {
        Image image = currColorObj.GetComponent<Image>();
        Vector2 size = new Vector2(colorPickerObj.GetComponent<RectTransform>().rect.width, colorPickerObj.GetComponent<RectTransform>().rect.height);

        Vector2 circlePalettePosition = colorPickerObj.transform.position;
        Vector2 pickerPosition = Input.mousePosition;

        Vector2 position = pickerPosition - circlePalettePosition + size * 0.5f;
        Vector2 normalized = new Vector2(position.x / colorPickerObj.GetComponent<RectTransform>().rect.width, position.y / colorPickerObj.GetComponent<RectTransform>().rect.height);

        Texture2D texture = colorPickerObj.GetComponent<Image>().mainTexture as Texture2D;
        Color circularSelectedColor = texture.GetPixelBilinear(normalized.x, normalized.y);

        image.color = circularSelectedColor;
    }

    private void ClickedPlaybar(float value)
    {
        if (!Input.GetMouseButton(0))
            return;

        //GraphicRaycaster raycaster = Singleton.Instance.canvasBottom.GetComponent<GraphicRaycaster>();
        //EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        //PointerEventData pointerEventData = new PointerEventData(eventSystem);
        //pointerEventData.position = Input.mousePosition;

        //List<RaycastResult> results = new List<RaycastResult>();
        //raycaster.Raycast(pointerEventData, results);

        //if (results.Count == 0 || !results[0].gameObject.name.Equals("Handle"))
        //    return;

        //float second = value;

        //for (int i = 0; i < Singleton.Instance.bottomPlayStepButtonSteps.Length; i++)
        //{
        //    if (Singleton.Instance.bottomPlayStepButtonSteps[i].transform.GetChild(0).GetComponent<Image>().sprite == spriteStep[1])
        //    {
        //        step = i;
        //        break;
        //    }
        //}

        //switch (step)
        //{
        //    case 0:
        //        {
        //            second += 0.5f;
        //            break;
        //        }
        //    case 1:
        //        {
        //            second += 180.5f;
        //            break;
        //        }
        //    case 2:
        //        {
        //            second += 304.8f;
        //            break;
        //        }
        //    case 3:
        //        {
        //            second += 345f;
        //            break;
        //        }
        //    case 4:
        //        {
        //            second += 385.3f;
        //            break;
        //        }
        //    case 5:
        //        {
        //            second += 453.6f;
        //            break;
        //        }
        //    case 6:
        //        {
        //            second += 612.4f;
        //            break;
        //        }
        //}

        //PhotonManager.Instance.photonView.RPC("TimebarControl", RpcTarget.All, second);
    }

    private void ClickedQuit()
    {
        FunctionManager.Instance.InitChildButton(buttonObj, false);

        //StartCoroutine(FunctionManager.Instance.Fade(() => Application.Quit()));
    }

    #region Main

    #region Setting

    private void ClickedSetting()
    {
        Singleton.Instance.settings.SetActive(true);
    }

    #endregion

    #region Skill

    private void ClickedSkillName()
    {

    }

    #endregion

    #region Stat

    private void Upgrade(GameObject statLevelObj, GameObject statValueObj, GameObject statCostObj, out int level)
    {
        int coin = int.Parse(Singleton.Instance.coinTmpCoin.GetComponent<TextMeshProUGUI>().text);
        int cost = int.Parse(statCostObj.GetComponent<TextMeshProUGUI>().text);

        if (coin < cost)
        {
            level = -1;
            return;
        }

        Singleton.Instance.coinTmpCoin.GetComponent<TextMeshProUGUI>().text = (coin - cost).ToString();

        level = int.Parse(statLevelObj.GetComponent<TextMeshProUGUI>().text.Split("Lv.")[1]) + 1;
        statLevelObj.GetComponent<TextMeshProUGUI>().text = "Lv." + (level).ToString();
        statValueObj.GetComponent<TextMeshProUGUI>().text = (level * 5f).ToString();
        statCostObj.GetComponent<TextMeshProUGUI>().text = (level * 50f).ToString();
    }

    private void ClickedStatAttackUp()
    {
        Upgrade(Singleton.Instance.statAttackTmpLevel, Singleton.Instance.statAttackTmpValue, Singleton.Instance.statAttackButtonUpCostTmpCost, out int level);

        if (level == -1)
            return;
        
        DataManager.Instance.data.attackLevel = level;
    }

    private void ClickedStatSpeedUp()
    {
        Upgrade(Singleton.Instance.statSpeedTmpLevel, Singleton.Instance.statSpeedTmpValue, Singleton.Instance.statSpeedButtonUpCostTmpCost, out int level);

        if (level == -1)
            return;

        DataManager.Instance.data.speedLevel = level;
        Singleton.Instance.statSpeedTmpValue.GetComponent<TextMeshProUGUI>().text = (0.999f + DataManager.Instance.data.speedLevel * 0.001f).ToString("F3");
    }

    private void ClickedStatCriticalUp()
    {
        Upgrade(Singleton.Instance.statCriticalTmpLevel, Singleton.Instance.statCriticalTmpValue, Singleton.Instance.statCriticalButtonUpCostTmpCost, out int level);

        if (level == -1)
            return;

        DataManager.Instance.data.criticalLevel = level;
    }

    private void ClickedStatDefenseUp()
    {
        Upgrade(Singleton.Instance.statDefenseTmpLevel, Singleton.Instance.statDefenseTmpValue, Singleton.Instance.statDefenseButtonUpCostTmpCost, out int level);

        if (level == -1)
            return;

        DataManager.Instance.data.defenseLevel = level;
    }

    private void ClickedStatHealthUp()
    {
        Upgrade(Singleton.Instance.statHealthTmpLevel, Singleton.Instance.statHealthTmpValue, Singleton.Instance.statHealthButtonUpCostTmpCost, out int level);

        if (level == -1)
            return;

        DataManager.Instance.data.healthLevel = level;
    }

    #endregion

    #region Contents

    private void ClickedContentsDevil()
    {
        Singleton.Instance.devil.SetActive(true);
    }

    private void ClickedContentsCoworker()
    {
        Singleton.Instance.coworker.SetActive(true);
    }

    private void ClickedContentsShop()
    {
        Singleton.Instance.shop.SetActive(true);
        Singleton.Instance.shopCoin.SetActive(true);
        Singleton.Instance.shopGem.SetActive(false);
        Singleton.Instance.shopLife.SetActive(false);
    }

    #endregion

    #endregion

    #region Popup

    #region Settings

    private void SetToogle(GameObject buttonObj, out bool isActive)
    {
        isActive = buttonObj.transform.GetChild(0).gameObject.activeSelf;
        buttonObj.transform.GetChild(0).gameObject.SetActive(!isActive);
        buttonObj.transform.GetChild(1).gameObject.SetActive(isActive);
    }

    private void ClickedSettingsPopupSound()
    {
        SetToogle(Singleton.Instance.settingsButtonSound, out bool isActive);

        DataManager.Instance.data.sound = isActive ? 1 : 0;
    }

    private void ClickedSettingsPopupMusic()
    {
        SetToogle(Singleton.Instance.settingsButtonMusic, out bool isActive);

        DataManager.Instance.data.music = isActive ? 1 : 0;
    }

    private void ClickedSettingsPopupNotification()
    {
        SetToogle(Singleton.Instance.settingsButtonNotification, out bool isActive);

        DataManager.Instance.data.notification = isActive ? 1 : 0;
    }

    private void ClickedSettingsPopupFacebook()
    {

    }

    private void ClickedSettingsPopupTwitter()
    {

    }

    private void ClickedSettingsPopupGoogle()
    {

    }

    private void ClickedSettingsPopupClose()
    {
        Singleton.Instance.settings.SetActive(false);
    }

    #endregion

    #region Devil

    private void ClickedDevilPopupLevel()
    {
        
    }

    private void ClickedDevilPopupSkill()
    {

    }

    private void ClickedDevilPopupChange()
    {

    }

    private void ClickedDevilPopupClose()
    {
        Singleton.Instance.devil.SetActive(false);
    }

    #endregion

    #region Coworker

    private void ClickedCoworkerPopupInfo()
    {

    }

    private void ClickedCoworkerPopupCall()
    {

    }

    private void ClickedCoworkerPopupUpgrade()
    {

    }

    private void ClickedCoworkerPopupClose()
    {
        Singleton.Instance.coworker.SetActive(false);
    }

    #endregion

    #region Shop

    #region Coin

    private void ClickedShopPopupCoinTabCoin()
    {
        Singleton.Instance.shopCoin.SetActive(true);
        Singleton.Instance.shopGem.SetActive(false);
        Singleton.Instance.shopLife.SetActive(false);
    }

    private void ClickedShopPopupCoinTabGem()
    {
        Singleton.Instance.shopCoin.SetActive(false);
        Singleton.Instance.shopGem.SetActive(true);
        Singleton.Instance.shopLife.SetActive(false);
    }

    private void ClickedShopPopupCoinTabLife()
    {
        Singleton.Instance.shopCoin.SetActive(false);
        Singleton.Instance.shopGem.SetActive(false);
        Singleton.Instance.shopLife.SetActive(true);
    }

    private void ClickedShopPopupCoinGem()
    {

    }

    private void ClickedShopPopupCoinGem2()
    {

    }

    private void ClickedShopPopupCoinGem3()
    {

    }

    private void ClickedShopPopupCoinGem4()
    {

    }

    #endregion

    #region Gem

    private void ClickedShopPopupGemTabCoin()
    {
        Singleton.Instance.shopCoin.SetActive(true);
        Singleton.Instance.shopGem.SetActive(false);
        Singleton.Instance.shopLife.SetActive(false);
    }

    private void ClickedShopPopupGemTabGem()
    {
        Singleton.Instance.shopCoin.SetActive(false);
        Singleton.Instance.shopGem.SetActive(true);
        Singleton.Instance.shopLife.SetActive(false);
    }

    private void ClickedShopPopupGemTabLife()
    {
        Singleton.Instance.shopCoin.SetActive(false);
        Singleton.Instance.shopGem.SetActive(false);
        Singleton.Instance.shopLife.SetActive(true);
    }

    private void ClickedShopPopupGemUS()
    {

    }

    private void ClickedShopPopupGemUS2()
    {

    }

    private void ClickedShopPopupGemUS3()
    {

    }

    private void ClickedShopPopupGemUS4()
    {

    }

    #endregion

    #region Life

    private void ClickedShopPopupLifeTabCoin()
    {
        Singleton.Instance.shopCoin.SetActive(true);
        Singleton.Instance.shopGem.SetActive(false);
        Singleton.Instance.shopLife.SetActive(false);
    }

    private void ClickedShopPopupLifeTabGem()
    {
        Singleton.Instance.shopCoin.SetActive(false);
        Singleton.Instance.shopGem.SetActive(true);
        Singleton.Instance.shopLife.SetActive(false);
    }

    private void ClickedShopPopupLifeTabLife()
    {
        Singleton.Instance.shopCoin.SetActive(false);
        Singleton.Instance.shopGem.SetActive(false);
        Singleton.Instance.shopLife.SetActive(true);
    }

    private void ClickedShopPopupLifeUS()
    {

    }

    private void ClickedShopPopupLifeUS2()
    {

    }

    private void ClickedShopPopupLifeUS3()
    {

    }

    private void ClickedShopPopupLifeUS4()
    {

    }

    #endregion

    private void ClickedShopPopupClose()
    {
        Singleton.Instance.shop.SetActive(false);
    }

    #endregion

    #endregion
}