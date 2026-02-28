using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public TextMeshProUGUI coinText;
    int coin = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddCoin()
    {
        coin++;
        coinText.text = "Coin : " + coin;
    }
}
