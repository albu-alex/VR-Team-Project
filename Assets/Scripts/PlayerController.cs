using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private bool pickUp = false;

    public float speed = 12f;
    private int hits = 0;
    private ToyScript toy = null;
    [SerializeField] GameObject door2;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bear"))
        {
            Debug.Log("HIT BEAR");
            pickUp = true;
            toy = other.gameObject.GetComponent<ToyScript>();
        }
        if (other.CompareTag("Red") && hits == 0)
        {
            Debug.Log("HIT RED");
            hits++;
        }
        else if (other.CompareTag("Green") && hits == 1)
        {
            Debug.Log("HIT GREEN");
            hits++;
        }
        else if (other.CompareTag("Blue") && hits == 2)
        {
            Debug.Log("HIT BLUE");
            hits++;
        }
        else if (other.CompareTag("Yellow"))
        {
            Debug.Log("HIT YELLOW");
            door2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if (other.CompareTag("Bear"))
        {
            pickUp = false;
            toy = null;
        }
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (toy != null && Input.GetKeyDown(KeyCode.Space))
        {
            toy.PickUp();
        }
    }
}
