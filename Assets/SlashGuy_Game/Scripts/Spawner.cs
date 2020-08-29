using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameController gameController;

    public GameObject playerPref;
    public GameObject levelPref;

    private void Awake()
    {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();

        }
        else
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }

  
    public void SpawnPlayer() {

        gameController.currentPlayer = Instantiate(playerPref, playerPref.transform.position, playerPref.transform.rotation);


        gameController.currentSword = gameController.currentPlayer.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).
            GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        gameController.currentPlayerMoveScript = gameController.currentPlayer.GetComponent<MoveScript>();
        gameController.currentPlayerAnimator = gameController.currentPlayer.transform.GetChild(0).GetComponent<Animator>();
        gameController.currentSwordMaterial = gameController.currentSword.transform.GetChild(0).GetComponent<MeshRenderer>().material;


    }

    public void SpawnLevel() {

        gameController.currentLevel = Instantiate(levelPref, levelPref.transform.position, levelPref.transform.rotation);
    }
}
