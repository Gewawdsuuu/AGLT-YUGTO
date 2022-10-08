using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class HeroProfileHandler : MonoBehaviour
{
    [Header("Other Game Objects")]
    public GameObject profileTab;

    [Header("Toggle Groups")]
    public ToggleGroup profileToggleGroup;
    public ToggleGroup heroToggleGroup;

    [Header("Images")]
    [SerializeField] private Image defaultHeroImage;
    public Sprite[] newHeroImage;

    [Header("Hero Texts")]
    public TextMeshProUGUI heroName;

    [Header("Skill Texts")]
    [SerializeField] private TextMeshProUGUI defaultSkill1Name;
    public string[] newSkill1Name;
    [SerializeField] private TextMeshProUGUI defaultSkill1Description;
    public string[] newSkill1Description;
    [SerializeField] private TextMeshProUGUI defaultSkill2Name;
    public string[] newSkill2Name;
    [SerializeField] private TextMeshProUGUI defaultSkill2Description;
    public string[] newSkill2Description;

    [Header("About Hero Texts")]
    [SerializeField] private TextMeshProUGUI defaultStoryTxt;
    public string[] newStoryTxt;
    [SerializeField] private TextMeshProUGUI defaultBornDate;
    public string[] newBornDate;
    [SerializeField] private TextMeshProUGUI defaultFullNametxt;
    public string[] newFullNametxt;
    [SerializeField] private TextMeshProUGUI defaultClassTxt;
    public string[] newClassTxt;


    // Start is called before the first frame update
    void Start()
    {
        if (profileToggleGroup == null) profileToggleGroup = GetComponent<ToggleGroup>();
        if (heroToggleGroup == null) heroToggleGroup = GetComponent<ToggleGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ProfileSelectedToggle().name == "ProfileToggle")
        {
            profileTab.SetActive(true);
            OnChange();
        }
        else if (ProfileSelectedToggle().name == "EquipToggle")
        {
            profileTab.SetActive(false);
        }

    }

    public Toggle ProfileSelectedToggle()
    {
        // May have several selected toggles
        foreach (var t in profileToggleGroup.ActiveToggles())
        {
            if (t.isOn) return t;
        }
        return null;
    }

    public Toggle HeroSelectedToggle()
    {
        // May have several selected toggles
        foreach (var t in heroToggleGroup.ActiveToggles())
        {
            if (t.isOn) return t;
        }
        return null;
    }

    public void OnChange()
    {
        if (HeroSelectedToggle().name == "SilangToggle")
        {
            defaultHeroImage.sprite = newHeroImage[0];
            heroName.text = "Gabriela";
            defaultSkill1Name.text = newSkill1Name[0];
            defaultSkill1Description.text = newSkill1Description[0];
            defaultSkill2Name.text = newSkill2Name[0];
            defaultSkill2Description.text = newSkill2Description[0];
            defaultStoryTxt.text = newStoryTxt[0];
            defaultBornDate.text = newBornDate[0];
            defaultFullNametxt.text = newFullNametxt[0];
            defaultClassTxt.text = newClassTxt[0];
        }
        else if (HeroSelectedToggle().name == "BonifacioToggle")
        {
            defaultHeroImage.sprite = newHeroImage[1];
            heroName.text = "Andres";
            defaultSkill1Name.text = newSkill1Name[0];
            defaultSkill1Description.text = newSkill1Description[0];
            defaultSkill2Name.text = newSkill2Name[0];
            defaultSkill2Description.text = newSkill2Description[0];
            defaultStoryTxt.text = newStoryTxt[1];
            defaultBornDate.text = newBornDate[1];
            defaultFullNametxt.text = newFullNametxt[1];
            defaultClassTxt.text = newClassTxt[0];
        }
        else if (HeroSelectedToggle().name == "LunaToggle")
        {
            defaultHeroImage.sprite = newHeroImage[2];
            heroName.text = "Antonio";
            defaultSkill1Name.text = newSkill1Name[5];
            defaultSkill1Description.text = newSkill1Description[5];
            defaultSkill2Name.text = newSkill2Name[5];
            defaultSkill2Description.text = newSkill2Description[5];
            defaultStoryTxt.text = newStoryTxt[2];
            defaultBornDate.text = newBornDate[2];
            defaultFullNametxt.text = newFullNametxt[2];
            defaultClassTxt.text = newClassTxt[4];
        }
        else if (HeroSelectedToggle().name == "LunaJToggle")
        {
            defaultHeroImage.sprite = newHeroImage[3];
            heroName.text = "Juan";
            defaultSkill1Name.text = newSkill1Name[3];
            defaultSkill1Description.text = newSkill1Description[3];
            defaultSkill2Name.text = newSkill2Name[3];
            defaultSkill2Description.text = newSkill2Description[3];
            defaultStoryTxt.text = newStoryTxt[3];
            defaultBornDate.text = newBornDate[3];
            defaultFullNametxt.text = newFullNametxt[3];
            defaultClassTxt.text = newClassTxt[3];
        }
        else if (HeroSelectedToggle().name == "AguinaldoToggle")
        {
            defaultHeroImage.sprite = newHeroImage[4];
            heroName.text = "Emilio";
            defaultSkill1Name.text = newSkill1Name[1];
            defaultSkill1Description.text = newSkill1Description[1];
            defaultSkill2Name.text = newSkill2Name[1];
            defaultSkill2Description.text = newSkill2Description[1];
            defaultStoryTxt.text = newStoryTxt[4];
            defaultBornDate.text = newBornDate[4];
            defaultFullNametxt.text = newFullNametxt[4];
            defaultClassTxt.text = newClassTxt[1];
        }
        else if (HeroSelectedToggle().name == "EscodaToggle")
        {
            defaultHeroImage.sprite = newHeroImage[5];
            heroName.text = "Josefa";
            defaultSkill1Name.text = newSkill1Name[2];
            defaultSkill1Description.text = newSkill1Description[2];
            defaultSkill2Name.text = newSkill2Name[2];
            defaultSkill2Description.text = newSkill2Description[2];
            defaultStoryTxt.text = newStoryTxt[5];
            defaultBornDate.text = newBornDate[5];
            defaultFullNametxt.text = newFullNametxt[5];
            defaultClassTxt.text = newClassTxt[2];
        }
        else if (HeroSelectedToggle().name == "AquinoToggle")
        {
            defaultHeroImage.sprite = newHeroImage[6];
            heroName.text = "Melchora";
            defaultSkill1Name.text = newSkill1Name[2];
            defaultSkill1Description.text = newSkill1Description[2];
            defaultSkill2Name.text = newSkill2Name[2];
            defaultSkill2Description.text = newSkill2Description[2];
            defaultStoryTxt.text = newStoryTxt[6];
            defaultBornDate.text = newBornDate[6];
            defaultFullNametxt.text = newFullNametxt[6];
            defaultClassTxt.text = newClassTxt[2];
        }
        else if (HeroSelectedToggle().name == "PurmassuriToggle")
        {
            defaultHeroImage.sprite = newHeroImage[7];
            heroName.text = "Purmassuri";
            defaultSkill1Name.text = newSkill1Name[3];
            defaultSkill1Description.text = newSkill1Description[3];
            defaultSkill2Name.text = newSkill2Name[3];
            defaultSkill2Description.text = newSkill2Description[3];
            defaultStoryTxt.text = newStoryTxt[7];
            defaultBornDate.text = newBornDate[7];
            defaultFullNametxt.text = newFullNametxt[7];
            defaultClassTxt.text = newClassTxt[3];
        }
        else if (HeroSelectedToggle().name == "RizalToggle")
        {
            defaultHeroImage.sprite = newHeroImage[8];
            heroName.text = "Jose";
            defaultSkill1Name.text = newSkill1Name[4];
            defaultSkill1Description.text = newSkill1Description[4];
            defaultSkill2Name.text = newSkill2Name[4];
            defaultSkill2Description.text = newSkill2Description[4];
            defaultStoryTxt.text = newStoryTxt[8];
            defaultBornDate.text = newBornDate[8];
            defaultFullNametxt.text = newFullNametxt[8];
            defaultClassTxt.text = newClassTxt[4];
        }
        else if (HeroSelectedToggle().name == "MagbanuaToggle")
        {
            defaultHeroImage.sprite = newHeroImage[9];
            heroName.text = "Teresa";
            defaultSkill1Name.text = newSkill1Name[2];
            defaultSkill1Description.text = newSkill1Description[2];
            defaultSkill2Name.text = newSkill2Name[2];
            defaultSkill2Description.text = newSkill2Description[2];
            defaultStoryTxt.text = newStoryTxt[9];
            defaultBornDate.text = newBornDate[9];
            defaultFullNametxt.text = newFullNametxt[9];
            defaultClassTxt.text = newClassTxt[1];
        }
    }
}
