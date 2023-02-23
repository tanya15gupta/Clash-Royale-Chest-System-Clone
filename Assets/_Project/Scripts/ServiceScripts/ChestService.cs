using ChestSystem.Chest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem
{
	public class ChestService : MonoSingleton<ChestService>
	{
		[SerializeField] private ChestConfigSO m_ChestConfig;
		[SerializeField] private ChestView m_ChestPrefab;
		[SerializeField] private ChestSO m_ChesSO;
		[SerializeField] private int m_ChestsUnlockLimit;
		private Queue<ChestController> m_ChestsUnlockQueue;
		private bool b_IsUnlocking;
		private void Start()
		{
			m_ChestsUnlockQueue = new Queue<ChestController>();
		}

		public ChestController CreateChest(Transform _spawnPoint)
		{
			m_ChesSO = ChestRandomizer();
			ChestController controller = new ChestController(m_ChestPrefab, new ChestModel(m_ChesSO), _spawnPoint);
			return controller;
		}

		public ChestSO ChestRandomizer()
		{
			return m_ChestConfig.ChestConfigs[Random.Range(0, m_ChestConfig.ChestConfigs.Length)].ChestScriptableObject;
		}

		public void EnqueueChestToUnlock(ChestController _chestController) => m_ChestsUnlockQueue.Enqueue(_chestController);

		public ChestController DequeueChest() => m_ChestsUnlockQueue.Dequeue();

		public bool IsChestUnlocking() => b_IsUnlocking;

		public void SetIsChestUnlocking(bool _isUnlocking) => b_IsUnlocking = _isUnlocking;

		public bool GetCanEnqueueChest() => m_ChestsUnlockLimit >= m_ChestsUnlockQueue.Count;

		public void UnlockChestInQueue()
		{
			if (m_ChestsUnlockQueue.Count == 0)
				return;
			ChestController chestToUnlock = DequeueChest();
			chestToUnlock.ChestStatusUpdate();
		}
	}
}
