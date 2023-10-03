using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ai_for_games_lab_week_1
{
    internal static class ShapebatcherHelpers
    {
        public static void Draw(this ShapeBatcher shapeBatcher, Agent agent, Microsoft.Xna.Framework.Color colour)
        {
            shapeBatcher.DrawCircle(agent.Position, agent.Radius, 100, 2, colour);
        }
    }
}
