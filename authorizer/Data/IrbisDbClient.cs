using irbis64helper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace irbis64helper.Data
{
    public class IrbisDbClient : IDbClient
    {
        private const String _guid = "388456";
        private const String _arm = "C";
        private Int32 _seq = 0;
        private String Seq { get => (++_seq).ToString(); }
        private Boolean _debug = false;
        private Boolean _authorized = false;
        public bool Authorized
        {
            get => _authorized;
            private set => _authorized = value;
        }
        private DbInfo _dbInfo;
        private DbFieldsInfo _dbFieldsInfo;
        private Connection _connection;
        public IrbisDbClient(DbConnectionInfo dbConnectionInfo, DbFieldsInfo dbFieldsInfo, bool debug = false)
        {
            _debug = debug;
            _dbInfo = dbConnectionInfo.DbInfo;
            _connection = new Connection(dbConnectionInfo.ConnectionInfo, _debug);
            _dbFieldsInfo = dbFieldsInfo;
        }
        public Response FindReader(String idRdr)
        {
            return FindReader(idRdr, "");
        }
        public Response FindReader(String idRdr, String pwdRdr)
        {
            //String packet = $"K\n{_arm}\nK\n{_id}\n{Seq}\n\n\n\n\n\n{_dbName}\n\"A=$\"\n1000\n1\n@brief\n\n\n!if ((v{_dbFn}='{idRdr}')*(v{_dbFp}='{pwdRdr}')) then '1' else '0' fi";
            String db = _dbInfo.DbName;
            String dbNf = _dbFieldsInfo.UNameField;
            String dbPf = _dbFieldsInfo.UPassField;
            String searchById = $"{db}\n\"A=$\"\n1000\n1\n@brief\n\n\n!if (v{dbNf}='{idRdr}') then '1' else '0' fi";
            String searchByIdAndPwd = $"{db}\n\"A=$\"\n1000\n1\n@brief\n\n\n!if ((v{dbNf}='{idRdr}')*(v{dbPf}='{pwdRdr}')) then '1' else '0' fi";
            PacketData packetData;
            if (pwdRdr == "")
                packetData = new PacketData(searchById);
            else
                packetData = new PacketData(searchByIdAndPwd);
            Request request = CreateRequest.Search(_arm, _guid, Seq, packetData);
            return _connection.SendRequestAndGetResponse(request);
        }
        public IList<string> GetLockRecords()
        {
            throw new NotImplementedException();
        }

        public Response Login()
        {
            //A\n{_arm}\nA\n{_id}\n{Seq}\n\n\n\n\n\n{_dbLogin}\n{_dbPasswd}
            String irbisLogin = _dbInfo.UserName;
            String irbisPassw = _dbInfo.Password;
            PacketData packetData = new PacketData($"{irbisLogin}\n{irbisPassw}");
            Request request = CreateRequest.Login(_arm, _guid, Seq, packetData);
            return _connection.SendRequestAndGetResponse(request);
        }

        public Response ReadRecord(String mfn)
        {
            String db = _dbInfo.DbName;
            String lockRecord = "1";
            PacketData packetData = new PacketData($"{db}\n{mfn}\n{lockRecord}");
            Request request = CreateRequest.ReadRecord(_arm, _guid, Seq, packetData);
            return _connection.SendRequestAndGetResponse(request);
        }

        public Response WriteRecord(String mfn, String record)
        {
            //$"D\n{_arm}\nD\n{_id}\n{Seq}\n\n\n\n\n\n{_dbName}\n{lockRec}\n{ifUpdate}\n{mfnRdr}#0{separatorStr}";
            String db = _dbInfo.DbName;
            String lockRecord = "0";
            String ifUpdate = "1";
            PacketData packetData = new PacketData($"{db}\n{lockRecord}\n{ifUpdate}\n{record}");
            Request request = CreateRequest.WriteRecord(_arm, _guid, Seq, packetData);
            return _connection.SendRequestAndGetResponse(request); ;
        }
        public Response UnlockRecord(String mfn)
        {
            return null;
        }
    }
}
