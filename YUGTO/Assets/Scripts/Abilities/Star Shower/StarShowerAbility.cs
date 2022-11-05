using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarShowerAbility : MonoBehaviour
{
    public ProjectileSkills ability;
    public Image ability1Image;
    public PlayerController playerController;
    public TextMeshProUGUI manacostText;

    public ManaBar manaBar;

    private bool isCooldown = false;

    public Animator animator;
    public List<GameObject> enemyGameObjects = new List<GameObject>();

    [HideInInspector] public RectTransform skillsPanel;

    GameObject go;
    Button tempButton;

    private void Start()
    {
        skillsPanel = GameObject.Find("Skills Panel").GetComponent<RectTransform>();
        SpawnButton();
        ability1Image.fillAmount = 0;

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyGameObjects.Add(fooObj);
        }
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

        for (int i = 0; i < enemyGameObjects.Count; i++)
        {
            if (enemyGameObjects[i] == null)
            {
                enemyGameObjects.RemoveAt(i);
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

        var cooldownText = go.transform.GetChild(2);
        manacostText = cooldownText.GetComponent<TextMeshProUGUI>();
        manacostText.text = ability.abilityManacost.ToString();

        tempButton = go.GetComponent<Button>();

        tempButton.onClick.AddListener(() => AbilitySpawn());
    }


    public void AbilitySpawn()
    {
        if (isCooldown == false && playerController.currentMana > 0 && playerController.currentMana >= ability.abilityManacost)
        {
            AudioManager.Instance.PlaySFX("Cast Spell");
            StarSpawn();
            isCooldown = true;
            ability1Image.fillAmount = 1;
            playerController.currentMana -= ability.abilityManacost;
            manaBar.SetMana(playerController.currentMana);
        }
    }

    public void StarSpawn()
    {
        GameObject newStarObject;

        for (int i = 0; i < enemyGameObjects.Count; i++)
        {
            newStarObject = Instantiate(ability.abilityPrefab, new Vector3(enemyGameObjects[i].transform.position.x, 65, 0), transform.rotation);
        }
    }
}
