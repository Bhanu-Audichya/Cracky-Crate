using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private float torque = 40;
    private GameManager gameManager;
    private Rigidbody targetRb;
    public int pointValue;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(14, 16), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-torque,torque),Random.Range(-torque,torque),Random.Range(-torque,torque),ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4,4), -2, 0);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isgameOver)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnMouseDown()
    {
        if (!gameManager.isgameOver)
        {
            Destroy(gameObject);
            Instantiate(particle, transform.position, transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Sensor"))
        {
            Destroy(gameObject);
        }
    }
    

}
