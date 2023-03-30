using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    private string _enemyName;
    public string enemyName
    {
        get { return _enemyName; }
        set { _enemyName = value; }
    }

    private float enemyDamage;
    public float EnemyDamage
    {
        get { return enemyDamage; }
        set { enemyDamage = value; }
    }

    public float regenTimer;
    public bool isAttack;
    public bool isStartTimer;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        enemyName = "Clayman";
        enemyDamage = 1.5f;
        this.gameObject.name = enemyName;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        takeDamageToPlayer();
    }

    void takeDamageToPlayer()
    {
        if (!isAttack)
        {
            if (!isStartTimer)
            {
                isStartTimer = true;
                regenTimer = 0.0f;
            }
            else
            {
                regenTimer += Time.deltaTime;
                if (regenTimer >= 0.5f)
                {
                    PlayerManager.Instance.IncreaseHealth();
                    isStartTimer = false;
                    regenTimer = 0.0f;
                }
            }
        }
        else
        {
            isStartTimer = false;
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager.Instance.DecreaseHealth(enemyDamage);
            isAttack = true;
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isAttack = false;
        }
    }


}