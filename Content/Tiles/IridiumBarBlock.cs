using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Twilique.Content.Tiles
{
	public class IridiumBarBlock : ModTile
	{
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;//是否为实体
            Main.tileSolidTop[Type] = true;//顶端能否站立
            Main.tileNoAttach[Type] = true;//能否在附近放置方块
            Main.tileTable[Type] = false;//能否当做桌子
            Main.tileLavaDeath[Type] = false;//能否被岩浆破坏
            Main.tileFrameImportant[Type] = true;//是否自动选帧 如果是true就显示随机纹理
                                                 //(但我只画了一个纹理嘻嘻)
            Main.tileCut[Type] = false;//能否被武器破坏
            Main.tileBlockLight[Type] = false;//是否阻挡光源
            TileID.Sets.Ore[Type] = true;//是否判定为矿石(可以被金属探测器探测)
                                         //这一条会无视"TileObjectData.newTile.CopyForm"里面填的"TileObjectData.Style" ,会按1x1的大小探测
                                         //但是方块大小依然是"TileObjectData.Style"的大小,纹理坐标会读取到边界外面(没看懂)
                                         //所以物块边界是棕色会怎么样啊
            Main.tileOreFinderPriority[Type] = 114;//金属探测器的优先级
                                                   //如果写了这一条，就算"TileID.Sets.Ore[Type] = false;"依然会被金属探测器探测
            Main.tileSpelunker[Type] = true;//是否被洞穴探险药水点亮
            Main.tileShine2[Type] = true;//是否被洞穴探险荧光棒高亮
            Main.tileShine[Type] = 30;//方块闪烁白光点的频率
            Main.tileMergeDirt[Type] = false;//会不会和土块连接
            Main.tileLighted[Type] = false;//是否发光

            //DustType = ModContent.DustType<Content.Blocks.IridiumBarBlock>();
            RegisterItemDrop(ModContent.ItemType<Content.Items.IridiumBar>(), 1);
        }
    }
}
