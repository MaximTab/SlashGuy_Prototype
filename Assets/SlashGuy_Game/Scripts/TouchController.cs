using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    private GameController gameController;
    private ScreensController screensController;


    void Awake()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        screensController = gameControllerObject.GetComponent<ScreensController>();

    }

    void Update()
    {

        // Touch Input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && screensController.MainScreen.activeInHierarchy)
        {
            if (CheckTapIsOverExpectedUIObject(Input.GetTouch(0).position, "MainScreen") || CheckTapIsOverExpectedUIObject(Input.GetTouch(0).position, "TapToPlayText"))
            {
                screensController.ShowScreen(nameof(ScreensController.Screens.GameScreen));
                StartCoroutine(gameController.StartGame());
            }
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (gameController.isGameStarted && !gameController.isAttack)
            {
                gameController.ChangeSwordScale();
            }
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && screensController.GameScreen.activeInHierarchy)
        {
            if (gameController.isGameStarted && !gameController.isAttack)
            {
                gameController.Attack();
            }
        }


        // Mouse input
        if (Input.GetButtonUp("Fire1") && screensController.MainScreen.activeInHierarchy)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if (CheckTapIsOverExpectedUIObject(mousePosition, "MainScreen") || CheckTapIsOverExpectedUIObject(mousePosition, "TapToPlayText"))
            {
                screensController.ShowScreen(nameof(ScreensController.Screens.GameScreen));
                StartCoroutine(gameController.StartGame());

            }
        }
        else if (Input.GetButton("Fire1"))
        {

            if (gameController.isGameStarted && !gameController.isAttack)
            {
                gameController.ChangeSwordScale();
            }

        }

        else if (Input.GetButtonUp("Fire1") && screensController.GameScreen.activeInHierarchy)
        {

            if (gameController.isGameStarted && !gameController.isAttack)
            {
                gameController.Attack();
            }

        }

    }

    bool CheckTapIsOverExpectedUIObject(Vector2 position, string expectedUIObjectName)
    {

        UnityEngine.EventSystems.PointerEventData pointer = new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current);
        pointer.position = position;
        List<UnityEngine.EventSystems.RaycastResult> raycastResults = new List<UnityEngine.EventSystems.RaycastResult>();
        UnityEngine.EventSystems.EventSystem.current.RaycastAll(pointer, raycastResults);

        if (raycastResults.Count >= 1)
        {
            foreach (var go in raycastResults)
            {
                //Debug.Log(raycastResults.Count);
                //Debug.Log(go.gameObject.name);
                if (go.gameObject.name == expectedUIObjectName)
                {

                    return true;
                }
            }
        }

        return false;
    }

}

