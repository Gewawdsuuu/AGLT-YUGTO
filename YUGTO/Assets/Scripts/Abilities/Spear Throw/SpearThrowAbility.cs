using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpearThrowAbility : MonoBehaviour
{
    //public RectTransform skillsPanel;

    public ProjectileSkills ability;
    public Image ability1Image;
    public Button ability1Button;

    private bool isCooldown = false;

    public Animator animator;

    private void Start()
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
    }

    //public void SpawnButton()
    //{
    //    GameObject go = Instantiate(ability.skillButtonPrefab) as GameObject;
    //    go.transform.SetParent(skillsPanel, false);
    //    go.transform.localScale = new Vector3(1, 1, 1);

    //    Button tempButton = go.GetComponent<Button>();

    //    tempButton.onClick.AddListener(() => AbilitySpawn());
    //}

    public void AbilitySpawn()
    {
        if (isCooldown == false)
        {
            StartCoroutine(SpearSpawn());
            isCooldown = true;
            ability1Image.fillAmount = 1;
        }
    }

    IEnumerator SpearSpawn()
    {
        animator.SetTrigger("Attack2");
        yield return new WaitForSeconds(1f);
        GameObject newSpearThrowObject = Instantiate(ability.abilityPrefab, transform.position + (transform.forward * 2), transform.rotation);
    }
}
