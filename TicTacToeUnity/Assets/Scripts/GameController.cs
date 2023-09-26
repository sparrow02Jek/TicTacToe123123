using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour
{

    public Text[] buttonList;
    public TMP_Text victoryCountText;
    public string playerSide;

    public GameObject gameOverPanel;
    public GameObject restartButton;
    public Text gameOverText;
    public Player playerX;
    public Player playerO;
    public PlayerColor activeColor;
    public PlayerColor inactiveColor;
    public AI aiScript;
    public bool isGameOver = false;
    public int victoryCount;


    private int moveCount;

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
    void Awake()
    {
        moveCount = 0;
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetPlayerColors(playerX, playerO);
        victoryCount = PlayerPrefs.GetInt("Wins");
        victoryCountText.text = victoryCount.ToString();
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
            if (playerSide == "X")
            {
                victoryCount++;
                PlayerPrefs.SetInt("Wins",victoryCount);
            }
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide &&
                 buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
            if (playerSide == "X")
            {
                victoryCount++;
                PlayerPrefs.SetInt("Wins",victoryCount);
            }
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide &&
                 buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
            if (playerSide == "X")
            {
                victoryCount++;
                PlayerPrefs.SetInt("Wins",victoryCount);
            }
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide &&
                 buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
            if (playerSide == "X")
            {
                victoryCount++;
                PlayerPrefs.SetInt("Wins",victoryCount);
            }
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide &&
                 buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
            if (playerSide == "X")
            {
                victoryCount++;
                PlayerPrefs.SetInt("Wins",victoryCount);
            }
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide &&
                 buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
            if (playerSide == "X")
            {
                victoryCount++;
                PlayerPrefs.SetInt("Wins",victoryCount);
            }
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide &&
                 buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
            if (playerSide == "X")
            {
                victoryCount++;
                PlayerPrefs.SetInt("Wins",victoryCount);
            }
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide &&
                 buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
            if (playerSide == "X")
            {
                victoryCount++;
                PlayerPrefs.SetInt("Wins",victoryCount);
            }
        }
        else if (moveCount >= 9)
        {
            GameOver("draw");
        }
        else
            ChangeSide();
    }

    void ChangeSide()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        if (playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
            // Если текущий игрок - нолик (ИИ), вызываем метод ИИ для его хода
            if (playerSide == "O")
            {
                aiScript.MakeAIMove();
            }
        }
    }

    void GameOver(string winningPlayer)
    {
        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a Draw!");
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
            
            isGameOver = true;
        }

        SetBoardInteractable(false);
        restartButton.SetActive(true);
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetBoardInteractable(true);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }

        isGameOver = false;
        SetPlayerColors(playerX, playerO);
        victoryCount = PlayerPrefs.GetInt("Wins");
        victoryCountText.text = victoryCount.ToString();
    }

    public void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activeColor.panelColor;
        //newPlayer.text.color = activeColor.textColor;
        oldPlayer.panel.color = inactiveColor.panelColor;
        //oldPlayer.text.color = inactiveColor.textColor;
    }
}