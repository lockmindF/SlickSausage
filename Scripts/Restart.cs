using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject gameOverUI;

    public GameObject finishUI;
    public void RestartGame()
    {
        gameOverUI.SetActive(false);
        finishUI.SetActive(false);
        FindObjectOfType<GameManager>().Respawn();
    }

}
