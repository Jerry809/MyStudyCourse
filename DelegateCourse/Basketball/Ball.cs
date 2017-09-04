using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateCourse
{
    public class Ball
    {
        public event EventHandler BallInPlay;

        // 事件通常為公用的，因此標示為 public
        // event 為關鍵字，一般 delegate 可為區域變數或成員變數，delegate 呼叫前若未指定任何方法，則會造成編譯錯誤，且第一次指定方法不可使用「+=」
        // 標示為 event 者僅能是成員變數，呼叫前若未指定任何方法，則僅在執行期間拋出例外，並且第一次指定方法可使用「+=」
        // EventHandler 則為 delegate 定義：  public delegate void EventHandler(object sender, EventArgs e);
        public void OnBallInPlay(BallEventArgs e)
        {
            if (BallInPlay != null)
            {
                BallInPlay(this, e);
            }
        }
    }
}
