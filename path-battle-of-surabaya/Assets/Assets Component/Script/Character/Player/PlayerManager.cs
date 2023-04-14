using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    [Header("Health Component")]
    public float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float regenTimer;
    [SerializeField] private float healthRegenAmount;
    public bool isDeath;

    [Header("Health UI Component")]
    public Image healthEffect;

    [Header("Energy Component")]
    public float maxEnergy;
    [SerializeField] private float currentEnergy;
    [SerializeField] private float energyUseAmount;
    [SerializeField] private float eneryRegenAmount;
    public bool isEnergyRegen;

    [Header("Energy UI Component")]
    [SerializeField] private float energyDecreaseTime;
    public Image energyBar;
    public Image energyEffect;

    [Header("Experience Component")]
    public float maxExperienceProgress;
    private float currentMaxExperienceProgress;
    [SerializeField] private float currentExperienceProgress;
    [SerializeField] private float experienceProgressAmount;
    public float currentExperience;

    [Header("Experience UI Component")]
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI experienceProgressText;
    public Image experienceBar;
    
    [Header("Reference")]
    private PlayerMain playerMain;

    protected override void Awake()
    {
        playerMain = GetComponent<PlayerMain>();

        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
    }

    void Update()
    {
        #region Health
        HealthInterface();
        #endregion

        #region Energy
        DecreaseEnergy();
        IncreaseEnergy();
        EnergyInterface();
        #endregion

        #region Experience
        ExperienceInterface();
        #endregion
    }

    public float DecreaseHealth(float _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDeath = true;
        }
        return currentHealth;
    }

    public float IncreaseHealth()
    {
        currentHealth += healthRegenAmount * Time.deltaTime;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        return currentHealth;
    }

    private void HealthInterface()
    {
        float currentColor = 1 - (currentHealth / maxHealth);
        healthEffect.color = new Color(0, 0, 0, currentColor);
    }

    private void DecreaseEnergy()
    {
        if (playerMain.isSprint && currentEnergy >= 0)
        {
            currentEnergy -= energyUseAmount;
        }
    }

    private void IncreaseEnergy()
    {
        if (!playerMain.isSprint && currentEnergy <= maxEnergy)
        {
            currentEnergy += eneryRegenAmount;
            isEnergyRegen = false;
            if (currentEnergy >= maxEnergy)
            {
                currentEnergy = maxEnergy;
                isEnergyRegen = true;
            }
        }
    }

    private void EnergyInterface()
    {
        energyBar.fillAmount = currentEnergy / maxEnergy;

        if (energyEffect.fillAmount > energyBar.fillAmount)
        {
            energyEffect.fillAmount -= energyDecreaseTime * Time.deltaTime;
        }
        else
        {
            energyEffect.fillAmount = energyBar.fillAmount;
        }
    }

    public float IncreaseExperience(float _experience)
    {
        currentExperienceProgress += _experience;
        if (currentExperienceProgress >= maxExperienceProgress)
        {
            currentExperienceProgress = 0;
            currentExperience += 1;

            currentMaxExperienceProgress = maxExperienceProgress;
            maxExperienceProgress = currentMaxExperienceProgress + experienceProgressAmount;
        }
        return currentExperience;
    }

    private void ExperienceInterface()
    {
        experienceBar.fillAmount = currentExperienceProgress / maxExperienceProgress;

        experienceText.text = currentExperience.ToString();
        experienceProgressText.text = currentExperienceProgress + ("/") + maxExperienceProgress;
    }
}
