using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject Player;

    private Renderer _rendererPlayer;
    public Texture2D texPlayerNew;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
        _rendererPlayer = Player.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (Player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * enemySpeed);

        if (transform.position.y < -5) {
            Destroy(gameObject);
            Player.transform.localScale = transform.localScale + new Vector3(1, 1, 1);
            _rendererPlayer.material.SetTexture("_MainTex", texPlayerNew);
        }
    }
}
