using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator toyController;
    void Start()
    {
        toyController = GetComponent<Animator>();
    }


    private IEnumerator destroy()
    {
        yield return new WaitForSeconds(2);
        GameManager.Instance.DecreaseNumber();
        Destroy(gameObject);
    }

    public void PickUp()
    {
        toyController.SetTrigger("IsPicked");
        StartCoroutine(destroy());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
