using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace IFramework.Net
{
    internal class TokenConnectionManager
    {
        LinkedList<NetConnectionToken> list = null;
        int period = 60;//s
        System.Threading.Timer timeoutThreading = null;
        LockParam lockParam = null;

        public int ConnectionTimeout { get; set; } = 60;//s

        public int Count { get { return list.Count; } }

        public TokenConnectionManager(int period)
        {
            if (period < 2) this.period = 2;
            else this.period = period;
 
            lockParam = new LockParam();
            int _period = GetPeriodSeconds();
            list = new LinkedList<NetConnectionToken>();
            timeoutThreading = new System.Threading.Timer(new TimerCallback(timeoutHandler), null, _period, _period);
        }

        private int GetPeriodSeconds()
        {
            return (period * 1000) >> 1;
        }

        public void TimerEnable(bool isContinue)
        {
            if (isContinue)
            {
                int _period = GetPeriodSeconds();
                timeoutThreading.Change(_period, _period);
            }
            else timeoutThreading.Change(-1, -1);
        }

        public void TimeoutChange(int period)
        {
            this.period = period;
            if (period < 2) this.period = 2;

            int _p = GetPeriodSeconds();
            timeoutThreading.Change(_p, _p);
        }

        public NetConnectionToken GetTopToken()
        {
            using(LockWait lwait=new LockWait(ref lockParam))
            {
                if (list.Count > 0)
                    return list.First();
                return null;
            }
        }

        public IEnumerable<NetConnectionToken> ReadNext()
        {
            using(LockWait lwait=new LockWait(ref lockParam))
            {
                foreach (var l in list)
                {
                    yield return l;
                }
            }
        }

        public void InsertToken(NetConnectionToken ncToken)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                list.AddLast(ncToken);
            }
        }

        public bool RemoveToken(NetConnectionToken ncToken,bool isClose)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                if (isClose) ncToken.Token.Close();
                return list.Remove(ncToken);
            }
        }

        public bool RemoveToken(SocketToken sToken)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                var item = list.Where(x => x.Token.CompareTo(sToken) == 0).FirstOrDefault();
                if (item != null)
                {
                   return list.Remove(item);
                }
            }
            return false;
        }

        public NetConnectionToken GetTokenById(int Id)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                return list.Where(x => x.Token.TokenId == Id).FirstOrDefault();
            }
        }

        public NetConnectionToken GetTokenBySocketToken(SocketToken sToken)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                return list.Where(x => x.Token.CompareTo(sToken) == 0).FirstOrDefault();
            }
        }

        public void Clear(bool isClose)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                while (list.Count > 0)
                {
                    var item = list.First();
                    list.RemoveFirst();

                    if (isClose)
                    {
                        if (item.Token != null)
                            item.Token.Close();
                    }
                }
            }
        }

        public bool RefreshConnectionToken(SocketToken sToken)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                var rt = list.Find(new NetConnectionToken(sToken));

                if (rt == null) return false;

                rt.Value.ConnectionTime = DateTime.Now;
                return true;
            }
        }

        private void timeoutHandler(object obj)
        {
            using (LockWait lwait = new LockWait(ref lockParam))
            {
                var items= list.Where(x => x.Verification == false ||
                DateTime.Now.Subtract(x.ConnectionTime).TotalSeconds >= ConnectionTimeout)
                    .ToArray();

                for (int i = 0; i < items.Length; ++i)
                {
                    items[i].Token.Close();
                    list.Remove(items[i]);
                }
            }
        }
    }

    public class NetConnectionToken:IComparable<NetConnectionToken>
    {

        public NetConnectionToken() { }

        public NetConnectionToken(SocketToken sToken)
        {
            this.Token = sToken;
            Verification = true;
            ConnectionTime = DateTime.Now;//兼容低版本语法
        }

        public SocketToken Token { get; set; }

        public DateTime ConnectionTime { get; set; }

        public bool Verification { get; set; }

        public int CompareTo(NetConnectionToken item)
        {
            return Token.CompareTo(item.Token);
        }

        public override bool Equals(object obj)
        {
            var nc = obj as NetConnectionToken;
            if (nc == null) return false;

            return this.CompareTo(nc) == 0;
        }

        public override int GetHashCode()
        {
            return Token.TokenId.GetHashCode()|Token.TokenSocket.GetHashCode();
        }
    }
}
