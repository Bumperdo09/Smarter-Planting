using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace strictPlanterBoxes
{
    // Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
    public class strictPlanterBoxes : Mod
    {


        public override void Load()
        {

            IL_SmartCursorHelper.Step_AlchemySeeds += IL_SmartCursorHelper_Step_AlchemySeeds;

        }

        private void IL_SmartCursorHelper_Step_AlchemySeeds(MonoMod.Cil.ILContext il)
        {
            try
            {


                var c = new ILCursor(il);

                // Yes this relies on the order that the code runs, no I dont want to fix it

                // Daybloom
                c.GotoNext(
                        i => i.MatchLdloca(4),
                        i => i.MatchCall<Terraria.Tile>("get_type"),
                        i => i.MatchLdindU2(),
                        i => i.MatchLdcI4(380));

                c.Index = c.Index + 4;
                c.EmitCeq();
                c.EmitLdloc(4); //push tile onto stack
                c.EmitDelegate((Tile tile) => tile.TileFrameY / 18 == 0);// If style matches the planter box, jump 
                c.EmitAnd();
                c.EmitLdcI4(1); //this is jank but I dont want to edit the jump


                // Moonglow
                c.GotoNext(
                        i => i.MatchLdloca(4),
                        i => i.MatchCall<Terraria.Tile>("get_type"),
                        i => i.MatchLdindU2(),
                        i => i.MatchLdcI4(380));

                c.Index = c.Index + 4;
                c.EmitCeq();
                c.EmitLdloc(4); //push tile onto stack
                c.EmitDelegate((Tile tile) => tile.TileFrameY / 18 == 1);// If style matches the planter box, jump 
                c.EmitAnd();
                c.EmitLdcI4(1); //this is jank but I dont want to edit the jump


                // Blinkroot
                c.GotoNext(
                        i => i.MatchLdloca(4),
                        i => i.MatchCall<Terraria.Tile>("get_type"),
                        i => i.MatchLdindU2(),
                        i => i.MatchLdcI4(380));

                c.Index = c.Index + 4;
                c.EmitCeq();
                c.EmitLdloc(4); //push tile onto stack
                c.EmitDelegate((Tile tile) => tile.TileFrameY / 18 == 4);// If style matches the planter box, jump 
                c.EmitAnd();
                c.EmitLdcI4(1); //this is jank but I dont want to edit the jump

                // Deathweed
                c.GotoNext(
                        i => i.MatchLdloca(4),
                        i => i.MatchCall<Terraria.Tile>("get_type"),
                        i => i.MatchLdindU2(),
                        i => i.MatchLdcI4(380));

                c.Index = c.Index + 4;
                c.EmitCeq();
                c.EmitLdloc(4); //push tile onto stack
                c.EmitDelegate((Tile tile) => tile.TileFrameY / 18 == 2 || tile.TileFrameY / 18 == 3);// If style matches the planter box, jump 
                c.EmitAnd();
                c.EmitLdcI4(1); //this is jank but I dont want to edit the jump


                // Waterleaf
                c.GotoNext(
                        i => i.MatchLdloca(4),
                        i => i.MatchCall<Terraria.Tile>("get_type"),
                        i => i.MatchLdindU2(),
                        i => i.MatchLdcI4(380));

                c.Index = c.Index + 4;
                c.EmitCeq();
                c.EmitLdloc(4); //push tile onto stack
                c.EmitDelegate((Tile tile) => tile.TileFrameY / 18 == 5);// If style matches the planter box, jump 
                c.EmitAnd();
                c.EmitLdcI4(1); //this is jank but I dont want to edit the jump

                // Fireblossom
                c.GotoNext(
                        i => i.MatchLdloca(4),
                        i => i.MatchCall<Terraria.Tile>("get_type"),
                        i => i.MatchLdindU2(),
                        i => i.MatchLdcI4(380));

                c.Index = c.Index + 4;
                c.EmitCeq();
                c.EmitLdloc(4); //push tile onto stack
                c.EmitDelegate((Tile tile) => tile.TileFrameY / 18 == 7);// If style matches the planter box, jump 
                c.EmitAnd();
                c.EmitLdcI4(1); //this is jank but I dont want to edit the jump

                // Shiverthorn
                c.GotoNext(
                        i => i.MatchLdloca(4),
                        i => i.MatchCall<Terraria.Tile>("get_type"),
                        i => i.MatchLdindU2(),
                        i => i.MatchLdcI4(380));

                c.Index = c.Index + 4;
                c.EmitCeq();
                c.EmitLdloc(4); //push tile onto stack
                c.EmitDelegate((Tile tile) => tile.TileFrameY / 18 == 6);// If style matches the planter box, jump 
                c.EmitAnd();
                c.EmitLdcI4(1); //this is jank but I dont want to edit the jump
            }
            catch (Exception e)
            {
                // If there are any failures with the IL editing, this method will dump the IL to Logs/ILDumps/{Mod Name}/{Method Name}.txt
                MonoModHooks.DumpIL(ModContent.GetInstance<strictPlanterBoxes>(), il);

                // If the mod cannot run without the IL hook, throw an exception instead. The exception will call DumpIL internally
                //throw new ILPatchFailureException(ModContent.GetInstance<ExampleMod>(), il, e);
            }
        }
    }
}
