using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{

    public GameObject enemy;
    private int score;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
        score = 0;
        scoreText.text = "Score" + score;
    }

    // Update is called once per frame
    void Update()
    {

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
}
