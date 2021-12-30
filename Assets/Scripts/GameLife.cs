using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameLife : MonoBehaviour
{
    private int life;
    public TextMeshProUGUI lifeText;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "Life :" + life;
        if (life <= 0 || gameManager.score<=-5)
        {
            gameManager.GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Bad"))
        {
            life--;
        }
    }
}
