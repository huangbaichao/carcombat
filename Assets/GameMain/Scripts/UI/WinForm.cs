using UnityEngine;
using UnityEngine.UI;
using GameFramework.Localization;

namespace CarCombat
{
    public class WinForm : UGuiForm
    {
        [SerializeField]
        private GameObject m_CollectBtn = null;
        [SerializeField]
        private GameObject m_CancelBtn = null;

        private Language m_SelectedLanguage = Language.Unspecified;

        public void OnCollectBtnClick()
        {

        }

        public void OnCancelBtnClick()
        {

        }


#if UNITY_2017_3_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnOpen(object userData)
#endif
        {
            base.OnOpen(userData);


        }

    }
}
