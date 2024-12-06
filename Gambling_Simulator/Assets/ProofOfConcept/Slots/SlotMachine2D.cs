using UnityEngine;
using TMPro;

public class SlotMachine2D : MonoBehaviour
{
    public TextMeshProUGUI reel1, reel2, reel3;  // References for each reel text
    public int payoutMultiplier = 10; // Adjust payout as needed

    private int[] results = new int[3];

    // Spins the reels
    public void Spin()
    {
        // Generate a random number for each reel
        results[0] = Random.Range(1, 8); // 1 to 7
        results[1] = Random.Range(1, 8);
        results[2] = Random.Range(1, 8);

        // Display each number on the respective reel
        reel1.text = results[0].ToString();
        reel2.text = results[1].ToString();
        reel3.text = results[2].ToString();

        CalculatePayout();  // Calculate the payout based on the results
    }

    // Calculates payout based on matches
    private void CalculatePayout()
    {
        if (results[0] == results[1] && results[1] == results[2]) // All three match
        {
            int payout = results[0] * payoutMultiplier;
            Debug.Log("Jackpot! Payout: " + payout);
        }
        else if (results[0] == results[1] || results[1] == results[2] || results[0] == results[2]) // Two match
        {
            int payout = 5;
            Debug.Log("Partial Match! Payout: " + payout);
        }
        else
        {
            Debug.Log("No match, better luck next time!");
        }
    }
}
