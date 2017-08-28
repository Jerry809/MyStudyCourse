using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = new BallEventArgs(trajectory: 20, distance: 200);
            var ball = new Ball();
            var p = new Pitcher(ball);
            var fans = new Fans(ball);
            ball.OnBallInPlay(e);
            Console.ReadLine();
        }
    }
}
