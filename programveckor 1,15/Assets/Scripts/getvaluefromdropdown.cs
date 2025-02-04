using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class getvaluefromdropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    private string dropdownKey = "DropdownSelection";

    void Start()
    {
        LoadDropdownSelection();
        dropdown.onValueChanged.AddListener(delegate { SaveDropdownSelection(); });
    }

    void SaveDropdownSelection()
    {
        PlayerPrefs.SetInt(dropdownKey, dropdown.value);

        if(dropdown.value == 0)
        {
            DifficultyManager.SetDifficulty(Difficulty.Easy);
        }        
        if(dropdown.value == 1)
        {
            DifficultyManager.SetDifficulty(Difficulty.Medium);
        }        
        if(dropdown.value == 2)
        {
            DifficultyManager.SetDifficulty(Difficulty.Hard);
        }
        

       
        PlayerPrefs.Save();
    }
    void LoadDropdownSelection()
    {
        if (PlayerPrefs.HasKey(dropdownKey))
        {
            int savedIndex = PlayerPrefs.GetInt(dropdownKey);

            if (savedIndex >= 0 && savedIndex < dropdown.options.Count)
            {
                dropdown.value = savedIndex;
            }
        }
    }

}
