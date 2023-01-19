using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private static int objectsNr;
    private bool shouldCollapse = false;
    [SerializeField] GameObject door;
    [SerializeField] GameObject roof;
    [SerializeField] Text textMesh;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        objectsNr = 8;
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
        float speed = -2.0f;
        roof.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }

    public void DecreaseNumber()
    {
        if (objectsNr > 0)
        {
            objectsNr--;
            SetText();
            if(objectsNr == 0)
            {
                door.SetActive(true);
                shouldCollapse = true;
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
