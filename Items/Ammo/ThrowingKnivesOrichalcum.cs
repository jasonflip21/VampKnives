﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VampKnives.Items.Ammo
{
    public class ThrowingKnivesOrichalcum : KnifeItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orichalcum Throwing Knives");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 7;
            item.width = 48;
            item.height = 48;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 1.5f;
            item.crit = 4;
            item.value = Item.sellPrice(0, 0, 8, 80);
            item.rare = 3;
            item.shoot = mod.ProjectileType("OrichalcumProj");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 6f;                  //The speed of the projectile
            item.ammo = mod.ItemType("ThrowingKnivesAmmo");              //The ammo class this ammo belongs to.
        }
        public override void AddRecipes()
        {
            DartCastRecipe recipe = new DartCastRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();

            recipe = new DartCastRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 1);
            recipe.AddTile(mod.GetTile("VampTableTile"));
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
        }
    }
}
