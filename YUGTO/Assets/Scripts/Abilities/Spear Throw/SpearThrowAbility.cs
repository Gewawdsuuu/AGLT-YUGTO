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
    public GameObject spawnPoint;

    private bool isCooldown = false;

    public Animator animator;

    [HideInInspector] public RectTransform skillsPanel;

    GameObject go;
    Button tempButton;

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

        if (playerController.currentMana <= 0 || playerController.currentMana < ability.abilityManacost || playerController.isDead == true)
        {
            tempButton.interactable = false;
            tempButton.enabled = false;
            tempButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            tempButton.interactable = true;
            tempButton.enabled = true;
            tempButton.GetComponent<Image>().color = Color.white;
        }

        manaBar.SetMana(playerController.currentMana);
    }

    public void SpawnButton()
    {
        go = Instantiate(ability.skillButtonPrefab) as GameObject;
        go.transform.SetParent(skillsPanel, false);
        go.transform.localScale = new Vector3(1, 1, 1);

        var cooldownImage = go.transform.GetChild(1);
        ability1Image = cooldownImage.GetComponent<Image>();

        tempButton = go.GetComponent<Button>();

        tempButton.onClick.AddListener(() => AbilitySpawn());
    }

    public void AbilitySpawn()
    {
        if (isCooldown == false && playerController.currentMana > 0 && playerController.currentMana >= ability.abilityManacost)
        {
            AudioManager.Instance.PlaySFX("Spear Throw");
            SpearSpawn();
            isCooldown = true;
            ability1Image.fillAmount = 1;
            playerController.currentMana -= ability.abilityManacost;
            manaBar.SetMana(playerController.currentMana);
        }
    }

    public void SpearSpawn()
    {
        animator.SetTrigger("Attack2");
        GameObject newSpearThrowObject = Instantiate(ability.abilityPrefab, spawnPoint.transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 90f));
    }
}
