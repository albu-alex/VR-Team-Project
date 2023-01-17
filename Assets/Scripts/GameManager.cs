using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private static int objectsNr;
    [SerializeField] GameObject door;
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

    public void DecreaseNumber()
    {
        if (objectsNr > 0)
        {
            objectsNr--;
            SetText();
            if(objectsNr == 0)
            {
                door.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
