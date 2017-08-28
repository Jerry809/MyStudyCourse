using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateCourse
{
    public class Fans
    {
        public Fans(Ball ball)
        {
            ball.BallInPlay += new EventHandler(ball_BallInPlay);
        }

        private void ball_BallInPlay(object sender, EventArgs e)
        {
            if (e is BallEventArgs)
            {
                var ballEventArgs = e as BallEventArgs;
                if (ballEventArgs.Distance > 100 && ballEventArgs.Trajectory < 50)
                {
                    Console.WriteLine("全壘打");
                }
            }
        }
    }
}
