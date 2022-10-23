using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleShotAbility : MonoBehaviour
{
    public ProjectileSkills ability;
    public Image ability1Image;
    public Button ability1Button;

    public PlayerController playerController;

    public ManaBar manaBar;

    public Animator animator;

    private bool isCooldown = false;

    void Start()
    {
        ability1Image.fillAmount = 0;

        ability1Button.onClick.AddListener(() => AbilitySpawn());
    }

    private void Update()
    {
        if (isCooldown)
        {
            ability1Image.fillAmount -= 1 / ability.abilityCooldown * Time.deltaTime;

            if (ability1Image.fillAmount <= 0)
            {
                ability1Image.fillAmount = 0;
                isCooldown = false;
            }
        }

        manaBar.SetMana(playerController.currentMana);
    }

    public void AbilitySpawn()
    {
        if (isCooldown == false && playerController.currentMana > 0)
        {
            StartCoroutine(DoubleSpawn());
            isCooldown = true;
            ability1Image.fillAmount = 1;
            playerController.currentMana -= ability.abilityManacost;
            Debug.Log("Current Mana: " + playerController.currentMana);
        }

    }

    IEnumerator DoubleSpawn()
    {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);
        GameObject newDoubleShotObject = Instantiate(ability.abilityPrefab, transform.position + (transform.forward * 2), transform.rotation);
        yield return new WaitForSeconds(0.5f);
        newDoubleShotObject = Instantiate(ability.abilityPrefab, transform.position + (transform.forward * 2), transform.rotation);
    }
}
