using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private Animator animator;
    
    public AnimationClip[] animations;

    public int attack;
    public int defence;
    public int health;
    public int maxHealth;

    [SerializeField] TMP_Text healthText;
    [SerializeField] Image healthBar;
    [SerializeField] Image healthBarDifference;

    public bool updatingBar = false;
    public bool abilityCharged;

    public int attacks;

    private GameManager gameManager;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();

        maxHealth = health;
    }

    private void Update()
    {
        DynamicBarUpdate();
    }

    public void PlayAnimation(int index)
    {
        Debug.Log($"{this.name}: played animation {animations[index].name}");
        animator.Play(animations[index].name);
    }

    public void Attack(Character defender)
    {
        PlayAnimation(1);

        attacks++;

        if (attacks >= 2)
        {
            attacks = 0;
            abilityCharged = true;
        }

        defender.GiveDamage(attack, defender);

        defender.UpdateUI();

        Debug.Log($"{defender.name}: Damage {attack} given to {defender.name} from {this.name}");
    }

    public void UseAbility()
    {
        if (abilityCharged)
        {
            abilityCharged = false;
            Debug.Log($"{this.name}: used ability");
        }
    }

    public void GiveDamage(int damage, Character defender)
    {
        if (health > 0)
        {
            defender.health -= damage;
        }
        else if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{this.name}: dead");
        Destroy(this.gameObject);
    }

    public void UpdateUI()
    {
        updatingBar = true;
        healthText.text = $"{health}/{maxHealth}";
    }

    private void DynamicBarUpdate()
    {
        if (updatingBar)
        {
            float newFill = (float)health / (float)maxHealth;

            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, newFill, 5f * Time.deltaTime);
            healthBarDifference.fillAmount = Mathf.Lerp(healthBarDifference.fillAmount, healthBar.fillAmount, 2.5f * Time.deltaTime);
        }
    }
}
