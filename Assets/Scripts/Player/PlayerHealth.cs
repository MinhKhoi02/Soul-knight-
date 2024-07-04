using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerConfig playerConfig;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            TakeDamge(amount:1f);
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            RecoverHealth(amount:1f);
        }
    }

    public void RecoverHealth(float amount)
    {
        playerConfig.CurrentHealth += amount;
        if (playerConfig.CurrentHealth > playerConfig.MaxHealth)
        {
            playerConfig.CurrentHealth = playerConfig.MaxHealth;
        }
    }

    public void TakeDamge(float amount)
    {
        if (playerConfig.Armor > 0)
        {
            //Break armor
            //Damage health
            float remainingDamage = amount - playerConfig.Armor;
            playerConfig.Armor = Mathf.Max(playerConfig.Armor - amount, 0f);
            if (remainingDamage > 0) 
            {
                playerConfig.CurrentHealth = 
                    Mathf.Max(playerConfig.CurrentHealth - remainingDamage, 0f);
            }        
        }
        else
        {
            //Damage health
            playerConfig.CurrentHealth = 
                Mathf.Max(playerConfig.CurrentHealth - amount, 0f);
        }

        if (playerConfig.CurrentHealth <= 0)
        {
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        Destroy(gameObject);
    }
}
