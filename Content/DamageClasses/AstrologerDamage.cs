using System;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Twilique.Content.DamageClasses
{
    public class AstrologerDamage : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == ModContent.GetInstance<AstrologerDamage>())
            {
                return StatInheritanceData.Full;
            }
            return new StatInheritanceData(
                damageInheritance: 0f,
                critChanceInheritance: 0f,
                attackSpeedInheritance: 0f,
                armorPenInheritance: 0f,
                knockbackInheritance: 0f
                );
        }
        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            if (damageClass == ModContent.GetInstance<AstrologerDamage>())
                return true;
            if (damageClass == DamageClass.Melee)
                return true;
            return false;
        }
        public override void SetDefaultStats(Player player)
        {
            player.GetCritChance<AstrologerDamage>() += 4;
        }
        public override bool UseStandardCritCalcs => true;
        public override bool ShowStatTooltipLine(Player player, string lineName)
        {
            // This method lets you prevent certain common statistical tooltip lines from appearing on items associated with this DamageClass.
            // The four line names you can use are "Damage", "CritChance", "Speed", and "Knockback". All four cases default to true, and thus will be shown. For example...
            return true;
        }
    }
/*
    #region ԭ��ǰ׺��
    public class DIYPrefix
    {
        // General ͨ��ǰ׺ ���ϡ�ì�������򡢻����ڡ����⡢��ͷ���������꣩
        // ��Ҷ��������ֻ��ӵ��ͨ��ǰ׺����Ϊ���ǵ��ٶ��޷��ı䡣
        // ͨ��������Ҳ���������������������ϳ��֡���õ�ͨ�����������񼶻��ħ��
        // ������������ֻ�ڻ������в�𣬶������������������¶�����Ϊ�ǲ�̫���á�
        // �����ϵĲ�����������Ժ��Բ��ƣ����Խ��񼶺Ͷ�ħ��Ϊ��ͬ�������

        // Public ����ǰ׺ ���������̽������������Զ�̡�ħ�������ٻ��˺�����������ӵ����Щ�����

        // Melee ��սǰ׺�������ͣ�

        // Ranged ����ǰ׺�������ͣ�

        // MagicAndSummon ħ�����ٻ�ǰ׺���ǵ�����ǰ׺��ͨre͵���������ǣ�

        // decorative װ��ǰ׺

        // PS:̩���������޷��õ��κν�ս������������Եõ�һ��������ṩ��ͬ���Եġ����桱�����
        // ������û�ӽ��������ˣ�

        /// <summary>
        /// 0ͨ��ǰ׺,1����ǰ׺,2��սǰ׺,3����ǰ׺,4ħ�����ٻ�ǰ׺,5װ��ǰ׺
        /// </summary>
        int[][] DIYPrefixID =//�������� �������������������
        {
            new int[]//ͨ��ǰ׺
            {
               PrefixID.Keen,//36,//����
               PrefixID.Superior,//37,//�߶�
               PrefixID.Forceful,//38,//ǿ��
               PrefixID.Broken,//39,//����
               PrefixID.Damaged,//40,//����
               PrefixID.Shoddy,//41,//����
               PrefixID.Hurtful,//53,//����
               PrefixID.Strong,//54,//ǿ��
               PrefixID.Unpleasant,//55,//��³
               PrefixID.Weak,//56,//����
               PrefixID.Ruthless,//57,//����
               PrefixID.Godly,//59,//��
               PrefixID.Demonic,//60,//��ħ
               PrefixID.Zealous//61,//����
            },
            new int[]//����ǰ׺
            {
                PrefixID.Quick,//42  Ѹ��
                PrefixID.Deadly2,//43  ����
                PrefixID.Agile,//44  ���
                PrefixID.Nimble,//45  ����
                PrefixID.Murderous,//46  �б�
                PrefixID.Slow,//47  ����
                PrefixID.Sluggish,//48  �ٶ�
                PrefixID.Lazy,//49  ����
                PrefixID.Annoying,//50  ����
                PrefixID.Nasty//51  ����
            },
            new int[]//��սǰ׺
            {
                PrefixID.Large ,//1   ��
                PrefixID.Massive,//2   �޴�
                PrefixID.Dangerous,//3   Σ��
                PrefixID.Savage,//4   �ײ�
                PrefixID.Sharp,//5   ����
                PrefixID.Pointy,//6   ����
                PrefixID.Tiny,//7   ΢С
                PrefixID.Terrible,//8   ����
                PrefixID.Small,//9   С
                PrefixID.Dull,//10  ��
                PrefixID.Unhappy,//11  ��ù
                PrefixID.Bulky,//12  ����
                PrefixID.Shameful,//13  �ɳ�
                PrefixID.Heavy,//14  ��
                PrefixID.Light,//15  ��
                PrefixID.Legendary// 81  ����
            },
            new int[]//����ǰ׺
            {
                PrefixID.Sighted,//16  ��׼
                PrefixID.Rapid ,//17  Ѹ��
                PrefixID.Hasty,//18  ����
                PrefixID.Intimidating,//19  �ֲ�
                PrefixID.Deadly,//20  ����
                PrefixID.Staunch,//21  �ɿ�
                PrefixID.Awful,//22  ��η
                PrefixID.Lethargic,//23  ����
                PrefixID.Awkward,//24  �ֱ�
                PrefixID.Powerful,//25  ǿ��
                PrefixID.Frenzying,//58  ��ŭ
                PrefixID.Unreal,//82  ���
            },
            new int[]//ħ�����ٻ�ǰ׺
            {
                PrefixID.Mystic,//26  ����
                PrefixID.Adept,//27  ����
                PrefixID.Masterful,//28  ��տ
                PrefixID.Inept,//29  ��׾
                PrefixID.Ignorant,//30  ��֪
                PrefixID.Deranged,//31  ����
                PrefixID.Intense,//32  ����
                PrefixID.Taboo,//33  ����
                PrefixID.Celestial,//34  ���
                PrefixID.Furious,//35  ��ŭ
                PrefixID.Manic,//52	����
                PrefixID.Mythical,//83	��
            },
             new int[]//װ��ǰ׺
            {
                PrefixID.Hard,//62	��Ӳ
                PrefixID.Guarding,//63	�ػ�
                PrefixID.Armored,//64	װ��
                PrefixID.Warding,//65	����
                PrefixID.Arcane,//66  ����
                PrefixID.Precise,//67  ��ȷ
                PrefixID.Lucky,//68  ����
                PrefixID.Jagged,//69  ���
                PrefixID.Spiked,//70  ���
                PrefixID.Angry,//71  ��ŭ
                PrefixID.Menacing,//72  �ն�
                PrefixID.Brisk,//73  ���
                PrefixID.Fleeting,//74  ����
                PrefixID.Hasty2,//75  ����
                PrefixID.Quick2,//76  Ѹ��
                PrefixID.Wild,//77  ��Ұ
                PrefixID.Rash,//78  ³ç
                PrefixID.Intrepid,//79  ����
                PrefixID.Violent,//80  ����
            },
        };
        /// <summary>
        ///  General ͨ��ǰ׺
        ///  Public ����ǰ׺
        ///  Melee ��սǰ׺
        ///  Ranged ����ǰ׺
        ///  MagicAndSummon ħ�����ٻ�ǰ׺ 
        ///  decorative װ��ǰ׺
        ///  ��ϸ���ݿ��Ե������࿴ע�� �����Լ�ȥwiki����
        /// </summary>
        /// <param name="General"></param>
        /// <param name="Public"></param>
        /// <param name="Melee"></param>
        /// <param name="Ranged"></param>
        /// <param name="MagicAndSummon"></param>
        /// <returns></returns>
        public int[] SelectPrefixID(bool General, bool Public, bool Melee, bool Ranged, bool MagicAndSummon, bool decorative)
        {
            int[] ints = new int[0];
            if (General) ints = ints.Concat(DIYPrefixID[0]).ToArray();
            if (Public) ints = ints.Concat(DIYPrefixID[1]).ToArray();
            if (Melee) ints = ints.Concat(DIYPrefixID[2]).ToArray();
            if (Ranged) ints = ints.Concat(DIYPrefixID[3]).ToArray();
            if (MagicAndSummon) ints = ints.Concat(DIYPrefixID[4]).ToArray();
            if (decorative) ints = ints.Concat(DIYPrefixID[5]).ToArray();
            return ints;
        }
        // diyPrefix �Զ���ǰ׺ ���������Ҫ��ǰ׺
        /// <summary>
        ///  diyPrefix �Զ���ǰ׺
        ///  General ͨ��ǰ׺
        ///  Public ����ǰ׺
        ///  Melee ��սǰ׺
        ///  Ranged ����ǰ׺
        ///  MagicAndSummon ħ�����ٻ�ǰ׺ 
        ///  decorative װ��ǰ׺
        ///  ��ϸ���ݿ��Ե������࿴ע�� �����Լ�ȥwiki����
        /// </summary>
        /// <param name="General"></param>
        /// <param name="Public"></param>
        /// <param name="Melee"></param>
        /// <param name="Ranged"></param>
        /// <param name="MagicAndSummon"></param>
        /// <returns></returns>
        public int[] SelectPrefixID(int[] diyPrefix, bool General, bool Public, bool Melee, bool Ranged, bool MagicAndSummon, bool decorative)
        {
            int[] ints = new int[0];
            ints = ints.Concat(diyPrefix).ToArray();
            if (General) ints = ints.Concat(DIYPrefixID[0]).ToArray();
            if (Public) ints = ints.Concat(DIYPrefixID[1]).ToArray();
            if (Melee) ints = ints.Concat(DIYPrefixID[2]).ToArray();
            if (Ranged) ints = ints.Concat(DIYPrefixID[3]).ToArray();
            if (MagicAndSummon) ints = ints.Concat(DIYPrefixID[4]).ToArray();
            if (decorative) ints = ints.Concat(DIYPrefixID[5]).ToArray();
            return ints;
        }
        public int[] SelectPrefixID(int[] diyPrefix)
        {
            int[] ints = new int[0];
            ints = ints.Concat(diyPrefix).ToArray();
            return ints;
        }
        /// <summary>
        /// ֻ����ԭ��Prefix��id mod��PrefixLoader.GetPrefix(xxx)?.SetStats(xxx)ȥ
        /// </summary>
        /// <param name="rolledPrefix"></param>
        /// <param name="dmg"></param>
        /// <param name="kb"></param>
        /// <param name="spd"></param>
        /// <param name="size"></param>
        /// <param name="shtspd"></param>
        /// <param name="mcst"></param>
        /// <param name="crt"></param>
        /// <returns></returns>
        public void GetPrefixStatMultipliersForItem(int rolledPrefix, out float dmg, out float kb, out float spd, out float size, out float shtspd, out float mcst, out int crt, out float num)
        {
            dmg = 1f;
            kb = 1f;
            spd = 1f;
            size = 1f;
            shtspd = 1f;
            mcst = 1f;
            crt = 0;
            switch (rolledPrefix)
            {
                case 1:
                    size = 1.12f;
                    break;
                case 2:
                    size = 1.18f;
                    break;
                case 3:
                    dmg = 1.05f;
                    crt = 2;
                    size = 1.05f;
                    break;
                case 4:
                    dmg = 1.1f;
                    size = 1.1f;
                    kb = 1.1f;
                    break;
                case 5:
                    dmg = 1.15f;
                    break;
                case 6:
                    dmg = 1.1f;
                    break;
                case 81:
                    kb = 1.15f;
                    dmg = 1.15f;
                    crt = 5;
                    spd = 0.9f;
                    size = 1.1f;
                    break;
                case 7:
                    size = 0.82f;
                    break;
                case 8:
                    kb = 0.85f;
                    dmg = 0.85f;
                    size = 0.87f;
                    break;
                case 9:
                    size = 0.9f;
                    break;
                case 10:
                    dmg = 0.85f;
                    break;
                case 11:
                    spd = 1.1f;
                    kb = 0.9f;
                    size = 0.9f;
                    break;
                case 12:
                    kb = 1.1f;
                    dmg = 1.05f;
                    size = 1.1f;
                    spd = 1.15f;
                    break;
                case 13:
                    kb = 0.8f;
                    dmg = 0.9f;
                    size = 1.1f;
                    break;
                case 14:
                    kb = 1.15f;
                    spd = 1.1f;
                    break;
                case 15:
                    kb = 0.9f;
                    spd = 0.85f;
                    break;
                case 16:
                    dmg = 1.1f;
                    crt = 3;
                    break;
                case 17:
                    spd = 0.85f;
                    shtspd = 1.1f;
                    break;
                case 18:
                    spd = 0.9f;
                    shtspd = 1.15f;
                    break;
                case 19:
                    kb = 1.15f;
                    shtspd = 1.05f;
                    break;
                case 20:
                    kb = 1.05f;
                    shtspd = 1.05f;
                    dmg = 1.1f;
                    spd = 0.95f;
                    crt = 2;
                    break;
                case 21:
                    kb = 1.15f;
                    dmg = 1.1f;
                    break;
                case 82:
                    kb = 1.15f;
                    dmg = 1.15f;
                    crt = 5;
                    spd = 0.9f;
                    shtspd = 1.1f;
                    break;
                case 22:
                    kb = 0.9f;
                    shtspd = 0.9f;
                    dmg = 0.85f;
                    break;
                case 23:
                    spd = 1.15f;
                    shtspd = 0.9f;
                    break;
                case 24:
                    spd = 1.1f;
                    kb = 0.8f;
                    break;
                case 25:
                    spd = 1.1f;
                    dmg = 1.15f;
                    crt = 1;
                    break;
                case 58:
                    spd = 0.85f;
                    dmg = 0.85f;
                    break;
                case 26:
                    mcst = 0.85f;
                    dmg = 1.1f;
                    break;
                case 27:
                    mcst = 0.85f;
                    break;
                case 28:
                    mcst = 0.85f;
                    dmg = 1.15f;
                    kb = 1.05f;
                    break;
                case 83:
                    kb = 1.15f;
                    dmg = 1.15f;
                    crt = 5;
                    spd = 0.9f;
                    mcst = 0.9f;
                    break;
                case 29:
                    mcst = 1.1f;
                    break;
                case 30:
                    mcst = 1.2f;
                    dmg = 0.9f;
                    break;
                case 31:
                    kb = 0.9f;
                    dmg = 0.9f;
                    break;
                case 32:
                    mcst = 1.15f;
                    dmg = 1.1f;
                    break;
                case 33:
                    mcst = 1.1f;
                    kb = 1.1f;
                    spd = 0.9f;
                    break;
                case 34:
                    mcst = 0.9f;
                    kb = 1.1f;
                    spd = 1.1f;
                    dmg = 1.1f;
                    break;
                case 35:
                    mcst = 1.2f;
                    dmg = 1.15f;
                    kb = 1.15f;
                    break;
                case 52:
                    mcst = 0.9f;
                    dmg = 0.9f;
                    spd = 0.9f;
                    break;
                case 84:
                    kb = 1.17f;
                    dmg = 1.17f;
                    crt = 8;
                    break;
                case 36:
                    crt = 3;
                    break;
                case 37:
                    dmg = 1.1f;
                    crt = 3;
                    kb = 1.1f;
                    break;
                case 38:
                    kb = 1.15f;
                    break;
                case 53:
                    dmg = 1.1f;
                    break;
                case 54:
                    kb = 1.15f;
                    break;
                case 55:
                    kb = 1.15f;
                    dmg = 1.05f;
                    break;
                case 59:
                    kb = 1.15f;
                    dmg = 1.15f;
                    crt = 5;
                    break;
                case 60:
                    dmg = 1.15f;
                    crt = 5;
                    break;
                case 61:
                    crt = 5;
                    break;
                case 39:
                    dmg = 0.7f;
                    kb = 0.8f;
                    break;
                case 40:
                    dmg = 0.85f;
                    break;
                case 56:
                    kb = 0.8f;
                    break;
                case 41:
                    kb = 0.85f;
                    dmg = 0.9f;
                    break;
                case 57:
                    kb = 0.9f;
                    dmg = 1.18f;
                    break;
                case 42:
                    spd = 0.9f;
                    break;
                case 43:
                    dmg = 1.1f;
                    spd = 0.9f;
                    break;
                case 44:
                    spd = 0.9f;
                    crt = 3;
                    break;
                case 45:
                    spd = 0.95f;
                    break;
                case 46:
                    crt = 3;
                    spd = 0.94f;
                    dmg = 1.07f;
                    break;
                case 47:
                    spd = 1.15f;
                    break;
                case 48:
                    spd = 1.2f;
                    break;
                case 49:
                    spd = 1.08f;
                    break;
                case 50:
                    dmg = 0.8f;
                    spd = 1.15f;
                    break;
                case 51:
                    kb = 0.9f;
                    spd = 0.9f;
                    dmg = 1.05f;
                    crt = 2;
                    break;
            }

            num = 1f * dmg * (2f - spd) * (2f - mcst) * size * kb * shtspd * (1f + (float)crt * 0.02f);
            if (rolledPrefix == 62 || rolledPrefix == 69 || rolledPrefix == 73 || rolledPrefix == 77)
                num *= 1.05f;

            if (rolledPrefix == 63 || rolledPrefix == 70 || rolledPrefix == 74 || rolledPrefix == 78 || rolledPrefix == 67)
                num *= 1.1f;

            if (rolledPrefix == 64 || rolledPrefix == 71 || rolledPrefix == 75 || rolledPrefix == 79 || rolledPrefix == 66)
                num *= 1.15f;

            if (rolledPrefix == 65 || rolledPrefix == 72 || rolledPrefix == 76 || rolledPrefix == 80 || rolledPrefix == 68)
                num *= 1.2f;

        }
    }
    #endregion

    #region ������¡ԭ��ǰ׺����
    public class Large : ModPrefix
    {
        //��Ҫ��¡��ǰ׺id
        public virtual int ID => PrefixID.Large;
        //��Ҫ��¡��ǰ׺���ı�
        public override LocalizedText DisplayName
        {
            get
            {
                LocalizedText localizedText = Language.GetText("Mods." + this.GetType().FullName);

                FieldInfo fieldInfo = typeof(LocalizedText).GetField("_value", BindingFlags.NonPublic | BindingFlags.Instance);
                if (fieldInfo != null)
                {
                    fieldInfo.SetValue(localizedText, $"{Lang.prefix[ID].Value}");
                }
                return localizedText;
            }
        }

        //ǰ׺���������PrefixCategory��Ĭ��������Զ���=5
        //Melee ��ս=0
        //Ranged Զ��=1
        //Magic ħ��=2
        //AnyWeapon  ��������=3�����������ٻ��Ŷ��
        //Accessory ��Ʒ = 4
        public override PrefixCategory Category => (PrefixCategory)3;//ǿ��ת��̫������XD
        // ǰ׺���ָ��� Ĭ����1 ������Ҫ��һ������ϡ�е�Ҳ���ǲ���,������д0Ҳ�и��ʳ��֣�
        public override float RollChance(Item item) => 1f;
        //�Ƿ���֣��������ж��˺����� ��������Ҫдʲô��ʲô
        public override bool CanRoll(Item item) => item.DamageType == ModContent.GetInstance<StarDamage>();

        //ʹ�ô˹��ܿ����޸ľ��д�ǰ׺����Ŀ����Щͳ����Ϣ��
        //�˺����������˳�����ʹ��ʱ�������������������С��������ٶȳ�����ħ��������ħ���ɱ����������ӳ�
        /// <summary>
        /// �˺����������˳�����ʹ��ʱ�������������������С��������ٶȳ�����ħ��������ħ���ɱ����������ӳ�
        /// </summary>
        /// <param name="damageMult"></param>
        /// <param name="knockbackMult"></param>
        /// <param name="useTimeMult"></param>
        /// <param name="scaleMult"></param>
        /// <param name="shootSpeedMult"></param>
        /// <param name="manaMult"></param>
        /// <param name="critBonus"></param>
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            //��¡�ӳ�
            new DIYPrefix().GetPrefixStatMultipliersForItem(ID,
            out damageMult, out knockbackMult, out useTimeMult, out scaleMult, out shootSpeedMult, out manaMult, out critBonus, out _);
            // PrefixLoader.GetPrefix(PrefixID.Large)?.
            //  SetStats(ref damageMult, ref knockbackMult, ref useTimeMult, ref scaleMult, ref shootSpeedMult, ref manaMult, ref critBonus);
        }
        // ��ֵ��ϡ���ԣ�ϡ�жȣ���

        public override void ModifyValue(ref float valueMult)
        {
            //��¡��ֵ��ϡ�ж�
            new DIYPrefix().GetPrefixStatMultipliersForItem(ID,
            out _, out _, out _, out _, out _, out _, out _, out valueMult);
            //(ModPrefix)Terraria.GameContent.Prefixes.PrefixLegacy.ItemSets.
            //ModContent.PrefixType<>();
            // PrefixLoader.GetPrefix(PrefixID.Large)?.ModifyValue(ref valueMult);
        }
        //�޸�������Ϣ
        public override void Apply(Item item)
        {
        }
    }
    #endregion

    #region ������¡
    public class Massive : Large
    {
        public override int ID => PrefixID.Massive;
    }
    public class Dangerous : Large
    {
        public override int ID => PrefixID.Dangerous;
    }
    public class Savage : Large
    {
        public override int ID => PrefixID.Savage;
    }
    public class Sharp : Large
    {
        public override int ID => PrefixID.Sharp;
    }
    public class Pointy : Large
    {
        public override int ID => PrefixID.Pointy;
    }
    public class Tiny : Large
    {
        public override int ID => PrefixID.Tiny;
    }
    public class Terrible : Large
    {
        public override int ID => PrefixID.Terrible;
    }
    public class Small : Large
    {
        public override int ID => PrefixID.Small;
    }
    public class Dull : Large
    {
        public override int ID => PrefixID.Dull;
    }
    public class Unhappy : Large
    {
        public override int ID => PrefixID.Unhappy;
    }
    public class Bulky : Large
    {
        public override int ID => PrefixID.Bulky;
    }
    public class Shameful : Large
    {
        public override int ID => PrefixID.Shameful;
    }
    public class Heavy : Large
    {
        public override int ID => PrefixID.Heavy;
    }
    public class Light : Large
    {
        public override int ID => PrefixID.Light;
    }
    public class Legendary : Large
    {
        public override int ID => PrefixID.Legendary;
    }
    #endregion*/
}