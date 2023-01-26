using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingCharacter : MonoBehaviour
{
    public GameObject Human;
    public GameObject Dwarf;
    public GameObject Robot;

    void Update()
    {
        GameObject player = GameObject.Find("Player");
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(player);
            player = Instantiate(Human);
            player.name = "Player";
            //player.AddComponent<FixedJoystick>();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(player);
            player = Instantiate(Dwarf);
            player.name = "Player";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Destroy(player);
            player = Instantiate(Robot);
            player.name = "Player";
        }

    }
}