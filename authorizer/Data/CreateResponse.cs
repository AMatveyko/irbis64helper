using irbis64helper.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace irbis64helper.Data
{
    internal static class CreateResponse
    {
        internal static Response GetResponse(String respRaw)
        {
            String[] splitedResponse = respRaw.Split('\n');
            for (int i = 0; i < splitedResponse.Length; i++)
                splitedResponse[i] = splitedResponse[i].TrimEnd('\r');
            Response response = new Response();
            response.Command = splitedResponse[0];
            response.Seq = splitedResponse[1];
            response.Guid = splitedResponse[2];
            response.ReservStr4 = splitedResponse[3];
            response.ReservStr5 = splitedResponse[4];
            response.ReservStr6 = splitedResponse[5];
            response.ReservStr7 = splitedResponse[6];
            response.ReservStr8 = splitedResponse[7];
            response.ReservStr9 = splitedResponse[8];
            response.ReservStr10 = splitedResponse[9];
            switch(response.Command)
            {
                case "K":
                    response.Data = new SearchPacketData();
                    break;
                case "C":
                    response.Data = new RecordPacketData();
                    break;
                default:
                    response.Data = new ResponsePacketData();
                    break;
            }
            if (response.Command == "C")
            {
                String separatorStr = Encoding.UTF8.GetString(new byte[] { 31, 30 });
                response.Data.Rows.Add(splitedResponse[10]); //error code
                response.Data.Rows.Add($"{splitedResponse[11]}0"); //mfn#status
                for (int i = 12; i < splitedResponse.Length - 1; i++)
                {
                    response.Data.Rows[1] += separatorStr + splitedResponse[i];
                }
            }
            else
            {
                for (int i = 10; i < splitedResponse.Length; i++)
                {
                    response.Data.Rows.Add(splitedResponse[i]);
                }
            }
            return response;
        }
    }
}
