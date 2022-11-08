using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReviveMeAbility : MonoBehaviour
{
    public BuffSkills ability;
    public Image ability1Image;
    public PlayerController playerController;
    public TextMeshProUGUI manacostText;

    public ManaBar manaBar;

    private bool isCooldown = false;

    public Animator animator;
    public List<GameObject> playerGameObjects = new List<GameObject>();
    public List<String> playerObjectName = new List<String>();
    public GameObject spawnPoint;

    [HideInInspector] public RectTransform skillsPanel;

    Button tempButton;
    GameObject go;

    private void Start()
    {
        skillsPanel = GameObject.Find("Skills Panel").GetComponent<RectTransform>();
        SpawnButton();
        ability1Image.fillAmount = 0;
        spawnPoint = GameObject.Find("ReviveSpawnPoint");

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Player"))
        {
            playerGameObjects.Add(fooObj);

            if (fooObj.name == "AndresBonifacio(Clone)")
                playerObjectName.Add("AndresBonifacio");

            if (fooObj.name == "AntonioLuna(Clone)")
                playerObjectName.Add("AntonioLuna");

            if (fooObj.name == "EmilioAguinaldo(Clone)")
                playerObjectName.Add("EmilioAguinaldo");

            if (fooObj.name == "GabrielaSilang(Clone)")
                playerObjectName.Add("GabrielaSilang");

            if (fooObj.name == "JosefaEscoda(Clone)")
                playerObjectName.Add("JosefaEscoda");

            if (fooObj.name == "JoseRizal(Clone)")
                playerObjectName.Add("JoseRizal");

            if (fooObj.name == "JuanLuna(Clone)")
                playerObjectName.Add("JuanLuna");

            if (fooObj.name == "MelchoraAquino(Clone)")
                playerObjectName.Add("MelchoraAquino");

            if (fooObj.name == "Purmassuri(Clone)")
                playerObjectName.Add("Purmassuri");

            if (fooObj.name == "TeresaMagbanua(Clone)")
                playerObjectName.Add("TeresaMagbanua");
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

        if (playerController.currentMana <= 0 || playerController.currentMana < ability.abilityManacost)
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
            AudioManager.Instance.PlaySFX("Light Spell");
            ReviveMeSpawn();
            isCooldown = true;
            ability1Image.fillAmount = 1;
            playerController.currentMana -= ability.abilityManacost;
            manaBar.SetMana(playerController.currentMana);
        }
    }

    public void ReviveMeSpawn()
    {
        for (int i = 0; i < playerGameObjects.Count; i++)
        {
            if (playerGameObjects[i] == null)
            {
                GameObject prefab;
                prefab = (GameObject)Instantiate(Resources.Load(playerObjectName[i]), spawnPoint.transform.position, Quaternion.identity);
                GameObject skillFx;
                skillFx = Instantiate(ability.abilityPrefab, new Vector3(prefab.transform.position.x + 3, prefab.transform.position.y, prefab.transform.position.z), transform.rotation);
                playerGameObjects.RemoveAt(i);
                playerGameObjects.Insert(i, prefab);
            }
        }
    }
}
