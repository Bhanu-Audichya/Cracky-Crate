using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    public GameObject pausePanel;
    public TextMeshProUGUI gameOverText;
    public int score;
    public Button restartButton;
    public List<GameObject> targets;
    public bool isgameOver;
    private float spawnrate =2;
    public bool pause;
   
    // Start is called before the first frame update
    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
   
    IEnumerator SpawnTarget()
    {
        while(!isgameOver)
        {
            yield return new WaitForSeconds(spawnrate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
        
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isgameOver = true;
    }
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(float difficluty)
    {
        isgameOver = false;
        spawnrate /= difficluty;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
    void PauseGame()
    {
        if (!pause)
        {
            pause = true;
            Time.timeScale = 0;
            pausePanel.gameObject.SetActive(true);
        }
        else
        {
            pause = false;
            Time.timeScale = 1;
            pausePanel.gameObject.SetActive(false);
        }
    }
   
}
