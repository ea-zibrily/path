using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float maxHp;
    private float currentHp;

    void Awake()
    {
        currentHp = maxHp;
    }
    
    public void DecreaseHealth(float damageTaken)
    {
        currentHp -= damageTaken;
        if (currentHp <= 0)
        {
            Destroy(gameObject);
            PlayerManager.Instance.IncreaseExperience(5f);
        }
        Debug.Log($"enemy hp is {currentHp}");
    }
}
