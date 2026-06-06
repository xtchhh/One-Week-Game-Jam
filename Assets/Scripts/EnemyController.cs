using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float EnemySpeed;
    public GameObject baryonyx;
    public GameObject egg;
    public MeshRenderer rex;
    public GameManager gameManager;
    public AudioSource stomp;

    void Update()
    {
        Vector3 baryonyxPos = baryonyx.transform.position;
        Vector3 currentPos = this.transform.position;
        Vector3 direction = (baryonyxPos - currentPos).normalized;
        float distance = Vector3.Distance(baryonyxPos, currentPos);

        if (egg.transform.position.y > 0f)
        {
            rex.enabled = true;
            this.transform.Translate(direction * EnemySpeed * Time.deltaTime);

            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            this.transform.rotation = rotation * Quaternion.Euler(0, 90, 0); //alternates direction??

            stomp.Play();

            if (distance <= 5)
            {
                gameManager.GameOverUI();
            }
        }
    }

}
