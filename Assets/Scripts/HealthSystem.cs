using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public GameObject player;
    public Image playerHealthBar;
    float playerHealth, playerMaxHealth = 100;
    float lerpSpeed;

    public GameObject enemy;
    float enemyHealth, enemyMaxHealth = 100;
    private Animator playerAnimator;
    private Animator enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
         playerAnimator = player.GetComponent<Animator>();
        enemyAnimator = enemy.GetComponent<Animator>();
        playerHealth = playerMaxHealth;
        enemyHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth > playerMaxHealth) playerHealth = playerMaxHealth;
        if (enemyHealth > enemyMaxHealth) enemyHealth = enemyMaxHealth;
        lerpSpeed = 6f * Time.deltaTime;
        HealthbarFiller();
        ColorChanger();

        if (playerHealth == 0f)
        {
            Debug.Log("Your Already Dead!");
            playerAnimator.Play("Chatacter-Death");
            float deathAnimLenght = 0.3f;
            Invoke("DisablePlayer", deathAnimLenght);
        }

        if (enemyHealth == 0f)
        {
            Debug.Log("Enemy Died");
            enemyAnimator.Play("Enemy-Death");
            float deathAnimLenght = 0.3f;
            Invoke("DisableEnemy", deathAnimLenght);

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

    void HealthbarFiller()
    {
        playerHealthBar.fillAmount = Mathf.Lerp(playerHealthBar.fillAmount, playerHealth / playerMaxHealth, lerpSpeed);
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
        if(enemyHealth > 0)
        {
            enemyHealth -= damagePoints;
        }
    }


}
