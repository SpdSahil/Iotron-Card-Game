using UnityEngine;

public class Card_Info : MonoBehaviour
{
    // References to UI elements for displaying card number
    [SerializeField] private TMPro.TMP_Text cardNumTop;
    [SerializeField] private TMPro.TMP_Text cardNumBottom;

    // Reference to the SpriteRenderer for the card family icon
    [SerializeField] private SpriteRenderer cardFamily;

    // Array of sprites for different card families (0 for heart, 1 for spade, 2 for diamond, 3 for clover)
    [SerializeField] private Sprite[] cardFamilies;

    private string cardName;  // The name of the card (e.g., "2H", "AS")
    private char family;      // The family of the card (e.g., 'H' for hearts)
    private int num;          // The number of the card (1-13)

    public void Initialize(char family, int num)
    {
        this.family = family;
        this.num = num;

        cardName = num.ToString() + family;
        gameObject.name = cardName;

        AssignFamily();
        AssignNum();
    }

    private void AssignNum()
    {
        string displayNum = num switch
        {
            1 => "A",
            11 => "J",
            12 => "Q",
            13 => "K",
            _ when num >= 2 && num <= 10 => num.ToString(),
            _ => null
        };

        if (displayNum != null)
        {
            cardNumTop.text = displayNum;
            cardNumBottom.text = displayNum;
        }
        else
        {
            Debug.LogError($"{cardName}: Card Number not assigned");
        }
    }

    private void AssignFamily()
    {
        switch (family)
        {
            case 'H':
                cardFamily.sprite = cardFamilies[0];
                SetCardColor(Color.red);
                break;
            case 'S':
                cardFamily.sprite = cardFamilies[1];
                SetCardColor(Color.black);
                break;
            case 'D':
                cardFamily.sprite = cardFamilies[2];
                SetCardColor(Color.red);
                break;
            case 'C':
                cardFamily.sprite = cardFamilies[3];
                SetCardColor(Color.black);
                break;
            default:
                Debug.LogError($"{cardName}: Card Family not assigned");
                break;
        }
    }

    private void SetCardColor(Color color)
    {
        cardNumTop.color = color;
        cardNumBottom.color = color;
    }
}
