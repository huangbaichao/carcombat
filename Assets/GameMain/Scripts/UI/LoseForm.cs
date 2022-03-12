using UnityEngine;
using UnityEngine.UI;
using GameFramework.Localization;

namespace CarCombat
{
    public class LoseForm : UGuiForm
    {
        [SerializeField]
        private GameObject m_TryAgainBtn = null;

        private Language m_SelectedLanguage = Language.Unspecified;

        public void OnTryAgainBtnClick()
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
