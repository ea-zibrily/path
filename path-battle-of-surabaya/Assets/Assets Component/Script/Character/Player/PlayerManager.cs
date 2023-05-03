using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    
    [Serializable]
    public struct InterfaceComponent
    {
        [Header("Health UI Component")]
        public Image healthEffect;
        
        [Header("Energy UI Component")]
        public Image energyBar;
        public Image energyEffect;
        
        [Header("Experience UI Component")]
        public TextMeshProUGUI experienceText;
        public TextMeshProUGUI experienceProgressText;
        public Image experienceBar;
    }
    
    [Header("Health Component")]
    public float maxHealth;
    private float currentHealth;
    [SerializeField] private float healthRegenAmount;
    public bool isDeath;

    [Header("Energy Component")]
    public float maxEnergy;
    private float currentEnergy;
    [SerializeField] private float energyUseAmount;
    [SerializeField] private float eneryRegenAmount;
    [SerializeField] private float energyDecreaseTime;
    public bool isEnergyRegen;

    [Header("Experience Component")]
    public float maxExperienceProgress;
    private float currentMaxExperienceProgress;
    private float currentExperienceProgress;
    private float experienceProgressAmount;
    private float currentExperience;

    [Space]
    public InterfaceComponent interfaceComponent;
    
    [Header("Reference")]
    private PlayerMainController _playerMainController;

    protected override void Awake()
    {
        _playerMainController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMainController>();

        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
    }

    private void Update()
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

    public void DecreaseHealth(float _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDeath = true;
        }
    }

    public void IncreaseHealth()
    {
        currentHealth += healthRegenAmount * Time.deltaTime;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void HealthInterface()
    {
        float currentColor = 1 - (currentHealth / maxHealth);
        interfaceComponent.healthEffect.color = new Color(0, 0, 0, currentColor);
    }

    private void DecreaseEnergy()
    {
        if (_playerMainController.isSprint && currentEnergy >= 0)
        {
            currentEnergy -= energyUseAmount;
        }
    }

    private void IncreaseEnergy()
    {
        if (!_playerMainController.isSprint && currentEnergy <= maxEnergy)
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
        interfaceComponent.energyBar.fillAmount = currentEnergy / maxEnergy;

        if (interfaceComponent.energyEffect.fillAmount > interfaceComponent.energyBar.fillAmount)
        {
            interfaceComponent.energyEffect.fillAmount -= energyDecreaseTime * Time.deltaTime;
        }
        else
        {
            interfaceComponent.energyEffect.fillAmount = interfaceComponent.energyBar.fillAmount;
        }
    }

    public void IncreaseExperience(float _experience)
    {
        currentExperienceProgress += _experience;
        if (currentExperienceProgress >= maxExperienceProgress)
        {
            currentExperienceProgress = 0;
            currentExperience += 1;

            currentMaxExperienceProgress = maxExperienceProgress;
            maxExperienceProgress = currentMaxExperienceProgress + experienceProgressAmount;
        }
    }

    private void ExperienceInterface()
    {
        interfaceComponent.experienceBar.fillAmount = currentExperienceProgress / maxExperienceProgress;

        interfaceComponent.experienceText.text = currentExperience.ToString();
        interfaceComponent.experienceProgressText.text = currentExperienceProgress + "/" + maxExperienceProgress;
    }
}
