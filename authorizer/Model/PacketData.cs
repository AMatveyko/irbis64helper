using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace irbis64helper.Model
{
    internal class PacketData
    {
        internal List<string> Rows { get; set; }
        internal PacketData()
        {
            Rows = new List<string>();
        }
        internal PacketData(String data)
        {
            String[] splitedData = data.Split('\n');
            Rows = splitedData.ToList();
        }
        public override string ToString()
        {
            string dataToStr = String.Empty;
            foreach (var row in Rows)
                dataToStr += row + '\n';
            return dataToStr.TrimEnd('\n');
        }
    }
}
