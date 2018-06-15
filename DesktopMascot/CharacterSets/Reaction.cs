using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    public struct Reaction
    {
        // 今後ほかにも必要な反応があるかもしれないのでこのクラスを作った
        // 今のところ必要なのは「何を喋るか」というだけなので、stringだけになっている。

        // メッセージ
        public String message;
        // 二個メッセージが必要なものは適宜使用する
        public String subMessage;
    }
}
