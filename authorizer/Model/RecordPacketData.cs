using irbis64helper.Converter;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Model
{
    class RecordPacketData : ResponsePacketData
    {
        private Record _record;
        private Record GetRecord()
        {
            if (_record == null)
            {
                //_record = RecordCreator.GetRecord(this);
            }
            return _record;
        }
    }
}
