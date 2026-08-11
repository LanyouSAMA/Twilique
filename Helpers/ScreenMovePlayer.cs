using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Twilique
{
    public class ScreenMovePlayer : ModPlayer
    {
        public Vector2 TargetScreenPos = Vector2.Zero;
        public Vector2 CurrentScreenPos = Vector2.Zero;
        public int ScreenShakeTimer = 0;//震屏计时器
        public float ScreenShakeScale = 0;//震屏幅度控制器
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