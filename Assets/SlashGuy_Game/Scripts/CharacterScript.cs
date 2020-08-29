using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private GameController gameController;

    void Awake()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (gameController.isGameStarted && collision.gameObject.tag == "ObstacleObject")
        {
            gameController.currentPlayerMoveScript.isMoving = false;
            gameController.currentPlayerAnimator.SetInteger("condition", 0);
        }
        else if (gameController.isGameStarted && collision.gameObject.tag != "ObstacleObject")
        {
            gameController.currentPlayerMoveScript.isMoving = true;
            gameController.currentPlayerAnimator.SetInteger("condition", 1);
        }

    }
}
