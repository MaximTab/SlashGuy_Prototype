using UnityEngine;

public class ObstacleObjectsScript : MonoBehaviour
{

    private Rigidbody rigidBody;
    private BoxCollider boxCollider;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Sword")
        {
            boxCollider.enabled = false;
            rigidBody.AddForce(new Vector3(0,12,0), ForceMode.Impulse);
        }
    }


    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.name == "Sword")
        {
            boxCollider.enabled = false;
            rigidBody.AddForce(new Vector3(0, 12, 0), ForceMode.Impulse);
        }
    }

}
