using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VampKnives.UI;
using Terraria.UI;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using VampKnives.Projectiles;

namespace VampKnives
{
    public class VampKnives : Mod
    {
        internal static VampKnives instance;
        public static ModHotKey HoodUpDownHotkey;
        public static ModHotKey SupportHotKey;
        public static int inventoryIndex;
        public UserInterface customRecources;
        public UserInterface customResources2;
        public UserInterface FirstLoadUI;
        private VampBar vampBar;
        private RecipePageState RecipePage;
        private EntranceDamageSettingsPanel FirstLoadUIPanel;
        private WarningMessage warning;
        //private UserInterface WarningMessage;
        internal UserInterface WarningMessagePerson;
        internal UserInterface VampireUserInterface;
        internal UserInterface VampireUserInterface2;
        public static bool IsAmmoRecipe;
        public static bool IsKnifeRecipe;
        public static bool IsSharpeningRodRecipe;
        public static bool IsPlateRecipe;
        public static bool IsAmmoSculptRecipe;
        public static bool IsKnifeSculptRecipe;
        public static bool IsSharpeningSculptRecipe;
        public static bool ChosenDifficulty;
        public static bool Legacy;
        public static bool Normal;
        public static bool Unforgiving;
        public static bool ChangeItemIsHeld;
        public static bool HammerInSlot;
        public static bool ChiselInSlot;
        public UserInterface WorkbenchSlots;
        private WorkbenchSlotState WorkbenchSlotPanel;
        //public static ModPacket MyPacket;
        //public static int MyPacketIdentifier;
        //private UserInterface VampBarInterface;
        //public VampBar vampbar;
        //private VampResource VampResource;

        public VampKnives()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            ModRecipe recipe2 = new ModRecipe(this);
            ModRecipe recipe3 = new ModRecipe(this);
            ModRecipe recipe4 = new ModRecipe(this);
            ModRecipe recipe5 = new ModRecipe(this);
            ModRecipe recipe6 = new ModRecipe(this);
            ModRecipe recipe7 = new ModRecipe(this);
            ModRecipe recipe8 = new ModRecipe(this);
            ModRecipe recipe9 = new ModRecipe(this);
            ModRecipe recipe10 = new ModRecipe(this);
            ModRecipe recipe11 = new ModRecipe(this);
            recipe.AddIngredient(this.GetItem("IronKnives"), 1);
            recipe.AddIngredient(ItemID.CrimsonKey, 1);
            recipe.AddTile(this.GetTile("KnifeBench"));
            recipe.SetResult(ItemID.VampireKnives);
            recipe.AddRecipe();
            recipe2.AddIngredient(this.GetItem("WeakVampireKnives"), 1);
            recipe2.AddIngredient(this.GetItem("LivingTissue"), 1);
            recipe2.AddTile(this.GetTile("KnifeBench"));
            recipe2.SetResult(ItemID.VampireKnives);
            recipe2.AddRecipe();
            recipe3.AddIngredient(ItemID.GlowingMushroom, 1);
            recipe3.AddIngredient(ItemID.BottledWater, 1);
            recipe3.AddTile(TileID.AlchemyTable);
            recipe3.SetResult(ItemID.LesserManaPotion);
            recipe3.AddRecipe();
            recipe4.AddIngredient(this.GetItem("Chisel"), 1);
            recipe4.AddTile(TileID.Furnaces);
            recipe4.SetResult(ItemID.IronBar);
            recipe4.AddRecipe();
            recipe5.AddIngredient(this.GetItem("Hammer"), 1);
            recipe5.AddTile(TileID.Furnaces);
            recipe5.SetResult(ItemID.IronBar, 1);
            recipe5.AddRecipe();
            recipe6.AddIngredient(this.GetItem("DartCast"));
            recipe6.AddTile(TileID.Furnaces);
            recipe6.SetResult(ItemID.IronBar, 3);
            recipe6.AddRecipe();
            recipe7.AddIngredient(this.GetItem("IronKnivesMold"));
            recipe7.AddTile(TileID.Furnaces);
            recipe7.SetResult(ItemID.IronBar, 3);
            recipe7.AddRecipe();
            recipe8.AddIngredient(this.GetItem("Chisel"), 1);
            recipe8.AddTile(TileID.Furnaces);
            recipe8.SetResult(ItemID.LeadBar);
            recipe8.AddRecipe();
            recipe9.AddIngredient(this.GetItem("Hammer"), 1);
            recipe9.AddTile(TileID.Furnaces);
            recipe9.SetResult(ItemID.LeadBar, 1);
            recipe9.AddRecipe();
            recipe10.AddIngredient(this.GetItem("DartCast"));
            recipe10.AddTile(TileID.Furnaces);
            recipe10.SetResult(ItemID.LeadBar, 3);
            recipe10.AddRecipe();
            recipe11.AddIngredient(this.GetItem("IronKnivesMold"));
            recipe11.AddTile(TileID.Furnaces);
            recipe11.SetResult(ItemID.LeadBar, 3);
            recipe11.AddRecipe();
            recipe11 = new ModRecipe(this);
            recipe11.AddIngredient(this.GetItem("SharpeningRodCast"));
            recipe11.AddTile(TileID.Furnaces);
            recipe11.SetResult(ItemID.LeadBar, 3);
            recipe11.AddRecipe();
            recipe11 = new ModRecipe(this);
            recipe11.AddIngredient(this.GetItem("SharpeningRodCast"));
            recipe11.AddTile(TileID.Furnaces);
            recipe11.SetResult(ItemID.IronBar, 3);
            recipe11.AddRecipe();
        }
        public override void Load()
        {
            instance = this;
            HoodUpDownHotkey = RegisterHotKey("HoodUpDown", "P");
            SupportHotKey = RegisterHotKey("Key to add/remove support debuff", "L");
            if (!Main.dedServ)
            {
                //AddEquipTexture(null, EquipType.Legs, "ExampleRobe_Legs", "ExampleMod/Items/Armor/ExampleRobe_Legs");
                AddEquipTexture(new Items.Armor.PyroHead(), null, EquipType.Head, "PyroHead", "VampKnives/Items/Armor/PyromancersHood_Head");
                AddEquipTexture(new Items.Armor.DPyroHead(), null, EquipType.Head, "DPyroHead", "VampKnives/Items/Armor/DarkPyromancersHood_Head");
                AddEquipTexture(new Items.Armor.TransmuterHead(), null, EquipType.Head, "TransmuterHead", "VampKnives/Items/Armor/TransmutersHood_Head");
                AddEquipTexture(new Items.Armor.InvokerHead(), null, EquipType.Head, "InvokerHead", "VampKnives/Items/Armor/InvokersHood_Head");
                AddEquipTexture(new Items.Armor.TechnomancerHead(), null, EquipType.Head, "TechnomancerHead", "VampKnives/Items/Armor/TechnomancersHood_Head");
                AddEquipTexture(new Items.Armor.PartyHead(), null, EquipType.Head, "PartyHead", "VampKnives/Items/Armor/PartyHood_Head");
                AddEquipTexture(new Items.Armor.ShamanHead(), null, EquipType.Head, "ShamanHead", "VampKnives/Items/Armor/ShamansHood_Head");
                AddEquipTexture(new Items.Armor.WitchDoctorHead(), null, EquipType.Head, "WitchDoctorHead", "VampKnives/Items/Armor/WitchDoctorHood_Head");
                AddEquipTexture(new Items.Armor.MageHead(), null, EquipType.Head, "MageHead", "VampKnives/Items/Armor/MagesHood_Head");

                customRecources = new UserInterface();
                customResources2 = new UserInterface();
                FirstLoadUI = new UserInterface();
                FirstLoadUIPanel = new EntranceDamageSettingsPanel();
                vampBar = new VampBar();
                VampBar.visible = true;
                RecipePage = new RecipePageState();
                customResources2.SetState(RecipePage);
                customRecources.SetState(vampBar);
                FirstLoadUI.SetState(FirstLoadUIPanel);
                VampireUserInterface = new UserInterface();
                VampireUserInterface2 = new UserInterface();

                WorkbenchSlots = new UserInterface();
                WorkbenchSlotPanel = new WorkbenchSlotState();
                WorkbenchSlots.SetState(WorkbenchSlotPanel);

            }
            base.Load();
        }
        public override void UpdateUI(GameTime gameTime)
        {
            if (!Legacy && !Normal && !Unforgiving)
            {
                EntranceDamageSettingsPanel.visible = true;
            }
            else if((Legacy || Normal || Unforgiving) && !ChangeItemIsHeld)
            {
                EntranceDamageSettingsPanel.visible = false;
            }
            VampireUserInterface?.Update(gameTime);
            VampireUserInterface2?.Update(gameTime);
            if (IsKnifeRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = true;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsAmmoRecipe)
            {
                RecipePageState.IsAmmoRecipe = true;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsSharpeningRodRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = true;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsPlateRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = true;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsAmmoSculptRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = true;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsKnifeSculptRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = true;
                RecipePageState.IsSharpeningSculptRecipe = false;
            }
            else if (IsSharpeningSculptRecipe)
            {
                RecipePageState.IsAmmoRecipe = false;
                RecipePageState.IsKnifeRecipe = false;
                RecipePageState.IsSharpeningRodRecipe = false;
                RecipePageState.IsPlateRecipe = false;
                RecipePageState.IsAmmoSculptRecipe = false;
                RecipePageState.IsKnifeSculptRecipe = false;
                RecipePageState.IsSharpeningSculptRecipe = true;
            }
            else
            {
                IsKnifeRecipe = false;
                IsAmmoRecipe = false;
                IsSharpeningRodRecipe = false;
                IsPlateRecipe = false;
                IsAmmoSculptRecipe = false;
                IsKnifeSculptRecipe = false;
                IsSharpeningSculptRecipe = false;
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex(layer => layer.Name.Contains("Vanilla: Mouse Text"));
            if (index != -1)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer("VampBars: Blood Resource Bar", delegate
                {
                    if (VampBar.visible)
                    {
                        customRecources.Update(Main._drawInterfaceGameTime);
                        vampBar.Draw(Main.spriteBatch);
                    }
                    if(RecipePageState.visible)
                    {
                        customResources2.Update(Main._drawInterfaceGameTime);
                        RecipePage.Draw(Main.spriteBatch);
                    }
                    if(EntranceDamageSettingsPanel.visible)
                    {
                        FirstLoadUI.Update(Main._drawInterfaceGameTime);
                        FirstLoadUIPanel.Draw(Main.spriteBatch);
                    }
                    if (WorkbenchSlotState.visible)
                    {
                        WorkbenchSlots.Update(Main._drawInterfaceGameTime);
                        WorkbenchSlotPanel.Draw(Main.spriteBatch);
                    }
                    return true;
                }));
                if(Main.playerInventory == false && WorkbenchSlotState.visible)
                {
                    WorkbenchSlotState.visible = false;
                }
            }
            inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (inventoryIndex != -1)
            {
                layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
                    "Skin shop UI",
                    delegate
                    {
                        VampireUserInterface.Draw(Main.spriteBatch, new GameTime());
                        VampireUserInterface2.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
        public override void Unload()
        {
            HoodUpDownHotkey = null;
            SupportHotKey = null;
            instance = null;
            base.Unload();
        }
        int Packet2 = 22;
        int Packet5 = 55;
        int Packet6 = 66;
        int Packet4 = 44;
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            int idVariable = reader.ReadInt32();
            if (idVariable == 11)
            {
                bool KeyPressed = reader.ReadBoolean();
                int playerID = reader.ReadInt32();
                ModPacket packet2 = this.GetPacket();
                packet2.Write(Packet2);
                packet2.Write(KeyPressed);
                packet2.Write(playerID);
                packet2.Send(-1, playerID); 
            }
            if (idVariable == Packet2)
            {
                bool KeyPressed2 = reader.ReadBoolean();

                int playerID = reader.ReadInt32();
                Main.player[playerID].GetModPlayer<ExamplePlayer>().HoodIsVisible = KeyPressed2;
            }
            if (idVariable == 33)
            {
                Main.LocalPlayer.GetModPlayer<ExamplePlayer>().NeckProgress++;
            }

            if (idVariable == Packet5)
            {
                int Owner = reader.ReadInt32();
                int Decision = reader.ReadInt32();
                int SyncLifeAmount = reader.ReadInt32();
                bool BuffState = Main.player[Owner].HasBuff(ModContent.BuffType<Buffs.TrueSupportDebuff>());
                ModPacket packet5 = this.GetPacket();
                packet5.Write(Packet6);
                packet5.Write(Decision);
                packet5.Write(SyncLifeAmount);
                packet5.Write(Owner);
                packet5.Write(BuffState);
                packet5.Send(-1, Owner);
            }
            if (idVariable == Packet6)
            {
                int Decision = reader.ReadInt32();
                int SyncLifeAmount = reader.ReadInt32();
                int Owner = reader.ReadInt32();
                bool BuffState = reader.ReadBoolean();
                if (BuffState)
                    Main.player[Owner].AddBuff(ModContent.BuffType<Buffs.TrueSupportDebuff>(), 60);
                Main.player[Decision].statLife += (SyncLifeAmount);
                if (SyncLifeAmount >= 1)
                    Main.player[Decision].HealEffect(SyncLifeAmount, false);
            }
            base.HandlePacket(reader, whoAmI);
        }
    }
}