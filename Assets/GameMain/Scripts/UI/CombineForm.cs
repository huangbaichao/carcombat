using UnityEngine;
using UnityEngine.UI;
using GameFramework.Localization;
using UnityGameFramework.Runtime;

namespace CarCombat
{
    public class CombineForm : UGuiForm
    {
        [SerializeField]
        private GameObject m_FightBtn = null;

        private ProcedureCombine m_ProcedureCombine = null;

        private Language m_SelectedLanguage = Language.Unspecified;

        public void OnFightBtnClick()
        {
            m_ProcedureCombine.GotoBattle();
        }


#if UNITY_2017_3_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnOpen(object userData)
#endif
        {
            base.OnOpen(userData);

            m_ProcedureCombine = (ProcedureCombine)userData;
            if (m_ProcedureCombine == null)
            {
                Log.Warning("ProcedureMenu is invalid when open MenuForm.");
                return;
            }
        }


#if UNITY_2017_3_OR_NEWER
        protected override void OnClose(bool isShutdown, object userData)
#else
        protected internal override void OnClose(bool isShutdown, object userData)
#endif
        {
            m_ProcedureCombine = null;

            base.OnClose(isShutdown, userData);
        }


    }
}
