using ChestSystem.Chest;
using UnityEngine;

namespace ChestSystem
{
    public class SlotController : MonoBehaviour
    {
        private bool b_IsEmpty;
		private ChestController chestController;
		private void Start()
		{
			b_IsEmpty = true;
		}
		public bool GetIsSlotEmpty() => b_IsEmpty;

		public void SetSlotIsEmpty() 
		{ 
			b_IsEmpty = true;
			chestController = null;
		} 

		public void SpawnChest()
		{
			chestController = ChestService.Instance.CreateChest(gameObject.transform);
			chestController.SetSlotController(this);
			b_IsEmpty = false;	
		}
    }
}
