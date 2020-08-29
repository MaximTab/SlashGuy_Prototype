using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Spawner spawner;
    private ScreensController screensController;


    // Settings
    public float speedPlayer = 5;
    public float scaleModifierSword = 0.08f;
    private Color32 defaultSwordColor = new Color32(255, 255, 255, 255);
    private Color32 chargedSwordColor = new Color32(0, 255, 15, 255);
    private Color32 chargingSwordColor = new Color32(121, 255, 130, 255);
    private Vector3 finishPoint = new Vector3(0, 0, 101);
    




    [HideInInspector]
    public Vector3 cameraStartPoint;

    [HideInInspector]
    public GameObject currentPlayer;
    [HideInInspector]
    public GameObject currentSword;
    [HideInInspector]
    public GameObject currentLevel;
    [HideInInspector]
    public MoveScript currentPlayerMoveScript;
    [HideInInspector]
    public Animator currentPlayerAnimator;
    [HideInInspector]
    public Material currentSwordMaterial;

    [HideInInspector]
    public bool isGameStarted;
    [HideInInspector]
    public bool isAttack;

    private void Awake()
    {
        Application.targetFrameRate = 60; 

        spawner = GetComponent<Spawner>();
        screensController = GetComponent<ScreensController>();
    }

    private void Start()
    {
        cameraStartPoint = Camera.main.transform.position;

        spawner.SpawnLevel();
        spawner.SpawnPlayer();
    }

    private void Update()
    {
        if (isGameStarted && currentPlayer.transform.position.z >= finishPoint.z) {

            StartCoroutine(WinGame());

        }

        if (isGameStarted && currentPlayer.transform.position.z < finishPoint.z)
        {
            screensController.barImage.fillAmount = currentPlayer.transform.position.z / 100;

        }
    }


    public IEnumerator StartGame() {

        yield return new WaitForSeconds(0.1f);
        isGameStarted = true;
    }

    public void ClearGame() {

        Destroy(currentSword);
        Destroy(currentPlayer);
        Destroy(currentLevel);
    }

    public void RestartGame() {

        ClearGame();
        spawner.SpawnLevel();
        spawner.SpawnPlayer();
        Camera.main.transform.DOMove(cameraStartPoint, 0.6f);
        screensController.ShowScreen(nameof(ScreensController.Screens.MainScreen));

    }

    public IEnumerator WinGame()
    {
        isGameStarted = false;
        currentPlayerAnimator.SetInteger("condition", 0);
        currentPlayerMoveScript.isMoving = false;
        screensController.winLoseText.GetComponent<Text>().text = "WIN";
        yield return new WaitForSeconds(0.01f);
        screensController.ShowScreen(nameof(ScreensController.Screens.WinLoseScreen));
 
    }

    public IEnumerator GameOver()
    {
        isGameStarted = false;
        currentPlayerAnimator.SetInteger("condition", 0);
        currentPlayerMoveScript.isMoving = false;
        screensController.winLoseText.GetComponent<Text>().text = "Game Over";
        yield return new WaitForSeconds(0.01f);
        screensController.ShowScreen(nameof(ScreensController.Screens.WinLoseScreen));
    }

    public void ChangeSwordScale()
    {
        if (currentSword.transform.localScale.z < 3)
        {
            currentSwordMaterial.SetColor("_Color",chargingSwordColor);
            Vector3 newScale = new Vector3(currentSword.transform.localScale.x, currentSword.transform.localScale.y, currentSword.transform.localScale.z + scaleModifierSword);
            currentSword.transform.localScale = newScale;
        }
        else
        {
            currentSwordMaterial.SetColor("_Color", chargedSwordColor);
        }
    }

    public void Attack()
    {
        isAttack = true;
        currentSword.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
        currentPlayer.transform.GetChild(0).DOLocalRotate(new Vector3(0, 360, 0), 0.35f,RotateMode.FastBeyond360).SetUpdate(true)
            .OnComplete(ChangeSwordScaleToDefault);

    }

    public void ChangeSwordScaleToDefault()
    {
        Vector3 newScale = new Vector3(currentSword.transform.localScale.x, currentSword.transform.localScale.y, 1);
        currentSword.transform.localScale = newScale;
        currentSword.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        currentSwordMaterial.SetColor("_Color", defaultSwordColor);
        isAttack = false;
    }

    
}
