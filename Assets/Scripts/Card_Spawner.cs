using UnityEngine;

public class Card_Spawner : MonoBehaviour
{
    [SerializeField] private Card_Info cardPrefab;  // Reference to the card prefab
    [SerializeField] private GameObject cardParent;  // Parent object to organize cards in the hierarchy
    [SerializeField] private int startXPos = 0;      // Starting X position for card placement
    [SerializeField] private int startZPos = 6;      // Starting Z position for card placement
    [SerializeField] private int xOffset = 4;        // Horizontal spacing between cards
    [SerializeField] private int zOffset = 4;        // Vertical spacing between cards

    private void Start()
    {
        GenerateDeck();
    }

    private void GenerateDeck()
    {
        for (int z = startZPos; z >= startZPos - 12; z -= zOffset)
        {
            for (int x = startXPos; x >= startXPos - 48; x -= xOffset)
            {
                // Create a new Vector3 for the position of the current card in the grid
                Vector3 position = new Vector3(x, 0f, z);

                // Spawn the card at the calculated position, determining its family and number based on its position
                SpawnCard(position, DetermineFamily(z), DetermineNum(x));
            }
        }
    }

    private void SpawnCard(Vector3 position, char family, int number)
    {
        // Instantiate the card prefab
        Card_Info newCard = Instantiate(cardPrefab, position, Quaternion.identity);

        // Set the card under the specified parent in the hierarchy
        newCard.transform.SetParent(cardParent.transform);

        // Initialize the card with the determined family and number
        newCard.Initialize(family, number + 1);  // `+1` to convert from 0-based to 1-based numbering
    }

    private char DetermineFamily(int zPos)
    {
        return zPos switch
        {
            6 => 'H',  // Hearts
            2 => 'S',  // Spades
            -2 => 'D', // Diamonds
            _ => 'C'   // Clovers
        };
    }

    private int DetermineNum(int xPos)
    {
        return (-xPos) / xOffset;
    }
}
