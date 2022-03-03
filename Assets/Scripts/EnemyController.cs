using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Preferences")]
    Rigidbody enemyRB;
    GameObject Player;
    [SerializeField] float speed = 5;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = (Player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDir * speed);

        if (transform.position.y < -5) Destroy(gameObject); 
    }
}
