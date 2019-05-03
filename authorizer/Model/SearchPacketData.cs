using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Model
{
    internal class SearchPacketData : ResponsePacketData
    {
        internal String Contain { get => Rows[1]; }
        private String _mfn = null;
        internal String GetMfn()
        {
            if(_mfn == null)
            {
                _mfn = ( Rows[2].Split('#') )[0];
            }
            return _mfn;
        }
    }
}
