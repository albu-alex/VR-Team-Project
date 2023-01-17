using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private bool pickUp = false;

    public float speed = 12f;
    private ToyScript toy = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bear"))
        {
            Debug.Log("HIT BEAR");
            pickUp = true;
            toy = other.gameObject.GetComponent<ToyScript>();
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
