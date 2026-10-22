using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Twilique
{
    /// <summary>
    /// 屏幕移动与震屏的玩家状态
    /// </summary>
    public class ScreenMovePlayer : ModPlayer
    {
        /// <summary>
        /// 屏幕移动的目标坐标
        /// 需要按如下格式赋值：player.GetModPlayer&lt;ScreenMovePlayer&gt;().TargetScreenPos = position;
        /// </summary>
        public Vector2 TargetScreenPos = Vector2.Zero;
        /// <summary>
        /// 屏幕移动时的当前坐标
        /// </summary>
        public Vector2 CurrentScreenPos = Vector2.Zero;
        public int ScreenShakeTimer = 0;//震屏计时器
        public float ScreenShakeScale = 0;//震屏幅度控制器
        /// <summary>
        /// 每帧更新屏幕移动的坐标
        /// </summary>
        public override void ResetEffects()
        {
            if (TargetScreenPos == Vector2.Zero)
            {
                CurrentScreenPos = Main.screenPosition;
            }
            else
            {
                CurrentScreenPos = Vector2.Lerp(CurrentScreenPos, TargetScreenPos, 0.09f);
                TargetScreenPos = Vector2.Zero;
            }
            base.ResetEffects();
        }
        /// <summary>
        /// 修改屏幕坐标并处理震屏(震屏计时器，震屏幅度)
        /// 需要按如下格式设置：player.GetModPlayer&lt;ScreenMovePlayer&gt;().ScreenShakeTimer = 5;
        /// player.GetModPlayer&lt;ScreenMovePlayer&gt;().ScreenShakeScale = 10;
        /// </summary>
        public override void ModifyScreenPosition()//修改屏幕的坐标
        {
            if (TargetScreenPos != Vector2.Zero)
                Main.screenPosition = CurrentScreenPos;//将屏幕坐标赋值为current
            //震屏
            if (ScreenShakeTimer > 0 && ScreenShakeScale > 0)//在都为大于0的数时震屏
            {
                Main.screenPosition += Main.rand.NextVector2Circular(ScreenShakeScale, ScreenShakeScale);
                ScreenShakeTimer--;
            }
            base.ModifyScreenPosition();
        }
    }
}
