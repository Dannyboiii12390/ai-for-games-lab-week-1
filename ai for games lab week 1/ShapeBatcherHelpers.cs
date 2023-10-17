using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoGameLib;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using ImGuiNET;
using MonoGameLib.Shapes;

namespace ai_for_games_lab_week_1
{
    internal static class ShapebatcherHelpers
    {
        public static void HelperDraw(this ShapeBatcher shapeBatcher, Agent agent, Color colour)
        {
            shapeBatcher.Begin();
            shapeBatcher.DrawCircle(agent.Position, agent.Radius, 100, 2, colour);
            shapeBatcher.End();
        }
        public static void HelperDraw(this ShapeBatcher shapeBatcher, Circle circle)
        {
            shapeBatcher.Begin();
            shapeBatcher.DrawCircle(circle._position, circle._radius, circle.numVertices, circle.thickness, circle._colour);
            shapeBatcher.End();
        }

        public static void HelperDrawArrow(this ShapeBatcher shapeBatcher, Circle circle)
        {
            shapeBatcher.Begin();
            shapeBatcher.DrawArrow(circle.position, circle._velocity, 2, 10, circle._colour);
            shapeBatcher.End();
        }
        public static void HelperDrawArrow(this ShapeBatcher shapeBatcher, Agent agent, Color colour)
        {
            shapeBatcher.Begin();
            shapeBatcher.DrawArrow(agent.Position, agent.Velocity, 2, 5, colour);
            shapeBatcher.End();

        }
        public static void HelperDrawLine(this ShapeBatcher shapeBatcher, Line line)
        {
            shapeBatcher.Begin();
            shapeBatcher.DrawLine(line._position, line.end, line.thickness, line._colour);
            shapeBatcher.End();
        }
        public static void HelperDrawTriangle(this ShapeBatcher shapeBatcher, MonoGameLib.Shapes.Triangle triangle)
        {
            shapeBatcher.Begin();
            shapeBatcher.DrawLine(triangle._position, triangle._position2, 2, triangle._colour);
            shapeBatcher.DrawLine(triangle._position2, triangle._position3, 2, triangle._colour);
            shapeBatcher.DrawLine(triangle._position, triangle._position3, 2, triangle._colour);
            shapeBatcher.End();

        }

    }
            
}
