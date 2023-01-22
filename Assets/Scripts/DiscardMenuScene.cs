using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscardMenuScene : MonoBehaviour
{
    public void ChangeToSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChangeToSampleScene();
        }
    }
}
