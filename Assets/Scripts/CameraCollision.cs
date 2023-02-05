using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Roof"))
        {
            Debug.Log("Collision detected with the Roof!");
            SceneManager.LoadScene("Menu");
        }
    }
}
