using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Chest
{
	public class ChestModel
	{
		public string name { get; private set; }
		public float unlockDuration { get; private set; }
		public int minGems { get; private set; }
		public int maxGems { get; private set; }
		public int minCoins { get; private set; }
		public int maxCoins { get; private set; }
		public int unlockAmount { get; private set; }
		public Texture chestTexture { get; private set; }

		public ChestModel(ChestSO _chestSo)
		{
			name = _chestSo.Name;
			unlockDuration = _chestSo.UnlockDuration;
			minGems = _chestSo.MinGems;
			maxGems = _chestSo.MaxGems;
			minCoins = _chestSo.MinCoins;
			maxCoins = _chestSo.MaxCoins;
			unlockAmount = _chestSo.UnlockAmount;
			chestTexture = _chestSo.ChestTexture;
		}
	}
}