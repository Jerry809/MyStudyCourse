using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateCourse
{
    public class Pitcher
    {
        public Pitcher(Ball ball)
        {
            ball.BallInPlay += new EventHandler(ball_BallInPlay); // 訂閱 BallInPlay 事件
        }

        private void ball_BallInPlay(object sender, EventArgs e)
        {
            // BallInPlay 事件處理方法

            if (e is BallEventArgs)
            {        
                // 判斷物件是否為 BallEventArgs 實體
                BallEventArgs ballEventArgs = e as BallEventArgs;  // 將物件由 EventArgs 轉型 BallEventArgs

                if ((ballEventArgs.Distance < 95) && (ballEventArgs.Trajectory < 60))
                    CatchBall();
                else
                    CoverFirstBase();
            }

        }

        private static void CatchBall()
        {
            Console.WriteLine("投手接殺");
        }

        private static void CoverFirstBase()
        {
            Console.WriteLine("投手穿越球");
        }
    }
}
