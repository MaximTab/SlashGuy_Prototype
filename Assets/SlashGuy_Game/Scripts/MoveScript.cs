using UnityEngine;


public class MoveScript : MonoBehaviour
{
    private GameController gameController;

    void Awake()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    public bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * gameController.speedPlayer);
        }
    }
}
