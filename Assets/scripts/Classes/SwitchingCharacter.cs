using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchingCharacter : MonoBehaviour
{
    public GameObject Player;
    public GameObject HumanPrefab;
    public GameObject DwarfPrefab;
    public GameObject RobotPrefab;
    public Button HumanButton;
    public Button DwarfButton;
    public Button RobotButton;

    void Start()
    {
        if (HumanButton != null)
            HumanButton.onClick.AddListener(() => SwitchCharacter(HumanPrefab));
        if (DwarfButton != null)
            DwarfButton.onClick.AddListener(() => SwitchCharacter(DwarfPrefab));
        if (RobotButton != null)
            RobotButton.onClick.AddListener(() => SwitchCharacter(RobotPrefab));
    }


    void SwitchCharacter(GameObject prefab)
    {
        Destroy(Player);
        Player = Instantiate(prefab);
    }
}

