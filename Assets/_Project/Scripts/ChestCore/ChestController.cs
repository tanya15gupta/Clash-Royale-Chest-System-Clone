using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Collections;


namespace ChestSystem.Chest
{
	public class ChestController
	{
		private ChestView m_ChestView;
		private ChestModel m_ChestModel;
		private ChestStates m_CurrentState;
		private float m_Timer;
		private UIService m_UIService;
		private ChestService m_ChestService;
		private int m_GemsCount;
		private int m_CoinsCount;
		private int timerToGems;
		public SlotController m_SlotController { get; private set; }
		public ChestController(ChestView _chestView, ChestModel _chestModal, Transform _spawnPoint) 
		{
			m_ChestModel = _chestModal;
			m_ChestView = GameObject.Instantiate<ChestView>(_chestView, _spawnPoint);
			m_Timer = m_ChestModel.unlockDuration;
			m_ChestView.SetChestController(this);
			m_CurrentState = ChestStates.Locked;
			m_ChestView.SetChestImage(m_ChestModel.chestTexture);
			m_CoinsCount = UnityEngine.Random.Range(m_ChestModel.minCoins, m_ChestModel.maxCoins);
			m_GemsCount = UnityEngine.Random.Range(m_ChestModel.minGems, m_ChestModel.maxGems);
			m_UIService = UIService.Instance;
			m_ChestService = ChestService.Instance;
		}

		public string GetChestTypeName() =>	m_ChestModel.name;

		public void SetSlotController(SlotController _controller)
		{
			m_SlotController = _controller;
		}

		public void EnterUnlockStateCheck()
		{
			if (m_ChestService.IsChestUnlocking() && m_CurrentState == ChestStates.Locked)
			{
				m_UIService.ModalWindow.PrintMessage(true, "I'm busy!", "Another chest is unlocking");
				EnqueueChest();
			}
			else
				ChestStatusUpdate();
		}

		public void ChestStatusUpdate()
		{
			if (m_CurrentState == ChestStates.Locked)
				EnterUnlockingState();
			else if (m_CurrentState == ChestStates.Unlocking)
				OpenInstantly();
			else if (m_CurrentState == ChestStates.Unlocked)
				EnterUnlockedState();
		}

		private void EnterUnlockedState()
		{
			//m_UIService.ModalWindow.PrintMessage(true, "Congratulations!", "You received: ", m_GemsCount.ToString(), );
			m_CurrentState = ChestStates.Unlocking;
			m_UIService.Resource.IncreaseCounter(m_GemsCount, m_CoinsCount);
			m_ChestView.DestroyChest();
		}

		private void EnqueueChest()
		{
			if (m_ChestService.GetCanEnqueueChest())
			{
				m_ChestService.EnqueueChestToUnlock(this);
				return;
			}
			m_UIService.ModalWindow.PrintMessage(true, "I'm busy!", "Another chest is unlocking");
			/*else
			{
				uIService.ModalWindow.PrintMessage(true, "I'm busy!", "Please wait till the chests in the queue get Unlocked.", null, null, false, false, false);
			}*/
		}
		private void EnterUnlockingState()
		{
			m_CurrentState = ChestStates.Unlocking;
			m_ChestView.ChestTimerText.text = "Unlock";
			m_ChestService.SetIsChestUnlocking(true);
			StartTimer();
		}

		private void OpenInstantly()
		{
			timerToGems = (int)MathF.Ceiling(m_Timer) * 1;
			if(m_UIService.Resource.GetGemsCount() < timerToGems)
			{
				m_UIService.ModalWindow.PrintMessage(true, "Can't process", "You do not have enough gems for opening this chest");
				return;
			}
			m_UIService.ModalWindow.PrintMessage(true, "Open Chest", "Do you want to open chest using gems?", 0,timerToGems, false, OnGemsDecrease);
		}

		private void OnGemsDecrease()
		{
			m_UIService.Resource.DecreaseGemsCounter(timerToGems);
			m_ChestView.DestroyChest();
		}

		
		public async void StartTimer()
		{
			float minutes, seconds;
			while (m_Timer > -1)
			{
				minutes = Mathf.FloorToInt(m_Timer / 60);
				seconds = Mathf.FloorToInt(m_Timer % 60);
				m_ChestView.ChestTimerText.text = minutes + " : " + seconds;
				await Task.Delay(1000);
				m_Timer -= 1;
			}
			m_CurrentState = ChestStates.Unlocked;
			m_ChestView.ChestTimerText.text = "Unlocked";
			m_ChestService.SetIsChestUnlocking(false);
			m_ChestService.UnlockChestInQueue();
			return;
		}
	}
}