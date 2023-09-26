using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class buttonsControl : MonoBehaviour
{
    public TMP_Text victoryCountText;
    [SerializeField] private GameObject _mainpoint, _loginPoint, _outputPoint, _backPoint;
    public GameObject mainMenu, loginMenu, cannotLoginButton;

    void Start()
    {
        victoryCountText.text = "Victories:" + " " + PlayerPrefs.GetInt("Wins").ToString();
    }
    public void StartButton()
    {
        SceneManager.LoadScene("MainBackground");
    }

    public void LoginButton()
    {
        mainMenu.transform.DOMove(_mainpoint.transform.position, 0.5f);
        loginMenu.transform.DOMove(_loginPoint.transform.position, 0.5f);
        
    }

    public void cannotLogin()
    {
        StartCoroutine(MoveButtonAndExecute());
    }

    IEnumerator MoveButtonAndExecute()
    {
        cannotLoginButton.transform.DOMove(_loginPoint.transform.position, 0.5f);
        yield return new WaitForSeconds(2f);
        cannotLoginButton.transform.DOMove(_outputPoint.transform.position, 0.5f);
    }

    public void backToMenuButton()
    {
        loginMenu.transform.DOMove(_backPoint.transform.position, 0.5f);
        mainMenu.transform.DOMove(_loginPoint.transform.position, 0.5f);
    }
}
