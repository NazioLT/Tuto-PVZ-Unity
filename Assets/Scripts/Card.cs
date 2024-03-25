using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Card : MonoBehaviour
{
    [SerializeField] private Plant _plantToPlace = null;

    private Deck _deck = null;

    public void Init(Deck deck)
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        _deck = deck;
    }

    private void OnClick()
    {
        _deck.ClickOnCard(_plantToPlace);
    }
}
