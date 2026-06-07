using UnityEngine;
using UnityEngine.InputSystem;

public class RoarInventory : MonoBehaviour
{
    public AudioSource roar1;
    public AudioSource roar2;
    public AudioSource roar3;
    public AudioSource eaten;
    public GameObject egg;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            roar1.Play();
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            roar2.Play();
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            roar3.Play();
        }

        if (egg.transform.position.y > 0)
        {
            eaten.Play();
        }
    }
}
