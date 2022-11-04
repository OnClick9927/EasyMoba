using System;
using System.Collections.Generic;

namespace IFramework.Net.KCP
{
    public class Kcp
    {
        private class Segment
        {
            internal uint conv = 0;
            internal uint cmd = 0;
            internal uint frg = 0;
            internal uint wnd = 0;
            internal uint ts = 0;
            internal uint sn = 0;
            internal uint una = 0;
            internal uint rto = 0;
            internal uint xmit = 0;
            internal uint resendts = 0;
            internal uint fastack = 0;
            internal uint acked = 0;
            internal BufferQueue data;
            private class Pool : ObjectPool<Segment>
            {
                protected override Segment CreateNew(IEventArgs arg)
                {
                    return null;
                }
            }
            private static Pool _pool = new Pool();
            public static Segment Get(int size)
            {
                if (_pool.count > 0)
                {
                    var seg = _pool.Get();
                    seg.data = BufferQueue.Allocate(size, true);
                    return seg;
                }
                return new Segment(size);
            }

            public static void Put(Segment seg)
            {
                seg.Reset();
                _pool.Set(seg);
            }

            private Segment(int size)
            {
                data = BufferQueue.Allocate(size, true);
            }

            // encode a segment into buffer
            internal int Encode(byte[] ptr, int offset)
            {

                var offset_ = offset;

                offset += KcpTool.Encode(ptr, offset, conv);
                offset += KcpTool.Encode(ptr, offset, (byte)cmd);
                offset += KcpTool.Encode(ptr, offset, (byte)frg);
                offset += KcpTool.Encode(ptr, offset, (UInt16)wnd);
                offset += KcpTool.Encode(ptr, offset, ts);
                offset += KcpTool.Encode(ptr, offset, sn);
                offset += KcpTool.Encode(ptr, offset, una);
                offset += KcpTool.Encode(ptr, offset, (uint)data.canRead);

                return offset - offset_;
            }

            internal void Reset()
            {
                conv = 0;
                cmd = 0;
                frg = 0;
                wnd = 0;
                ts = 0;
                sn = 0;
                una = 0;
                rto = 0;
                xmit = 0;
                resendts = 0;
                fastack = 0;
                acked = 0;

                data.Clear();
                data.Dispose();
                data = null;
            }
        }

        private struct Ack
        {
            internal uint sn;
            internal uint ts;
        }

        private DateTime _startTime = DateTime.Now;

        public uint time
        {
            get
            {
                var ts = DateTime.Now.Subtract(_startTime);
                return (uint)ts.TotalMilliseconds;
            }
        }

        uint conv; uint mtu; uint mss; uint state;
        uint snd_una; uint snd_nxt; uint rcv_nxt;
        uint ts_recent; uint ts_lastack; uint ssthresh;
        uint rx_rttval; uint rx_srtt;
        uint rx_rto; uint rx_minrto;
        uint snd_wnd; uint rcv_wnd; uint rmt_wnd; uint cwnd; uint probe;
        uint interval; uint ts_flush;
        uint nodelay; uint updated;
        uint ts_probe; uint probe_wait;
        uint dead_link; uint incr;

        Int32 fastresend;//快速重发间隔片个数
        bool nocwnd;//关闭拥塞控制
        public bool stream;//是否启用流控

        List<Segment> snd_queue = new List<Segment>(16);
        List<Segment> rcv_queue = new List<Segment>(16);
        List<Segment> snd_buf = new List<Segment>(16);
        List<Segment> rcv_buf = new List<Segment>(16);

        List<Ack> acklist = new List<Ack>(16);

        byte[] buffer;
        Int32 reserved;
        IKcpSocket _sender; // buffer, size
        public uint sendWindow { get { return snd_wnd; } }
        public uint recWindow { get { return rcv_wnd; } }
        public uint RmtWnd { get { return rmt_wnd; } }
        /// <summary>
        /// 每个分片最大  大小
        /// </summary>
        public uint Mss { get { return mss; } }

        // get how many packet is waiting to be sent
        public int waitToSend { get { return snd_buf.Count + snd_queue.Count; } }


        // create a new kcp control object, 'conv' must equal in two endpoint
        // from the same connection.
        public Kcp(uint conv_, IKcpSocket sender)
        {
            conv = conv_;
            snd_wnd = KcpTool.IKCP_WND_SND;
            rcv_wnd = KcpTool.IKCP_WND_RCV;
            rmt_wnd = KcpTool.IKCP_WND_RCV;
            mtu = KcpTool.IKCP_MTU_DEF;
            mss = mtu - KcpTool.IKCP_OVERHEAD;
            rx_rto = KcpTool.IKCP_RTO_DEF;
            rx_minrto = KcpTool.IKCP_RTO_MIN;
            interval = KcpTool.IKCP_INTERVAL;
            ts_flush = KcpTool.IKCP_INTERVAL;
            ssthresh = KcpTool.IKCP_THRESH_INIT;
            dead_link = KcpTool.IKCP_DEADLINK;
            buffer = new byte[mtu];
            _sender = sender;
        }

        // check the size of next message in the recv queue
        public int PeekSize()
        {
            if (0 == rcv_queue.Count) return -1;
            var seq = rcv_queue[0];
            if (0 == seq.frg) return seq.data.canRead;
            if (rcv_queue.Count < seq.frg + 1) return -1;
            int length = 0;
            foreach (var item in rcv_queue)
            {
                length += item.data.canRead;
                if (0 == item.frg)
                    break;
            }
            return length;
        }



        public int Recv(byte[] buffer, int index, int length)
        {
            var peekSize = PeekSize();
            if (peekSize < 0)return -1;
            if (peekSize > length)return -2;

            var fast_recover = false;
            if (rcv_queue.Count >= rcv_wnd)
                fast_recover = true;

            // merge fragment.
            var count = 0;
            var n = index;
            foreach (var seg in rcv_queue)
            {
                // copy fragment data into buffer.
                Buffer.BlockCopy(seg.data.buffer, seg.data.reader, buffer, n, seg.data.canRead);
                n += seg.data.canRead;

                count++;
                var fragment = seg.frg;
                Segment.Put(seg);
                if (0 == fragment) break;
            }

            if (count > 0) rcv_queue.RemoveRange(0, count);

            // move available data from rcv_buf -> rcv_queue
            count = 0;
            foreach (var seg in rcv_buf)
            {
                if (seg.sn == rcv_nxt && rcv_queue.Count + count < rcv_wnd)
                {
                    rcv_queue.Add(seg);
                    rcv_nxt++;
                    count++;
                }
                else
                {
                    break;
                }
            }

            if (count > 0)
            {
                rcv_buf.RemoveRange(0, count);
            }


            // fast recover
            if (rcv_queue.Count < rcv_wnd && fast_recover)
            {
                // ready to send back IKCP_CMD_WINS in ikcp_flush
                // tell remote my window size
                probe |= KcpTool.IKCP_ASK_TELL;
            }

            return n - index;
        }


        // user/upper level send, returns below zero for error
        public int Send(byte[] buffer, int index, int length)
        {
            if (0 == length) return -1;

            if (stream)
            {
                var n = snd_queue.Count;
                if (n > 0)
                {
                    var seg = snd_queue[n - 1];
                    if (seg.data.canRead < mss)
                    {
                        var capacity = (int)(mss - seg.data.canRead);
                        var writen = Math.Min(capacity, length);
                        seg.data.WriteBytes(buffer, index, writen);
                        index += writen;
                        length -= writen;
                    }
                }
            }

            if (length == 0)
                return 0;

            var count = 0;
            if (length <= mss)
                count = 1;
            else
                count = (int)(((length) + mss - 1) / mss);

            if (count > 255) return -2;

            if (count == 0) count = 1;

            for (var i = 0; i < count; i++)
            {
                var size = Math.Min(length, (int)mss);

                var seg = Segment.Get(size);
                seg.data.WriteBytes(buffer, index, size);
                index += size;
                length -= size;

                seg.frg = (!stream ? (byte)(count - i - 1) : (byte)0);
                snd_queue.Add(seg);
            }

            return 0;
        }

        // update ack.
        void update_ack(Int32 rtt)
        {
            // https://tools.ietf.org/html/rfc6298
            if (0 == rx_srtt)
            {
                rx_srtt = (uint)rtt;
                rx_rttval = (uint)rtt >> 1;
            }
            else
            {
                Int32 delta = (Int32)((uint)rtt - rx_srtt);
                rx_srtt += (uint)(delta >> 3);
                if (0 > delta) delta = -delta;

                if (rtt < rx_srtt - rx_rttval)
                {
                    // if the new RTT sample is below the bottom of the range of
                    // what an RTT measurement is expected to be.
                    // give an 8x reduced weight versus its normal weighting
                    rx_rttval += (uint)((delta - rx_rttval) >> 5);
                }
                else
                {
                    rx_rttval += (uint)((delta - rx_rttval) >> 2);
                }
            }

            var rto = (int)(rx_srtt + KcpTool.Max(interval, rx_rttval << 2));
            rx_rto = KcpTool.Clamp(rx_minrto, (uint)rto, KcpTool.IKCP_RTO_MAX);
        }

        void shrink_buf()
        {
            if (snd_buf.Count > 0)
                snd_una = snd_buf[0].sn;
            else
                snd_una = snd_nxt;
        }

        void parse_ack(uint sn)
        {

            if (KcpTool.Subtract(sn, snd_una) < 0 || KcpTool.Subtract(sn, snd_nxt) >= 0) return;

            foreach (var seg in snd_buf)
            {
                if (sn == seg.sn)
                {
                    // mark and free space, but leave the segment here,
                    // and wait until `una` to delete this, then we don't
                    // have to shift the segments behind forward,
                    // which is an expensive operation for large window
                    seg.acked = 1;
                    break;
                }
                if (KcpTool.Subtract(sn, seg.sn) < 0)
                    break;
            }
        }

        void parse_fastack(uint sn, uint ts)
        {
            if (KcpTool.Subtract(sn, snd_una) < 0 || KcpTool.Subtract(sn, snd_nxt) >= 0)
                return;

            foreach (var seg in snd_buf)
            {
                if (KcpTool.Subtract(sn, seg.sn) < 0)
                    break;
                else if (sn != seg.sn && KcpTool.Subtract(seg.ts, ts) <= 0)
                    seg.fastack++;
            }
        }

        void parse_una(uint una)
        {
            var count = 0;
            foreach (var seg in snd_buf)
            {
                if (KcpTool.Subtract(una, seg.sn) > 0)
                {
                    count++;
                    Segment.Put(seg);
                }
                else
                    break;
            }

            if (count > 0)
                snd_buf.RemoveRange(0, count);
        }

        void ack_push(uint sn, uint ts)
        {
            acklist.Add(new Ack { sn = sn, ts = ts });
        }

        bool parse_data(Segment newseg)
        {
            var sn = newseg.sn;
            if (KcpTool.Subtract(sn, rcv_nxt + rcv_wnd) >= 0 || KcpTool.Subtract(sn, rcv_nxt) < 0)
                return true;

            var n = rcv_buf.Count - 1;
            var insert_idx = 0;
            var repeat = false;
            for (var i = n; i >= 0; i--)
            {
                var seg = rcv_buf[i];
                if (seg.sn == sn)
                {
                    repeat = true;
                    break;
                }

                if (KcpTool.Subtract(sn, seg.sn) > 0)
                {
                    insert_idx = i + 1;
                    break;
                }
            }

            if (!repeat)
            {
                if (insert_idx == n + 1)
                    rcv_buf.Add(newseg);
                else
                    rcv_buf.Insert(insert_idx, newseg);
            }

            // move available data from rcv_buf -> rcv_queue
            var count = 0;
            foreach (var seg in rcv_buf)
            {
                if (seg.sn == rcv_nxt && rcv_queue.Count + count < rcv_wnd)
                {
                    rcv_nxt++;
                    count++;
                }
                else
                {
                    break;
                }
            }

            if (count > 0)
            {
                for (var i = 0; i < count; i++)
                    rcv_queue.Add(rcv_buf[i]);
                rcv_buf.RemoveRange(0, count);
            }
            return repeat;
        }

        // Input when you received a low level packet (eg. UDP packet), call it
        // regular indicates a regular packet has received(not from FEC)
        // 
        // 'ackNoDelay' will trigger immediate ACK, but surely it will not be efficient in bandwidth
        public int Input(byte[] data, int offset, int size, bool regular, bool ackNoDelay)
        {
            var s_una = snd_una;
            if (size < KcpTool.IKCP_OVERHEAD) return -1;

            Int32 _offset = offset;
            uint latest = 0;
            int flag = 0;
            UInt64 inSegs = 0;

            while (true)
            {
                uint ts = 0;
                uint sn = 0;
                uint length = 0;
                uint una = 0;
                uint conv_ = 0;

                UInt16 wnd = 0;
                byte cmd = 0;
                byte frg = 0;

                if (size - (_offset - offset) < KcpTool.IKCP_OVERHEAD) break;

                _offset += KcpTool.Decode(data, _offset, ref conv_);

                if (conv != conv_) return -1;

                _offset += KcpTool.Decode(data, _offset, ref cmd);
                _offset += KcpTool.Decode(data, _offset, ref frg);
                _offset += KcpTool.Decode(data, _offset, ref wnd);
                _offset += KcpTool.Decode(data, _offset, ref ts);
                _offset += KcpTool.Decode(data, _offset, ref sn);
                _offset += KcpTool.Decode(data, _offset, ref una);
                _offset += KcpTool.Decode(data, _offset, ref length);

                if (size - (_offset - offset) < length) return -2;
                switch (cmd)
                {
                    case KcpTool.IKCP_CMD_PUSH:
                    case KcpTool.IKCP_CMD_ACK:
                    case KcpTool.IKCP_CMD_WASK:
                    case KcpTool.IKCP_CMD_WINS:
                        break;
                    default:
                        return -3;
                }

                // only trust window updates from regular packets. i.e: latest update
                if (regular) rmt_wnd = wnd;

                parse_una(una);
                shrink_buf();
                switch (cmd)
                {
                    case KcpTool.IKCP_CMD_PUSH:
                        var repeat = true;
                        if (KcpTool.Subtract(sn, rcv_nxt + rcv_wnd) < 0)
                        {
                            ack_push(sn, ts);
                            if (KcpTool.Subtract(sn, rcv_nxt) >= 0)
                            {
                                var seg = Segment.Get((int)length);
                                seg.conv = conv_;
                                seg.cmd = (uint)cmd;
                                seg.frg = (uint)frg;
                                seg.wnd = (uint)wnd;
                                seg.ts = ts;
                                seg.sn = sn;
                                seg.una = una;
                                seg.data.WriteBytes(data, _offset, (int)length);
                                repeat = parse_data(seg);
                            }
                        }
                        break;
                    case KcpTool.IKCP_CMD_ACK:
                        parse_ack(sn);
                        parse_fastack(sn, ts);
                        flag |= 1;
                        latest = ts;
                        break;
                    case KcpTool.IKCP_CMD_WASK:
                        probe |= KcpTool.IKCP_ASK_TELL;
                        break;
                    case KcpTool.IKCP_CMD_WINS:
                        break;
                    default:
                        return -3;
                }
                inSegs++;
                _offset += (int)length;
            }

            // update rtt with the latest ts
            // ignore the FEC packet
            if (flag != 0 && regular)
            {
                var current = time;
                if (KcpTool.Subtract(current, latest) >= 0)
                {
                    update_ack(KcpTool.Subtract(current, latest));
                }
            }

            // cwnd update when packet arrived
            if (!nocwnd)
            {
                if (KcpTool.Subtract(snd_una, s_una) > 0)
                {
                    if (cwnd < rmt_wnd)
                    {
                        var _mss = mss;
                        if (cwnd < ssthresh)
                        {
                            cwnd++;
                            incr += _mss;
                        }
                        else
                        {
                            if (incr < _mss)
                            {
                                incr = _mss;
                            }
                            incr += (_mss * _mss) / incr + (_mss) / 16;
                            if ((cwnd + 1) * _mss <= incr)
                            {
                                if (_mss > 0)
                                    cwnd = (incr + _mss - 1) / _mss;
                                else
                                    cwnd = incr + _mss - 1;
                            }
                        }
                        if (cwnd > rmt_wnd)
                        {
                            cwnd = rmt_wnd;
                            incr = rmt_wnd * _mss;
                        }
                    }
                }
            }

            // ack immediately
            if (ackNoDelay && acklist.Count > 0)
            {
                Flush(true);
            }

            return 0;
        }

        UInt16 wnd_unused()
        {
            if (rcv_queue.Count < rcv_wnd)
                return (UInt16)(rcv_wnd - rcv_queue.Count);
            return 0;
        }

        // flush pending data
        public uint Flush(bool ackOnly)
        {
            var seg = Segment.Get(32);
            seg.conv = conv;
            seg.cmd = KcpTool.IKCP_CMD_ACK;
            seg.wnd = (uint)wnd_unused();
            seg.una = rcv_nxt;

            var writeIndex = reserved;

            Action<int> makeSpace = (space) =>
            {
                if (writeIndex + space > mtu)
                {
                    _sender.Send(buffer, writeIndex);
                    writeIndex = reserved;
                }
            };

            Action flushBuffer = () =>
            {
                if (writeIndex > reserved)
                {
                    _sender.Send(buffer, writeIndex);
                }
            };

            // flush acknowledges
            for (var i = 0; i < acklist.Count; i++)
            {
                makeSpace(KcpTool.IKCP_OVERHEAD);
                var ack = acklist[i];
                if (KcpTool.Subtract(ack.sn, rcv_nxt) >= 0 || acklist.Count - 1 == i)
                {
                    seg.sn = ack.sn;
                    seg.ts = ack.ts;
                    writeIndex += seg.Encode(buffer, writeIndex);
                }
            }
            acklist.Clear();

            // flash remain ack segments
            if (ackOnly)
            {
                flushBuffer();
                return interval;
            }

            uint current = 0;
            // probe window size (if remote window size equals zero)
            if (0 == rmt_wnd)
            {
                current = time;
                if (0 == probe_wait)
                {
                    probe_wait = KcpTool.IKCP_PROBE_INIT;
                    ts_probe = current + probe_wait;
                }
                else
                {
                    if (KcpTool.Subtract(current, ts_probe) >= 0)
                    {
                        if (probe_wait < KcpTool.IKCP_PROBE_INIT)
                            probe_wait = KcpTool.IKCP_PROBE_INIT;
                        probe_wait += probe_wait / 2;
                        if (probe_wait > KcpTool.IKCP_PROBE_LIMIT)
                            probe_wait = KcpTool.IKCP_PROBE_LIMIT;
                        ts_probe = current + probe_wait;
                        probe |= KcpTool.IKCP_ASK_SEND;
                    }
                }
            }
            else
            {
                ts_probe = 0;
                probe_wait = 0;
            }

            // flush window probing commands
            if ((probe & KcpTool.IKCP_ASK_SEND) != 0)
            {
                seg.cmd = KcpTool.IKCP_CMD_WASK;
                makeSpace(KcpTool.IKCP_OVERHEAD);
                writeIndex += seg.Encode(buffer, writeIndex);
            }

            if ((probe & KcpTool.IKCP_ASK_TELL) != 0)
            {
                seg.cmd = KcpTool.IKCP_CMD_WINS;
                makeSpace(KcpTool.IKCP_OVERHEAD);
                writeIndex += seg.Encode(buffer, writeIndex);
            }

            probe = 0;

            // calculate window size
            var cwnd_ = KcpTool.Min(snd_wnd, rmt_wnd);
            if (!nocwnd)
                cwnd_ = KcpTool.Min(cwnd, cwnd_);

            // sliding window, controlled by snd_nxt && sna_una+cwnd
            var newSegsCount = 0;
            for (var k = 0; k < snd_queue.Count; k++)
            {
                if (KcpTool.Subtract(snd_nxt, snd_una + cwnd_) >= 0)
                    break;

                var newseg = snd_queue[k];
                newseg.conv = conv;
                newseg.cmd = KcpTool.IKCP_CMD_PUSH;
                newseg.sn = snd_nxt;
                snd_buf.Add(newseg);
                snd_nxt++;
                newSegsCount++;
            }

            if (newSegsCount > 0)
            {
                snd_queue.RemoveRange(0, newSegsCount);
            }

            // calculate resent
            var resent = (uint)fastresend;
            if (fastresend <= 0) resent = 0xffffffff;

            // check for retransmissions
            current = time;
            UInt64 change = 0; UInt64 lostSegs = 0; UInt64 fastRetransSegs = 0; UInt64 earlyRetransSegs = 0;
            var minrto = (Int32)interval;

            for (var k = 0; k < snd_buf.Count; k++)
            {
                var segment = snd_buf[k];
                var needsend = false;
                if (segment.acked == 1)
                    continue;
                if (segment.xmit == 0)  // initial transmit
                {
                    needsend = true;
                    segment.rto = rx_rto;
                    segment.resendts = current + segment.rto;
                }
                else if (segment.fastack >= resent) // fast retransmit
                {
                    needsend = true;
                    segment.fastack = 0;
                    segment.rto = rx_rto;
                    segment.resendts = current + segment.rto;
                    change++;
                    fastRetransSegs++;
                }
                else if (segment.fastack > 0 && newSegsCount == 0) // early retransmit
                {
                    needsend = true;
                    segment.fastack = 0;
                    segment.rto = rx_rto;
                    segment.resendts = current + segment.rto;
                    change++;
                    earlyRetransSegs++;
                }
                else if (KcpTool.Subtract(current, segment.resendts) >= 0) // RTO
                {
                    needsend = true;
                    if (nodelay == 0)
                        segment.rto += rx_rto;
                    else
                        segment.rto += rx_rto / 2;
                    segment.fastack = 0;
                    segment.resendts = current + segment.rto;
                    lostSegs++;
                }

                if (needsend)
                {
                    current = time;
                    segment.xmit++;
                    segment.ts = current;
                    segment.wnd = seg.wnd;
                    segment.una = seg.una;

                    var need = KcpTool.IKCP_OVERHEAD + segment.data.canRead;
                    makeSpace(need);
                    writeIndex += segment.Encode(buffer, writeIndex);
                    Buffer.BlockCopy(segment.data.buffer, segment.data.reader, buffer, writeIndex, segment.data.canRead);
                    writeIndex += segment.data.canRead;

                    if (segment.xmit >= dead_link)
                    {
                        state = 0xFFFFFFFF;
                    }
                }

                // get the nearest rto
                var _rto = KcpTool.Subtract(segment.resendts, current);
                if (_rto > 0 && _rto < minrto)
                {
                    minrto = _rto;
                }
            }

            // flash remain segments
            flushBuffer();

            // cwnd update
            if (!nocwnd )
            {
                // update ssthresh
                // rate halving, https://tools.ietf.org/html/rfc6937
                if (change > 0)
                {
                    var inflght = snd_nxt - snd_una;
                    ssthresh = inflght / 2;
                    if (ssthresh < KcpTool.IKCP_THRESH_MIN)
                        ssthresh = KcpTool.IKCP_THRESH_MIN;
                    cwnd = ssthresh + resent;
                    incr = cwnd * mss;
                }

                // congestion control, https://tools.ietf.org/html/rfc5681
                if (lostSegs > 0)
                {
                    ssthresh = cwnd / 2;
                    if (ssthresh < KcpTool.IKCP_THRESH_MIN)
                        ssthresh = KcpTool.IKCP_THRESH_MIN;
                    cwnd = 1;
                    incr = mss;
                }

                if (cwnd < 1)
                {
                    cwnd = 1;
                    incr = mss;
                }
            }

            return (uint)minrto;
        }

        // update state (call it repeatedly, every 10ms-100ms), or you can ask
        // ikcp_check when to call it again (without ikcp_input/_send calling).
        // 'current' - current timestamp in millisec.
        public void Update()
        {
            var current = time;

            if (0 == updated)
            {
                updated = 1;
                ts_flush = current;
            }

            var slap = KcpTool.Subtract(current, ts_flush);

            if (slap >= 10000 || slap < -10000)
            {
                ts_flush = current;
                slap = 0;
            }

            if (slap >= 0)
            {
                ts_flush += interval;
                if (KcpTool.Subtract(current, ts_flush) >= 0)
                    ts_flush = current + interval;
                Flush(false);
            }
        }

        // Determine when should you invoke ikcp_update:
        // returns when you should invoke ikcp_update in millisec, if there
        // is no ikcp_input/_send calling. you can call ikcp_update in that
        // time, instead of call update repeatly.
        // Important to reduce unnacessary ikcp_update invoking. use it to
        // schedule ikcp_update (eg. implementing an epoll-like mechanism,
        // or optimize ikcp_update when handling massive kcp connections)
        public uint Check()
        {
            var ts_flush_ = ts_flush;
            var tm_flush_ = 0x7fffffff;
            var tm_packet = 0x7fffffff;
            var minimal = 0;

            if (updated == 0)
                return time;

            if (KcpTool.Subtract(time, ts_flush_) >= 10000 || KcpTool.Subtract(time, ts_flush_) < -10000)
                ts_flush_ = time;

            if (KcpTool.Subtract(time, ts_flush_) >= 0)
                return time;

            tm_flush_ = (int)KcpTool.Subtract(ts_flush_, time);

            foreach (var seg in snd_buf)
            {
                var diff = KcpTool.Subtract(seg.resendts, time);
                if (diff <= 0)
                    return time;
                if (diff < tm_packet)
                    tm_packet = (int)diff;
            }

            minimal = (int)tm_packet;
            if (tm_packet >= tm_flush_)
                minimal = (int)tm_flush_;
            if (minimal >= interval)
                minimal = (int)interval;

            return time + (uint)minimal;
        }

        // change MTU size, default is 1024
        public int SetMtu(Int32 mtu_)
        {
            if (mtu_ < 50 || mtu_ < (Int32)KcpTool.IKCP_OVERHEAD)
                return -1;
            if (reserved >= (int)(mtu - KcpTool.IKCP_OVERHEAD) || reserved < 0)
                return -1;

            var buffer_ = new byte[mtu_];
            if (null == buffer_)
                return -2;

            mtu = (uint)mtu_;
            mss = mtu - KcpTool.IKCP_OVERHEAD - (uint)reserved;
            buffer = buffer_;
            return 0;
        }

        // normal:  0, 40, 2, true
        // fast:    0, 30, 2, true
        // fast2:   1, 20, 2, true
        // fast3:   1, 10, 2, true
        // fastest: ikcp_nodelay(kcp, 1, 20, 2, 1)
        // nodelay: 0:disable(default), 1:enable
        // interval: internal update timer interval in millisec, default is 100ms
        // resend: 0:disable fast resend(default), 1:enable fast resend
        // nc: 0:normal congestion control(default), 1:disable congestion control
        public int NoDelay(int nodelay_, int interval_, int resend_, bool nc_=false)
        {

            if (nodelay_ > 0)
            {
                nodelay = (uint)nodelay_;
                if (nodelay_ != 0)
                    rx_minrto = KcpTool.IKCP_RTO_NDL;
                else
                    rx_minrto = KcpTool.IKCP_RTO_MIN;
            }

            if (interval_ >= 0)
            {
                if (interval_ > 5000)
                    interval_ = 5000;
                else if (interval_ < 10)
                    interval_ = 10;
                interval = (uint)interval_;
            }

            if (resend_ >= 0)
                fastresend = resend_;

                nocwnd = nc_;

            return 0;
        }
        // set maximum window size: sndwnd=32, rcvwnd=32 by default
        public int SetWIndow(int sndwnd, int rcvwnd)
        {
            if (sndwnd > 0)
                snd_wnd = (uint)sndwnd;

            if (rcvwnd > 0)
                rcv_wnd = (uint)rcvwnd;
            return 0;
        }

        public bool ReserveBytes(int reservedSize)
        {
            if (reservedSize >= (mtu - KcpTool.IKCP_OVERHEAD) || reservedSize < 0)
                return false;

            reserved = reservedSize;
            mss = mtu - KcpTool.IKCP_OVERHEAD - (uint)(reservedSize);
            return true;
        }

    }
}
