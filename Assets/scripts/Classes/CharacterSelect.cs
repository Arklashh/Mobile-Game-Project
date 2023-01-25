using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSelect : MonoBehaviour, IPointerClickHandler
{
    public GameObject Human;
    public GameObject Dwarf;
    public GameObject Robot;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerPress == gameObject)
        {
            if (gameObject.name == "Human")
            {
                InstantiatePlayer1();
            }
            if (gameObject.name == "Dwarf")
            {
                InstantiatePlayer2();
            }
            if (gameObject.name == "Robot")
            {
                InstantiatePlayer3();
            }
        }
    }

    void InstantiatePlayer1()
    {
        GameObject player = Instantiate(Human);
        player.AddComponent<Human>();
    }

    void InstantiatePlayer2()
    {
        GameObject player = Instantiate(Dwarf);
        player.AddComponent<Dwarf>();
    }

    void InstantiatePlayer3()
    {
        GameObject player = Instantiate(Robot);
        player.AddComponent<Robot>();
    }
}
