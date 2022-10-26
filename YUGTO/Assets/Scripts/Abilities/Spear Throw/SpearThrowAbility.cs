using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpearThrowAbility : MonoBehaviour
{
    public ProjectileSkills ability;
    public Image ability1Image;
    public PlayerController playerController;

    public ManaBar manaBar;

    private bool isCooldown = false;

    public Animator animator;

    [HideInInspector] public RectTransform skillsPanel;
    private void Start()
    {
        skillsPanel = GameObject.Find("Skills Panel").GetComponent<RectTransform>();
        SpawnButton();
        ability1Image.fillAmount = 0;

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

    public void SpawnButton()
    {
        GameObject go = Instantiate(ability.skillButtonPrefab) as GameObject;
        go.transform.SetParent(skillsPanel, false);
        go.transform.localScale = new Vector3(1, 1, 1);

        var cooldownImage = go.transform.GetChild(1);
        ability1Image = cooldownImage.GetComponent<Image>();

        Button tempButton = go.GetComponent<Button>();

        tempButton.onClick.AddListener(() => AbilitySpawn());
    }

    public void AbilitySpawn()
    {
        if (isCooldown == false)
        {
            StartCoroutine(SpearSpawn());
            isCooldown = true;
            ability1Image.fillAmount = 1;
            playerController.currentMana -= ability.abilityManacost;
            manaBar.SetMana(playerController.currentMana);
        }
    }

    IEnumerator SpearSpawn()
    {
        animator.SetTrigger("Attack2");
        yield return new WaitForSeconds(1f);
        GameObject newSpearThrowObject = Instantiate(ability.abilityPrefab, transform.position + (transform.forward * 2), transform.rotation);
    }
}
