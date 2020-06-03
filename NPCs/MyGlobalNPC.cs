using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.Items;
using VampKnives.Items.Accessories;
using VampKnives.Items.BossDrops;
using VampKnives.Items.Materials;

namespace VampKnives.NPCs
{
    public class MyGlobalNPC : GlobalNPC
    {
        public bool VortexBuff = false;
        public int Packet3 = 33;
        public int Kills;
        int NPCLastInteract;
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public override void NPCLoot(NPC npc)
        {
            if (npc.lastInteraction != 255)
            {
                ExamplePlayer p = Main.player[npc.lastInteraction].GetModPlayer<ExamplePlayer>();
                if (p.VampNecklace)
                {
                    if (Main.netMode == 0)
                    {
                        p.NeckProgress++;
                    }
                    else
                    {
                        ModPacket packet = mod.GetPacket();
                        packet.Write(Packet3); // no idea what Packet3 is, but this should be the ID f the message, something that tells the receiving end what this message is about
                        //Main.NewText("Packet3 Written");
                        packet.Send(npc.lastInteraction); // sends the packet to the killer only
                    }
                }
            }

            if (gildedCurse && npc.lifeMax > 5 && npc.value > 0f)
            {
                for (int x = 0; x < 800; x++)
                {
                    int randomCopper = Main.rand.Next(0, 60);
                    int randomSilver = Main.rand.Next(0, 4000);
                    int randomGold = Main.rand.Next(0, 40000);
                    int RandomPlatinum = Main.rand.Next(0, 500000);
                    if (randomCopper == 2)
                        Item.NewItem(npc.getRect(), ItemID.CopperCoin);
                    if (randomSilver == 2)
                        Item.NewItem(npc.getRect(), ItemID.SilverCoin);
                    if (randomGold == 2)
                        Item.NewItem(npc.getRect(), ItemID.GoldCoin);
                    if (RandomPlatinum == 2)
                        Item.NewItem(npc.getRect(), ItemID.PlatinumCoin);
                }
            }
            if (npc.type == NPCID.Plantera)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BloomingTerror>());
                for (int x = 0; x < 5; x++)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Superglue>());
                }
                for (int x = 0; x < Main.rand.Next(45, 76); x++)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<PlantFiber>());
                }
            }
            if(npc.type == NPCID.WyvernHead)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WyvernHead>());
            }
            if(npc.type == NPCID.Harpy)
            {
                if (Main.rand.Next(50) <= 4)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<HarpyKnives>());
            }
            if (npc.type == NPCID.MartianTurret)
            {
                if (Main.rand.Next(50) == 4)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.RukasusTeslaKnives>());
            }
            if (npc.type == NPCID.CultistBoss)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Armor.MagesHood>());
            }
            if (npc.type == NPCID.BrainofCthulhu)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CrimsonCrystal>());
            }
            if (npc.type == NPCID.Butcher)
            {
                if (NPC.downedPlantBoss == true)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<LivingTissue>());
                }
            }
            if (npc.type == NPCID.EaterofWorldsHead)
            {
                if (Main.rand.Next(6) == 0)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CorruptionCrystal>());

            }
            if (npc.type == NPCID.EaterofSouls)
            {
                Random random = new Random();
                int ran = random.Next(0, 11);
                if (ran == 5)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CorruptionShard>());
            }
            if (npc.type == NPCID.FaceMonster)
            {
                Random random = new Random();
                int ran = random.Next(0, 11);
                if (ran == 5)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<CrimsonShard>());
            }
            if (npc.type == NPCID.MoonLordCore)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<LuminiteKnives>());
            }
            if (npc.type == NPCID.KingSlime)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Superglue>());
            }
            if (npc.type == NPCID.SkeletronHead)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<ExtraFinger>());
            }
            if (npc.type == NPCID.SkeletronPrime)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<MechanicalFingers>());
            }
            if (npc.type == NPCID.Mothron)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.BrokenHeroKnives>());
            }
        }
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.WitchDoctor)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Misc.MudkipBall>());
                shop.item[nextSlot].shopCustomPrice = new int?(100000);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Misc.LucarioBall>());
                shop.item[nextSlot].shopCustomPrice = new int?(100000);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Misc.ArcanineBall>());
                shop.item[nextSlot].shopCustomPrice = new int?(100000);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Misc.EeveeBall>());
                shop.item[nextSlot].shopCustomPrice = new int?(100000);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Misc.Bagutte>());
                shop.item[nextSlot].shopCustomPrice = new int?(100000);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Misc.MasterSword>());
                shop.item[nextSlot].shopCustomPrice = new int?(100000);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Misc.ConnorPet>());
                shop.item[nextSlot].shopCustomPrice = new int?(100000);
                nextSlot++;
            }
        }

        public override bool CheckDead(NPC npc)
        {
            if (VortexBuff)
            {
                for (int x = 0; x < Main.rand.Next(8, 16); x++)
                {
                    float ran1 = Main.rand.NextFloat(-2, 2);
                    float ran2 = Main.rand.NextFloat(-2, 2);
                    if (ran1 == 0)
                        ran1 = -1;
                    if (ran2 == 0)
                        ran2 = -2;
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, ran1, ran2, mod.ProjectileType("VortexProj2"), 8, 4, Main.LocalPlayer.whoAmI);
                }
                return true;
            }
            else
                return true;
        }

        public bool PenetratingPoison = false;
        public bool bleedingOut = false;
        public bool hellfire = false;
        public bool cursedFire = false;
        public bool gildedCurse = false;
        public bool ichorUproar = false;
        public bool partyBuff = false;
        public bool potentPoison = false;
        public bool ShroomitePoison = false;

        public override void ResetEffects(NPC npc)
        {
            PenetratingPoison = false;
            bleedingOut = false;
            hellfire = false;
            cursedFire = false;
            gildedCurse = false;
            ichorUproar = false;
            partyBuff = false;
            potentPoison = false;
            VortexBuff = false;
            ShroomitePoison = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (PenetratingPoison)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (npc.lifeRegen > 0)
                    {
                        npc.lifeRegen = 0;
                    }
                    npc.lifeRegen -= 12;
                    if (damage < 6)
                    {
                        damage = 6;
                    }
                }
            }
            if(ShroomitePoison)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (npc.lifeRegen > 0)
                    {
                        npc.lifeRegen = 0;
                    }
                    npc.lifeRegen -= 18;
                    if (damage < 9)
                    {
                        damage = 11 + Main.rand.Next(-3,4);
                    }
                }
            }
            if (bleedingOut)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int exampleKnifeCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active && p.type == ModContent.ProjectileType<Projectiles.ButchersKnivesProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        exampleKnifeCount++;
                    }
                }
                npc.lifeRegen -= exampleKnifeCount * 2 * 3;
                if (damage < exampleKnifeCount * 3)
                {
                    damage = exampleKnifeCount * 3;
                }
            }
            if (hellfire)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (npc.lifeRegen > 0)
                    {
                        npc.lifeRegen = 0;
                    }
                    npc.lifeRegen -= Main.rand.Next(5, 12);
                    if (damage < 5)
                        damage = damage + x;
                }
            }
            if (cursedFire)
            {
                for (int x = 0; x < 15; x++)
                {
                    if (npc.lifeRegen > 0)
                    {
                        npc.lifeRegen = 0;
                    }
                    npc.lifeRegen -= Main.rand.Next(8, 18);
                    if (damage < 8)
                        damage = damage + x;
                }
            }
        }
        public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if (ichorUproar)
            {
                if (npc.defense > 5)
                    damage = (int)(damage * (npc.defense / 3));
                if (npc.defense < 5 && npc.defense > 0)
                    damage = (int)(damage * (npc.defense / 2));
            }
            return base.StrikeNPC(npc, ref damage, defense, ref knockback, hitDirection, ref crit);
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (PenetratingPoison)
            {
                int DustID2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width - 3, npc.height - 3, 273, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 10, Color.DarkGreen, 1.8f);
                Main.dust[DustID2].noGravity = true;
                int DustID3 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width - 3, npc.height - 3, 244, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 10, Color.LightGreen, 1.8f);
                Main.dust[DustID3].noGravity = true;
            }
            if (ShroomitePoison)
            {
                int DustID2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width - 3, npc.height - 3, 1, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 10, new Color(126,138,255), 1.8f);
                Main.dust[DustID2].noGravity = true;
            }
            if (bleedingOut)
            {
                Random ran = new Random();
                int blood = ran.Next(0, 2);
                if (blood == 1)
                {
                    int DustID2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width - 3, npc.height - 3, 5, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 10, Color.Red, 1f);
                    Main.dust[DustID2].noGravity = true;
                }
            }
            if (hellfire)
            {
                int DustID3 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width - 3, npc.height - 3, 186, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 40, Color.Black, 2f);
                Main.dust[DustID3].noGravity = false;
                Main.dust[DustID3].velocity.Y = -6;
                int DustID2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width - 3, npc.height - 3, 6, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 10, Color.Red, 3f);
                Main.dust[DustID2].noGravity = false;
                Main.dust[DustID2].velocity.Y = -5;
            }
            if (cursedFire)
            {
                int DustID3 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y - (npc.height / 2)), npc.width - 3, npc.height - 3, 186, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 40, Color.Black, 2f);
                Main.dust[DustID3].noGravity = false;
                Main.dust[DustID3].velocity.Y = -6;
                int DustID2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width - 3, npc.height - 3, 228, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 10, Color.Green, 2f);
                Main.dust[DustID2].noGravity = false;
                Main.dust[DustID2].velocity.Y = -5;
            }
            if (gildedCurse)
            {
                int DustID3 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width - 3, npc.height - 3, 10, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 40, Color.Gold, 1.2f);
                Main.dust[DustID3].noGravity = true;
                int DustID2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width - 3, npc.height - 3, 19, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 40, Color.Gold, 0.8f);
                Main.dust[DustID2].noGravity = true;
                npc.color = Color.Gold;
            }
            if (ichorUproar)
            {
                int DustID3 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y - (npc.height / 2)), npc.width - 3, npc.height - 3, 186, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 40, Color.White, 2f);
                Main.dust[DustID3].noGravity = false;
                Main.dust[DustID3].velocity.Y = -6;
                int DustID2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width - 3, npc.height - 3, 228, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 10, Color.Orange, 2f);
                Main.dust[DustID2].noGravity = false;
                Main.dust[DustID2].velocity.Y = -5;
            }
            if (partyBuff)
            {
                int colorSelect = Main.rand.Next(0, 25);
                if (colorSelect == 0)
                    npc.color = Color.Red;
                if (colorSelect == 1)
                    npc.color = Color.Orange;
                if (colorSelect == 2)
                    npc.color = Color.Yellow;
                if (colorSelect == 3)
                    npc.color = Color.Green;
                if (colorSelect == 4)
                    npc.color = Color.Blue;
                if (colorSelect == 5)
                    npc.color = Color.Indigo;
                if (colorSelect == 6)
                    npc.color = Color.Violet;
            }
            if(VortexBuff)
            {
                if (Main.rand.NextFloat() < 0.4605263f)
                {
                    Dust dust;
                    Vector2 position = Main.LocalPlayer.Center;
                    dust = Main.dust[Terraria.Dust.NewDust(npc.position, npc.width, npc.height, 217, 0f, 0f, 0, new Color(0, 242, 255), 0.86f)];
                    dust.noGravity = true;
                    dust.fadeIn = 1.381579f;
                }
            }
        }
    }
}
