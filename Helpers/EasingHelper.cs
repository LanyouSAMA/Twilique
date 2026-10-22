using System;
using Microsoft.Xna.Framework;

namespace Twilique
{
    public static class EasingHelper
    {
        /// <summary>
        /// 突变插值(起始值，结束值，进度)
        /// </summary>
        public static float Step(float value1, float value2, float amount)
        {
            return amount <= 0f ? value1 : value2;
        }

        /// <summary>
        /// 线性插值(起始值，结束值，进度)
        /// </summary>
        public static float Lerp(float value1, float value2, float amount)
        {
            return Interpolate(value1, value2, amount, amount);
        }

        /// <summary>
        /// 正弦缓入插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInSine(float value1, float value2, float amount)
        {
            return Interpolate(value1, value2, amount, 1f - MathF.Cos(amount * MathHelper.PiOver2));
        }

        /// <summary>
        /// 正弦缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseOutSine(float value1, float value2, float amount)
        {
            return Interpolate(value1, value2, amount, MathF.Sin(amount * MathHelper.PiOver2));
        }

        /// <summary>
        /// 正弦缓入缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInOutSine(float value1, float value2, float amount)
        {
            return Interpolate(value1, value2, amount, (1f - MathF.Cos(amount * MathHelper.Pi)) / 2f);
        }

        /// <summary>
        /// 二次缓入插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInQuad(float value1, float value2, float amount)
        {
            return Interpolate(value1, value2, amount, amount * amount);
        }

        /// <summary>
        /// 二次缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseOutQuad(float value1, float value2, float amount)
        {
            float inverse = 1f - amount;
            return Interpolate(value1, value2, amount, 1f - inverse * inverse);
        }

        /// <summary>
        /// 二次缓入缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInOutQuad(float value1, float value2, float amount)
        {
            float eased;
            if (amount < 0.5f)
            {
                eased = 2f * amount * amount;
            }
            else
            {
                float inverse = 2f - 2f * amount;
                eased = 1f - inverse * inverse / 2f;
            }
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 三次缓入插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInCubic(float value1, float value2, float amount)
        {
            return Interpolate(value1, value2, amount, amount * amount * amount);
        }

        /// <summary>
        /// 三次缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseOutCubic(float value1, float value2, float amount)
        {
            float inverse = 1f - amount;
            return Interpolate(value1, value2, amount, 1f - inverse * inverse * inverse);
        }

        /// <summary>
        /// 三次缓入缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInOutCubic(float value1, float value2, float amount)
        {
            float eased;
            if (amount < 0.5f)
            {
                eased = 4f * amount * amount * amount;
            }
            else
            {
                float inverse = 2f - 2f * amount;
                eased = 1f - inverse * inverse * inverse / 2f;
            }
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 四次缓入插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInQuart(float value1, float value2, float amount)
        {
            float squared = amount * amount;
            return Interpolate(value1, value2, amount, squared * squared);
        }

        /// <summary>
        /// 四次缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseOutQuart(float value1, float value2, float amount)
        {
            float inverse = 1f - amount;
            float squared = inverse * inverse;
            return Interpolate(value1, value2, amount, 1f - squared * squared);
        }

        /// <summary>
        /// 四次缓入缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInOutQuart(float value1, float value2, float amount)
        {
            float eased;
            if (amount < 0.5f)
            {
                float squared = amount * amount;
                eased = 8f * squared * squared;
            }
            else
            {
                float inverse = 2f - 2f * amount;
                float squared = inverse * inverse;
                eased = 1f - squared * squared / 2f;
            }
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 五次缓入插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInQuint(float value1, float value2, float amount)
        {
            float squared = amount * amount;
            return Interpolate(value1, value2, amount, squared * squared * amount);
        }

        /// <summary>
        /// 五次缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseOutQuint(float value1, float value2, float amount)
        {
            float inverse = 1f - amount;
            float squared = inverse * inverse;
            return Interpolate(value1, value2, amount, 1f - squared * squared * inverse);
        }

        /// <summary>
        /// 五次缓入缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInOutQuint(float value1, float value2, float amount)
        {
            float eased;
            if (amount < 0.5f)
            {
                float squared = amount * amount;
                eased = 16f * squared * squared * amount;
            }
            else
            {
                float inverse = 2f - 2f * amount;
                float squared = inverse * inverse;
                eased = 1f - squared * squared * inverse / 2f;
            }
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 指数缓入插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInExpo(float value1, float value2, float amount)
        {
            float eased = amount == 0f ? 0f : MathF.Pow(2f, 10f * amount - 10f);
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 指数缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseOutExpo(float value1, float value2, float amount)
        {
            float eased = amount == 1f ? 1f : 1f - MathF.Pow(2f, -10f * amount);
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 指数缓入缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInOutExpo(float value1, float value2, float amount)
        {
            float eased;
            if (amount < 0.5f)
                eased = MathF.Pow(2f, 20f * amount - 10f) / 2f;
            else
                eased = (2f - MathF.Pow(2f, -20f * amount + 10f)) / 2f;
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 圆弧缓入插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInCirc(float value1, float value2, float amount)
        {
            return Interpolate(value1, value2, amount, 1f - MathF.Sqrt(1f - amount * amount));
        }

        /// <summary>
        /// 圆弧缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseOutCirc(float value1, float value2, float amount)
        {
            float inverse = amount - 1f;
            return Interpolate(value1, value2, amount, MathF.Sqrt(1f - inverse * inverse));
        }

        /// <summary>
        /// 圆弧缓入缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInOutCirc(float value1, float value2, float amount)
        {
            float eased;
            if (amount < 0.5f)
            {
                float doubled = 2f * amount;
                eased = (1f - MathF.Sqrt(1f - doubled * doubled)) / 2f;
            }
            else
            {
                float inverse = 2f - 2f * amount;
                eased = (1f + MathF.Sqrt(1f - inverse * inverse)) / 2f;
            }
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 回力缓入插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInBack(float value1, float value2, float amount)
        {
            const float strength = 1.70158f;
            float squared = amount * amount;
            return Interpolate(value1, value2, amount, (strength + 1f) * squared * amount - strength * squared);
        }

        /// <summary>
        /// 回力缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseOutBack(float value1, float value2, float amount)
        {
            const float strength = 1.70158f;
            float inverse = amount - 1f;
            float squared = inverse * inverse;
            return Interpolate(value1, value2, amount, 1f + (strength + 1f) * squared * inverse + strength * squared);
        }

        /// <summary>
        /// 回力缓入缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInOutBack(float value1, float value2, float amount)
        {
            const float strength = 1.70158f * 1.525f;
            float doubled = 2f * amount;
            float eased;
            if (amount < 0.5f)
                eased = doubled * doubled * ((strength + 1f) * doubled - strength) / 2f;
            else
            {
                float inverse = doubled - 2f;
                eased = (inverse * inverse * ((strength + 1f) * inverse + strength) + 2f) / 2f;
            }
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 弹性缓入插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInElastic(float value1, float value2, float amount)
        {
            const float period = 2f * MathHelper.Pi / 3f;
            float eased = -MathF.Pow(2f, 10f * amount - 10f) * MathF.Sin((10f * amount - 10.75f) * period);
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 弹性缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseOutElastic(float value1, float value2, float amount)
        {
            const float period = 2f * MathHelper.Pi / 3f;
            float eased = MathF.Pow(2f, -10f * amount) * MathF.Sin((10f * amount - 0.75f) * period) + 1f;
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 弹性缓入缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInOutElastic(float value1, float value2, float amount)
        {
            const float period = 2f * MathHelper.Pi / 4.5f;
            float eased;
            if (amount < 0.5f)
                eased = -MathF.Pow(2f, 20f * amount - 10f) * MathF.Sin((20f * amount - 11.125f) * period) / 2f;
            else
                eased = MathF.Pow(2f, -20f * amount + 10f) * MathF.Sin((20f * amount - 11.125f) * period) / 2f + 1f;
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 弹跳缓入插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInBounce(float value1, float value2, float amount)
        {
            return Interpolate(value1, value2, amount, 1f - BounceOutProgress(1f - amount));
        }

        /// <summary>
        /// 弹跳缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseOutBounce(float value1, float value2, float amount)
        {
            return Interpolate(value1, value2, amount, BounceOutProgress(amount));
        }

        /// <summary>
        /// 弹跳缓入缓出插值(起始值，结束值，进度)
        /// </summary>
        public static float EaseInOutBounce(float value1, float value2, float amount)
        {
            float eased = amount < 0.5f
                ? (1f - BounceOutProgress(1f - 2f * amount)) / 2f
                : (1f + BounceOutProgress(2f * amount - 1f)) / 2f;
            return Interpolate(value1, value2, amount, eased);
        }

        /// <summary>
        /// 弹跳缓出的进度(进度)
        /// </summary>
        private static float BounceOutProgress(float amount)
        {
            const float scale = 7.5625f;
            const float divisor = 2.75f;
            if (amount < 1f / divisor)
                return scale * amount * amount;
            if (amount < 2f / divisor)
            {
                amount -= 1.5f / divisor;
                return scale * amount * amount + 0.75f;
            }
            if (amount < 2.5f / divisor)
            {
                amount -= 2.25f / divisor;
                return scale * amount * amount + 0.9375f;
            }
            amount -= 2.625f / divisor;
            return scale * amount * amount + 0.984375f;
        }

        /// <summary>
        /// 按缓动后的进度进行插值(起始值，结束值，原进度，缓动后的进度)
        /// </summary>
        private static float Interpolate(float value1, float value2, float amount, float easedAmount)
        {
            if (amount == 0f) return value1;
            if (amount == 1f) return value2;
            return MathHelper.Lerp(value1, value2, easedAmount);
        }
    }
}
