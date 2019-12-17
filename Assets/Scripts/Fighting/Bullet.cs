using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject enemyDeathBlood;
    public GameObject hitEffect;
    private int damage = 1;
    EnemyAI enemyAI;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyHumanoid") {
            enemyAI = collision.gameObject.GetComponent<EnemyAI>();
            enemyAI.Killed();
            GameObject effect = Instantiate(enemyDeathBlood, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
        } else {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }
    }
}
