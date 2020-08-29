using UnityEngine;
using DG.Tweening;

public class EnemyScript : MonoBehaviour
{
    private GameController gameController;

    private Color32 color = new Color32(90,164,71,255);

    void Awake()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sword")
        {
            GetComponent<MeshRenderer>().material.DOColor(color, 0.6f);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 9, 0), ForceMode.Impulse);
            
        }


        if (collision.gameObject.tag == "Player")
        {

            StartCoroutine(gameController.GameOver());
            
        }
    }
}
