using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private float phase;  //三角関数の位相をバラつかせるため
    public GameObject explosion;
    private GameControllerScript gameController;

    // Start is called before the first frame update
    void Start()
    {
        phase = Random.Range(0f, Mathf.PI * 2);
        gameController = GameObject
            .FindWithTag("GameController")
            .GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            Mathf.Cos(Time.frameCount * 0.05f + phase) * 0.05f,
            -2f * Time.deltaTime,
            0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 弾と衝突
        if (other.gameObject.CompareTag("Bullet")) {
            gameController.AddScore(10);  //得点を加算

            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        // プレイヤーと衝突
        if (other.gameObject.CompareTag("Player")) {
            gameController.GameOver();

            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
