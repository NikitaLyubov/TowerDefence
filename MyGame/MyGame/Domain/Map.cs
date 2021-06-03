using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace MyGame
{
    enum State
    {
        Empty,
        Visited,
        Wall,
    }

    class Map
    {
        private static readonly string[] SimpleMap = new string[]
        {

            "XXXXXXXXXXXXX",
            "XXXXXXXXXXXXX",
            "X    XXXXXXXX",
            "  XX XX      ",
            "XXXX    XXXXX",
            "XXXXXXXXXXXXX",
            "XXXXXXXXXXXXX"


        };

        // Поиск пути обходом в ширину
        public static State[,] GetRouteV2(string[] mapState)
        {
            var map = new State[mapState[0].Length, mapState.Length];
            for (var x = 0; x < map.GetLength(0); x++)
            for (var y = 0; y < map.GetLength(1); y++)
                map[x, y] = mapState[y][x] == ' ' ? State.Empty : State.Wall;
            return map;
        }

        public static List<Point> Route(State[,] map, Point startPoint)
        {
            var listPoint = new List<Point>();
            var queue = new Queue<Point>();
            queue.Enqueue(startPoint);
            while (queue.Count != 0)
            {
                var point = queue.Dequeue();
                if (point.X < 0
                    || point.X >= map.GetLength(0)
                    || point.Y < 0
                    || point.Y >= map.GetLength(1))
                    continue;
                if (map[point.X, point.Y] != State.Empty)
                    continue;
                map[point.X, point.Y] = State.Visited;
                listPoint.Add(point);
                for (var dy = -1; dy <= 1; dy++)
                for (var dx = -1; dx <= 1; dx++)
                    if (dx != 0 && dy != 0)
                        continue;
                    else
                        queue.Enqueue(new Point(point.X + dx, point.Y + dy));
            }
            return listPoint;
        }
        
        public static List<Point> Way()
        {
            var field = GetRouteV2(SimpleMap);
            var points = Route(field, new Point(0, 3));
            for (var i = 0; i < points.Count; i++)
            {
                points[i] = new Point(points[i].X * 150 + 50 , points[i].Y * 150);
            }
            return CurPoints(points); ;
        }

        // Разбивание пути на маленькие подпути
        public static List<Point> CurPoints(List<Point> wayList)
        {
            var list = new List<Point>();
            
            for (var i = 0; i < wayList.Count-1; i++)
            {
                if (wayList[i].X < wayList[i + 1].X && wayList[i].Y == wayList[i + 1].Y)
                {
                    var tmp = wayList[i];

                    while (tmp.X != wayList[i + 1].X)
                    {
                        tmp.X += 5;
                        list.Add(tmp);
                    }

                }

                if (wayList[i].X == wayList[i + 1].X && wayList[i].Y < wayList[i + 1].Y)
                {
                    var tmp = wayList[i];
                   
                    while (tmp.Y != wayList[i + 1].Y)
                    {
                        tmp.Y += 5;
                        list.Add(tmp);
                    }
                }

                if (wayList[i].X == wayList[i + 1].X && wayList[i].Y > wayList[i + 1].Y)
                {
                    var tmp = wayList[i];
                  
                    while (tmp.Y != wayList[i + 1].Y)
                    {
                        tmp.Y -= 5;
                        list.Add(tmp);
                    }
                }
            }

            return list;

        }
    }
}


