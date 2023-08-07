using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isDone;

    [SerializeField]
    private bool[] sceneChoice;

    private void Start()
    {
        FunctionManager.Instance.SetFrameRate(120);

        StartCoroutine(Contents());
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
        yield return new WaitUntil(() => isDone);

        #endregion

        #region Phase1

        if (sceneChoice[0])
        {
            /* Fade Out */
            //StartCoroutine(FunctionManager.Instance.Fade(true, () => isDone = true));

            yield return new WaitUntil(() => isDone);
            isDone = false;

            /*Function*/


            /* Wait */
            yield return new WaitUntil(() => isDone);
            isDone = false;
        }

        #endregion
    }

    private void Init()
    {
        isDone = false;
    }
}