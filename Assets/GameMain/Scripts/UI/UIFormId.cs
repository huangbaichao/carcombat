namespace CarCombat
{
    /// <summary>
    /// 界面编号。
    /// </summary>
    public enum UIFormId : byte
    {
        Undefined = 0,

        /// <summary>
        /// 弹出框。
        /// </summary>
        DialogForm = 1,

        /// <summary>
        /// 主菜单。
        /// </summary>
        MenuForm = 100,

        /// <summary>
        /// 设置。
        /// </summary>
        SettingForm = 101,

        /// <summary>
        /// 组装
        /// </summary>
        CombineForm = 102,

        /// <summary>
        /// 战斗UI
        /// </summary>
        BattleUIForm = 103,

        /// <summary>
        /// 战斗提示Btn
        /// </summary>
        BattleBtnForm = 104,

        /// <summary>
        /// 胜利
        /// </summary>
        WinForm = 105,

        /// <summary>
        /// 失败
        /// </summary>
        LoseForm = 106,
    }
}
