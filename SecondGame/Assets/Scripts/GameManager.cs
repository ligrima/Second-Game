using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //set gameended to false
    private bool gameEnded = false;

	// if gameended is still false, return, if lives are less or equal to 0, end game
	void Update () {
        if (gameEnded)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
	}

    // if end game is true, load game over scene
    void EndGame ()
    {
        gameEnded = true;
        SceneManager.LoadScene ("GameOverScene");
    }
}
