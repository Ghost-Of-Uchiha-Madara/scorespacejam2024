using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    //Player
    public GameObject player;
    public Image playerHealthBar;
    public float playerHealth, playerMaxHealth = 100;
    float lerpSpeed;
    private Animator playerAnimator;

    //Boss
    public GameObject boss;
    public Image bossHealthBar;
    public float bossHealth, bossMaxHealth = 100;
    public Animator bossAnimator;

    //enemy
    public GameObject enemy;
    public float enemyHealth, enemyMaxHealth = 100;
    private Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        enemyAnimator = enemy.GetComponent<Animator>();
        bossAnimator = boss.GetComponent<Animator>();
        playerHealth = playerMaxHealth;
        enemyHealth = enemyMaxHealth;
        bossHealth = bossMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth > playerMaxHealth) playerHealth = playerMaxHealth;
        if (enemyHealth > enemyMaxHealth) enemyHealth = enemyMaxHealth;
        if(bossHealth > bossMaxHealth) bossHealth = bossMaxHealth;
        lerpSpeed = 6f * Time.deltaTime;
        HealthbarFiller();
        ColorChanger();

        if (playerHealth <= 0f)
        {
            Debug.Log("Your Already Dead!");
            playerAnimator.Play("Chatacter-Death");
            float deathAnimLenght = 0.3f;
            Invoke("DisablePlayer", deathAnimLenght);
        }

        if (enemyHealth <= 0f)
        {
            Debug.Log("Enemy Died");
            enemyAnimator.Play("Enemy-Death");
            float deathAnimLenght = 0.3f;
            Invoke("DisableEnemy", deathAnimLenght);
        }

        if(bossHealth <= 0f)
        {
            Debug.Log("Boss Defeated");
            bossAnimator.Play("Boss-Death");
            float deathAnimLenght = 0.6f;
            Invoke("DisableBoss", deathAnimLenght);

        }
    }

    public void DisablePlayer()
    {
        player.SetActive(false);
    }

    public void DisableEnemy()
    {
        enemy.SetActive(false);
    }

    public void DisableBoss()
    {
        boss.SetActive(false);
    }

    void HealthbarFiller()
    {
        playerHealthBar.fillAmount = Mathf.Lerp(playerHealthBar.fillAmount, playerHealth / playerMaxHealth, lerpSpeed);
        bossHealthBar.fillAmount = Mathf.Lerp(bossHealthBar.fillAmount,bossHealth / bossMaxHealth, lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (playerHealth / playerMaxHealth));

        playerHealthBar.color = healthColor;
    }

    //Test Purpose
    public void PlayerDamage(float damagePoints)
    {
        if (playerHealth > 0)
        {
            playerHealth -= damagePoints;
        }
    }

    public void PlayerHeal(float healingPoints)
    {
        if (playerHealth < playerMaxHealth)
        {
            playerHealth += healingPoints;
        }
    }

    public void EnemyDamage(float damagePoints)
    {
        if (enemyHealth > 0)
        {
            enemyHealth -= damagePoints;
        }
    }

    public void BossDamage(float damagePoints)
    {
        if(bossHealth > 0)
        {
            bossHealth -= damagePoints;
        }
    }


}
