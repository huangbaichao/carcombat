using GameFramework.Event;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;


namespace CarCombat
{
    public class ProcedureBattle : ProcedureBase
    {
        private bool m_Replay = false;
        private bool m_GotoCombine = false;

        private BattleUIForm m_BattleUIForm = null;

        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        /**
         * 重新开始战斗
         */
        public void Replay()
        {
            m_GotoCombine = false;
            m_Replay = true;
        }

        /**
         * 战斗结束，返回组装场景
         */
        public void GotoCombine()
        {
            m_Replay = false;
            m_GotoCombine = true;
        }


        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            m_Replay = false;
            m_GotoCombine = false;
            GameEntry.UI.OpenUIForm(UIFormId.BattleUIForm, this);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            if (m_Replay)
            {
                procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Battle"));
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
            else if (m_GotoCombine)
            {
                procedureOwner.SetData<VarInt32>("NextSceneId", GameEntry.Config.GetInt("Scene.Combine"));
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }
            m_BattleUIForm = (BattleUIForm)ne.UIForm.Logic;
        }

    }
}