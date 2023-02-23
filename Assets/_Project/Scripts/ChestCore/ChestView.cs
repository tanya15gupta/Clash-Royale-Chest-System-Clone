using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ChestSystem.Chest
{
	public class ChestView : MonoBehaviour
	{
		[SerializeField] private RawImage m_ChestSprite;
		private ChestController m_ChestController;
		public TextMeshProUGUI ChestTimerText { get; private set; }
		private void Start()
		{
			ChestTimerText = GetComponentInChildren<TextMeshProUGUI>();
			ChestTimerText.text = m_ChestController.GetChestTypeName();
		}
		public void SetChestImage(Texture _chestTexture)
		{
			m_ChestSprite.texture = _chestTexture;
		}

		public void SetChestController(ChestController _chestController)
		{
			m_ChestController = _chestController;
		}

		public void OnChestClicked()
		{
			m_ChestController.EnterUnlockStateCheck();
		}
		public void DestroyChest()
		{
			m_ChestController.m_SlotController.SetSlotIsEmpty();
			Destroy(this.gameObject);
		}
	}
}

