using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
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

    // Update is called once per frame
    void Update()
    {
        if (!shouldCollapse) 
        { 
            return; 
        }
        collapseWall();
    }
}
