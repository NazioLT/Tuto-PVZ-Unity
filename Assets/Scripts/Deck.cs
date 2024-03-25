using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// S'occupe de gerer les cartes et de choisir la plante a instancier.
/// </summary>
public class Deck : MonoBehaviour
{
    private static Deck _instance = null;

    private Card[] _cards;
    private Plant _plantToPlace = null;

    public static Deck Instance => _instance;

    public void ClickOnCard(Plant plant)
    {
        _plantToPlace = plant;
    }

    public Plant GetPlantToPlace()
    {
        //Supprime après pour qu'on ne puisse pas spammer
        Plant plant = _plantToPlace;
        _plantToPlace = null;

        return plant;
    }

    private void Awake()
    {
        _instance = this;

        _cards = FindObjectsOfType<Card>();

        foreach (var card in _cards)
        {
            card.Init(this);
        }
    }


}
