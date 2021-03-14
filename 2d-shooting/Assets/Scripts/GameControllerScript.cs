using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    public GameObject enemy;
    private int score;
    public Text scoreText;
    public Text replayText;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
        score = 0;
        UpdateScoreText();
        replayText.text = "";
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver) return;

        if(Input.GetKey(KeyCode.Space)) {
            // そもそもSceneを読みこみ直す
            SceneManager.LoadScene("MainScene");
        }
    }

    IEnumerator SpawnEnemy() {
        while(true) {
            Instantiate(
                enemy,
                new Vector3(Random.Range(-8f, 8f), transform.position.y, 0f),
                transform.rotation
            );
            yield return new WaitForSeconds(0.5f);
        }
    }

    // スコア加算publicメソッド
    public void AddScore(int scoreToAdd) {
        score += scoreToAdd;
        UpdateScoreText();
    }

    // スコアの反映処理を共通化するメソッド
    void UpdateScoreText() {
        scoreText.text = "Score" + score;
    }

    public void GameOver() {
        isGameOver = true;
        replayText.text = "Hit space to replay!";
    }
}
