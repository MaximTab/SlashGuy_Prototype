using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private GameController gameController;

    void Awake()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void Update()
    {
        if (gameController.isGameStarted)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, gameController.currentPlayer.transform.position.z + (gameController.cameraStartPoint.z-1));
        }
    }
}
