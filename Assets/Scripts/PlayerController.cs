using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float forwardInput;

    [Header("Preferences")]
    [SerializeField] Rigidbody playerRB;
    [SerializeField] GameObject focalPoint;
    public GameObject powerupIndicator;


    [Header("Settings")]
    [SerializeField] float speed;
    private bool gotPowerup = false;
    [SerializeField] float powerupStrength = 15;
    [SerializeField] float effectDuration = 6f;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }


    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            gotPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupDuration());

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && gotPowerup)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 impulseDir = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + gotPowerup);
            enemyRB.AddForce(impulseDir * powerupStrength, ForceMode.Impulse);

            
        }
    }

    IEnumerator PowerupDuration()
    {
        powerupIndicator.gameObject.SetActive(true);
        yield return new WaitForSeconds(effectDuration);
        powerupIndicator.gameObject.SetActive(false);
        gotPowerup = false;
        Debug.Log("Powerup has ended");
    }
}
