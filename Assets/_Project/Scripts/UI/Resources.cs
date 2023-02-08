using TMPro;
using UnityEngine;

namespace ChestSystem
{
    public class Resources : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_Coins;
        [SerializeField] private TextMeshProUGUI m_Gems;
		private int m_GemsCount;
		private int m_CoinsCount;
		private void Start()
		{
			m_Coins.text = "0";
			m_Gems.text = "0";
		}

		public int GetGemsCount() => m_GemsCount;

		public void IncreaseCounter(int _gems, int _coins)
		{
			m_GemsCount += _gems;
			m_CoinsCount += _coins;
			RefreshUI();
		}

		public void DecreaseGemsCounter(int _gems)
		{
			m_GemsCount -= _gems;
			RefreshUI();
		}

		private void RefreshUI()
		{
			m_Coins.text = m_CoinsCount.ToString();
			m_Gems.text = m_GemsCount.ToString();
		}
	}
}
