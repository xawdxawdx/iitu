using PixelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Snack
{
    public class ExampleSnake : ISnake
    {
        private const int _width = 50;
        private const int _wallDistanceThreshold = 5;
        private Point _myHeadPosition;
        private Point _foodPosition;

        public string Name => "Example Snake";

        public SnakeDirection GetNextDirection(SnakeDirection currentDirection)
        {
            if (_myHeadPosition.Y == _foodPosition.Y)
            {
                if (_myHeadPosition.X > _foodPosition.X)
                {
                    if (currentDirection == SnakeDirection.Right)
                    {
                        return SnakeDirection.Up;
                    }
                    else return SnakeDirection.Left;
                }
                if (_myHeadPosition.X < _foodPosition.X)
                {
                    if (currentDirection == SnakeDirection.Left)
                    {
                        return SnakeDirection.Down;
                    }
                    else return SnakeDirection.Right;
                }
            }
            
            if (_myHeadPosition.X == _foodPosition.X)
            {
                if (_myHeadPosition.Y > _foodPosition.Y)
                {
                    if (currentDirection == SnakeDirection.Down)
                    {
                        return SnakeDirection.Left;
                    }
                    else return SnakeDirection.Up;
                }
                if (_myHeadPosition.Y < _foodPosition.Y)
                {
                    if (currentDirection == SnakeDirection.Up)
                    {
                        return SnakeDirection.Right;
                    }
                    else return SnakeDirection.Down;
                }
            }



            if (_myHeadPosition.Y > _foodPosition.Y)
            {
                if (_myHeadPosition.X > _foodPosition.X)
                {
                    if (currentDirection == SnakeDirection.Right)
                    {
                        return SnakeDirection.Up;
                    }
                    else return SnakeDirection.Left;
                }
                else
                if (_myHeadPosition.X < _foodPosition.X)
                {
                    if (currentDirection == SnakeDirection.Left)
                    {
                        return SnakeDirection.Down;
                    }
                    else return SnakeDirection.Right;
                }
            }

            if (_myHeadPosition.Y < _foodPosition.Y)
            {
                //if (_myHeadPosition.X < _foodPosition.X)
                //{
                 //   return SnakeDirection.Down;
                //}

                if (_myHeadPosition.X < _foodPosition.X)
                {
                    if (currentDirection == SnakeDirection.Left)
                    {
                        return SnakeDirection.Down;
                    }
                    else
                    return SnakeDirection.Right;
                }
                
                if (_myHeadPosition.X > _foodPosition.X)
                {
                    if (currentDirection == SnakeDirection.Right)
                    {
                        return SnakeDirection.Up;
                    }
                    else return SnakeDirection.Left;
                }
            }

            //if (_myHeadPosition.Y > _foodPosition.Y)
            //{
        
            //    if (_myHeadPosition.X < _foodPosition.X && currentDirection == SnakeDirection.Left)
            //    {
            //        return SnakeDirection.Up;
            //    }
            //    if (_myHeadPosition.X > _foodPosition.X && currentDirection == SnakeDirection.Right)
            //    {
            //        return SnakeDirection.Up;
            //    }

            //}
            //
            if (currentDirection == SnakeDirection.Up 
                && _myHeadPosition.Y < _wallDistanceThreshold - 3)
            {
                return SnakeDirection.Left;
            }

            if(currentDirection == SnakeDirection.Right
                && _myHeadPosition.X > _width - _wallDistanceThreshold + 3)
            {
                return SnakeDirection.Up;
            }

            if(currentDirection == SnakeDirection.Down
                && _myHeadPosition.Y > _width - _wallDistanceThreshold + 2)
            {
                return SnakeDirection.Right;
            }

            if (currentDirection == SnakeDirection.Left
                && _myHeadPosition.X <  _wallDistanceThreshold - 3)
            {
                return SnakeDirection.Down;
            }

            return currentDirection;
        }

        public void UpdateMap(string map)
        {
            _myHeadPosition = getMyHeadPosition(map);
            _foodPosition = getFoodPosition(map);
        }

        private Point getMyHeadPosition(string map)
        {
            var headIndex = map.IndexOf('*');
            return new Point(headIndex % _width, headIndex / _width);
        }

        private Point getFoodPosition(string map)
        {
            var foodIndex = map.IndexOf('7');
            return new Point(foodIndex % _width, foodIndex / _width);
        }
    }
}
