using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;

    private Camera[] cameras;
    private static int objectsNr;
    private bool shouldCollapse = true;
    [SerializeField] GameObject door;
    [SerializeField] GameObject roof;
    [SerializeField] Text textMesh;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        objectsNr =5;
        textMesh.text = "Items left:" + objectsNr;
        cameras = new Camera[] { camera1, camera2, camera3, camera4 };
    }

    private void Start()
    {
        door.SetActive(false);
    }

    private void SetText()
    {
        textMesh.text = "Items left:" + objectsNr;
    }

    private void collapseWall()
    {
        float speed = -0.5f;
        roof.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if (roof.transform.position.y < 10)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void DecreaseNumber()
    {
        if (objectsNr > 0)
        {
            objectsNr--;
            SetText();
            if(objectsNr == 0)
            {
                shouldCollapse = false;
                door.SetActive(true);
            }
        }
    }

    void SwitchToCamera(int index)
    {
        // Deactivate all cameras
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        // Activate the second camera
        cameras[index].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldCollapse) 
        {
            float distance = Vector3.Distance(camera1.transform.position, door.transform.position);
            if (distance < 10.0)
            {
                SwitchToCamera(1);
                textMesh.text = "";
                textMesh.text = "Rob Green Bought Yahoo";
            }
            return; 
        }
        collapseWall();
    }
}
