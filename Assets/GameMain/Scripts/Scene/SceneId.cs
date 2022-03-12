namespace CarCombat
{
    /// <summary>
    /// 场景编号。
    /// </summary>
    public enum SceneId : byte
    {
        Undefined = 0,

        /// <summary>
        /// 菜单场景
        /// </summary>
        MenuScene = 1,

        /// <summary>
        /// 拼装场景
        /// </summary>
        CombineScene = 2,

        /// <summary>
        /// 战斗场景
        /// </summary>
        BattleScene = 3,
    }
}
