using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject baryonyx;

    void Update()
    {
        float distance = Vector3.Distance(baryonyx.transform.position, this.transform.position); //returns magnitude basically after subtracting baryonyx pos by this class' pos
        if (distance <= 2.5)
        {
            transform.Translate(Vector3.up * 1.0f);
            this.gameObject.SetActive(false);
            
        }
    }
}
