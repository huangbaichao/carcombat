using UnityEngine;
using UnityEngine.UI;
using GameFramework.Event;
using GameFramework.Localization;
using UnityGameFramework.Runtime;

namespace CarCombat
{
    public class BattleUIForm : UGuiForm
    {
        [SerializeField]
        private GameObject m_Top = null;
        [SerializeField]
        private GameObject m_ReplayBtn = null;
        [SerializeField]
        private Text m_LevelText = null;
        [SerializeField]
        private Text m_CoinText = null;

        [SerializeField]
        private GameObject m_Operate = null;
        [SerializeField]
        private GameObject m_BattleStart = null;
        [SerializeField]
        private Text m_BattleTipText = null;

        private ProcedureBattle m_ProcedureBattle = null;

        private Language m_SelectedLanguage = Language.Unspecified;

        public void OnReplayBtnClick()
        {
            Log.Warning("点击重新开始");
            GameEntry.UI.OpenDialog(new DialogParams()
            {
                Mode = 2,
                Title = GameEntry.Localization.GetString("Battle.AskReplayGame.Title"),
                Message = GameEntry.Localization.GetString("Battle.AskReplayGame.Message"),
                OnClickConfirm = delegate (object userData)
                {

                },
            });
        }

        public void OnBattleStartBtnClick()
        {
            Log.Info("点击屏幕开始拖动");
        }


#if UNITY_2017_3_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnOpen(object userData)
#endif
        {
            base.OnOpen(userData);
            m_ProcedureBattle = (ProcedureBattle)userData;
            if (m_ProcedureBattle == null)
            {
                Log.Warning("ProcedureBattle is invalid when open BattleUIForm.");
                return;
            }
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            m_Operate.SetActive(true);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnClose(bool isShutdown, object userData)
#else
        protected internal override void OnClose(bool isShutdown, object userData)
#endif
        {
            m_ProcedureBattle = null;
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            base.OnClose(isShutdown, userData);
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
            //m_MenuForm = (MenuForm)ne.UIForm.Logic;
        }

        #region Test UI

        public void OnWinBtnClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.WinForm, this);
        }
        public void OnLoseBtnClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.LoseForm, this);
        }

        #endregion

    }
}
