using TMPro;
using UnityEngine;

public class JPObjective : MonoBehaviour
{
    public GameObject baryonyx;
    public GameObject egg;
    public float EscapeDistance;
    private float time;
    public GameManager gameManager;
    public TMP_Text NoEgg;
    public TMP_Text Objective;

    void Update()
    {
        time += Time.deltaTime;
        countTime();
        float distance = Vector3.Distance(baryonyx.transform.position, this.transform.position);

        if (distance <= EscapeDistance && egg.transform.position.y > 0)
        {
            gameManager.SecondGameOverUI();
        }
        /*
        else if (distance <= EscapeDistance && egg.transform.position.y == 0)
        {
            NoEgg.enabled = true;
        }
        else
        {
            NoEgg.enabled = false;
        }
        */
    }
    void countTime()
    {
        if (time <= 5)
        {
            Objective.enabled = true;
        }
        else
        {
            Objective.enabled = false;
        }
    }
}
