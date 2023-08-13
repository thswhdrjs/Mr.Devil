using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public bool isDone;

    protected override void Awake()
    {
        isDone = false;
    }

    private void Start()
    {
        FunctionManager.Instance.SetFrameRate(120);

        StartCoroutine(Contents());
        StartCoroutine(AutoSave());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    //Contents
    private IEnumerator Contents()
    {
        #region Setting

        Init();

        yield return new WaitUntil(() => DataManager.Instance.data.level != 0);
        StartCoroutine(FunctionManager.Instance.Fade(true, () => isDone = true));

        yield return new WaitUntil(() => isDone);
        isDone = false;

        #endregion

        /*Function*/


        /* Wait */
        yield return new WaitUntil(() => isDone);
        isDone = false;
    }

    private IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(180f);
        DataManager.Instance.SaveData();
    }

    private void Init()
    {
        Image loading = Singleton.Instance.loadingImageLoading.GetComponent<Image>();
        loading.color = new Color(0f, 0f, 0f, 1f);

        DataManager.Instance.UpdateData();
    }

    private void OnApplicationQuit()
    {
        DataManager.Instance.data.level = int.Parse(Singleton.Instance.levelTmpLevel.GetComponent<TextMeshProUGUI>().text);

        DataManager.Instance.data.coin = int.Parse(Singleton.Instance.coinTmpCoin.GetComponent<TextMeshProUGUI>().text);
        DataManager.Instance.data.gem = int.Parse(Singleton.Instance.gemTmpGem.GetComponent<TextMeshProUGUI>().text);

        DataManager.Instance.SaveData();
    }
}