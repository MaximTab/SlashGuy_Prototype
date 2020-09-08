using UnityEngine;


public class MoveScript : MonoBehaviour
{
    private GameConfig gameConfig;

    void Awake()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameConfig = gameControllerObject.GetComponent<GameConfig>();
    }

    public bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * gameConfig.speedPlayer);
        }
    }
}
