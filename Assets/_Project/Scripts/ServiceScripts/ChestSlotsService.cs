using UnityEngine;

namespace ChestSystem
{
    public class ChestSlotsService : MonoSingleton<ChestSlotsService>
    {
        [SerializeField] private SlotController[] m_Slots;

        public void SpawnChest()
        {
            int emptySlot = GetEmptySlot();
            if (emptySlot == -1)
                UIService.Instance.ModalWindow.PrintMessage(true, "Error 404", "No Empty Slots Found! :( ");
            else
                m_Slots[emptySlot].SpawnChest();
        }

        private int GetEmptySlot()
        {
            for(int i = 0; i < m_Slots.Length; i++)
            {
                if (m_Slots[i].GetIsSlotEmpty())
                    return i;
            }
            return -1;
        }
    }
}
