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

    #region Setting

    private void ClickedSetting()
    {

    }

    #endregion

    #region Skill

    private void ClickedSkillName()
    {

    }

    #endregion

    #region Stat

    private void ClickedStatAttackUp()
    {

    }

    private void ClickedStatSpeedUp()
    {

    }

    private void ClickedStatCriticalUp()
    {

    }

    private void ClickedStatDefenseUp()
    {

    }

    private void ClickedStatHealthUp()
    {

    }

    #endregion

    #region Contents

    private void ClickedContentsDevil()
    {

    }

    private void ClickedContentsCoworker()
    {

    }

    private void ClickedContentsShop()
    {

    }

    #endregion
}