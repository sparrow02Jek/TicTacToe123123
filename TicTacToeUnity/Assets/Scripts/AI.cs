using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameController gameController; // Ссылка на GameController

    public void MakeAIMove()
    {
        while (!gameController.isGameOver)
        {
            int i = Random.Range(0, gameController.buttonList.Length);
            print(i);
            if (gameController.buttonList[i].text == "")
            {
                gameController.buttonList[i].text = "O"; // O - это символ нолика
                gameController.EndTurn(); // Завершаем ход
                return;
            }
            else
            {
                continue;
            }
        }
    }
}
