using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem
{
	public class ModalWindow : MonoBehaviour
	{
		[SerializeField] private GameObject m_modalWindowPanel;

		[Header("Header")]
		[SerializeField] private GameObject m_header;
		[SerializeField] private TextMeshProUGUI t_header;

		[Header("Body")]
		[SerializeField] private GameObject m_body;
		[SerializeField] private TextMeshProUGUI t_bodyText;
		[SerializeField] private GameObject m_coin;
		[SerializeField] private TextMeshProUGUI t_coinAmount;
		[SerializeField] private GameObject m_gem;
		[SerializeField] private TextMeshProUGUI t_gemAmount;

		[Header("Footer")]
		[SerializeField] private GameObject m_footer;
		[SerializeField] private Button m_acceptButton;
		[SerializeField] private Button m_declineButton;

		private Action onAccept;
		private Action onDecline;

		private void Start()
		{
			SetPanelVisibility(false);
		}

		public void SetPanelVisibility(bool _isActive)
		{
			m_modalWindowPanel.SetActive(_isActive);
		}

		private void SetHeader(bool _isActive, string _headerText)
		{
			m_header.SetActive(_isActive);
			t_header.text = _headerText;
		}
		public void SetBody(bool _isActive, string _bodyText, int _gemsCount, int _coinsCount, bool _isGemsActive, bool _isCoinsActive)
		{
			m_body.SetActive(_isActive);
			t_bodyText.text = _bodyText;
			t_gemAmount.text = _gemsCount.ToString();
			t_coinAmount.text = _coinsCount.ToString();
			m_coin.SetActive(_isCoinsActive);
			m_gem.SetActive(_isGemsActive);
		}

		private void SetFooter(bool _isActive, Action _onConfirm, bool _isAcceptButtonActive)
		{
			m_footer.SetActive(_isActive);
			m_acceptButton.gameObject.SetActive(_isAcceptButtonActive);
			m_declineButton.gameObject.SetActive(_isActive);
			onAccept = _onConfirm;
		}


		public void PrintMessage(bool _setPanelActive, string _headerText, string _bodyText)
		{
			SetPanelVisibility(_setPanelActive);
			SetHeader(_setPanelActive, _headerText);
			SetBody(_setPanelActive, _bodyText, 0, 0, false, false);
			SetFooter(_setPanelActive, null, false);
		}

		public void PrintMessage(bool _setPanelActive, string _headerText, string _bodyText, int _coinCount, int _gemsCount, bool _isCoinActive, Action _onConfirm = null)
		{
			SetPanelVisibility(_setPanelActive);
			SetHeader(_setPanelActive, _headerText);
			SetBody(_setPanelActive, _bodyText, _gemsCount, _coinCount, true, _isCoinActive);
			SetFooter(_setPanelActive, _onConfirm, true);
		}

		public void OnConfirm()
		{
			onAccept?.Invoke();
			SetPanelVisibility(false);
		}
		public void OnDecline()
		{
			onDecline?.Invoke();
			SetPanelVisibility(false);
		}
	}
}
