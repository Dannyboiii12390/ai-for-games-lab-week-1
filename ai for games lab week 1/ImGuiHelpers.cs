using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ai_for_games_lab_week_1
{
    internal static class ImGuiHelpers
    {
        public static void RenderGui(this Agent agent)
        {
            System.Numerics.Vector2 v = agent.Velocity.ToNumerics();

            if (ImGui.InputFloat2("velocity", ref v))
            {
                agent.Velocity = v;
            }
        }
    }
}
