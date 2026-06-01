using UnityEngine;

public class JPObjective : MonoBehaviour
{
    private GameObject baryonyx;
    private GameObject egg;
    public float EscapeDistance;
    public GameManager gameManager;

    void Awake()
    {
        baryonyx = GameObject.Find("Baryonyx");
        egg = GameObject.Find("Egg");
    }

    void Update()
    {
        float distance = Vector3.Distance(baryonyx.transform.position, this.transform.position);

        if (distance <= EscapeDistance && egg.transform.position.y > 0)
        {
            Debug.Log($"You escaped into Jurassic park, Game Over!!");
            gameManager.GameOverUI();
        }
        else if (distance <= EscapeDistance && egg.transform.position.y == 0)
        {
            Debug.Log($"You are hungry, you need to find food"); //text

        }
    }
}
