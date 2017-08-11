using System;
using System.Data;

namespace LoaderConfig
{
    public partial class IBFlexQueryConfigs
    {

        public string IBGetRequestCodeURL { get; set; }
        public string IBGetStatementURL { get; set; }
        public string IBToken { get; set; }
        public string IBQueryID { get; set; }
        public string IBStatementType { get; set; }
        public string IBStatementSaveName { get; set; }
        public string IBStatementSavePath { get; set; }
        public string IBResultCode { get; set; }
        public int IBStatementWait { get; set; }
    }

}
