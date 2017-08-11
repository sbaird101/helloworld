using System;
namespace Main
{
    public class deprecated
    {
        public deprecated()
        {

			class DeadClass
		{

			static void Dead(string[] args)
			{
				string MasterConnectString = ConfigurationManager.AppSettings["master_connect_string"];
				string firstStepURL = "";
				string ibToken = "";
				string ibQueryID = "";
				string ibStatementCode = "";
				string ibBaseURL = "";
				string ibStatementURL = "";
				string statementStorePath = "";
				string statementStoreName = "";
				int numIBQueries = 0;

				SqlConnection masterConnection = new SqlConnection(MasterConnectString);

				masterConnection.Open();
				SqlDataReader rdr = null;
				SqlCommand cmd = new SqlCommand("SELECT ib_base_url, ib_statement_url, ib_query_name, ib_token, ib_queryid, file_save_path FROM BrokerConnectors WHERE connection_type = 'IBFlexAPI' AND status = 1", masterConnection);

				rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					ibBaseURL = rdr[0] + "";
					ibToken = rdr[3] + "";
					ibQueryID = rdr[4] + "";
					ibStatementURL = rdr[1] + "";
					statementStorePath = rdr[5] + "";
					statementStoreName = rdr[2] + "";
				}

				if (rdr != null)
				{
					rdr.Close();
				}

				// 5. Close the connection
				if (masterConnection != null)
				{
					masterConnection.Close();
				}

				//string myDataConnectString = myResult.DbConnect(MasterConnectString);

				// Get values from app.config
				//string firstStepURL = ConfigurationManager.AppSettings["base_url"] + ConfigurationManager.AppSettings["token"] + ConfigurationManager.AppSettings["query_id"];
				//string queryResultCode = "";
				//string statementPath = ConfigurationManager.AppSettings["statementStore"];
				//string statementName = "FirstTest" + ".xml";

				// uncomment next line for debugging
				//Console.WriteLine(firstStepURL);

				// Open first URL to get the response code needed
				// to build flex statement url.
				XmlDocument resultDoc = new XmlDocument();
				resultDoc.Load(ibBaseURL + "t=" + ibToken + "&q=" + ibQueryID);

				// Find the "code" element in the resulting xml
				// and grab it out to build the statment url.
				XmlNodeList resultNodes = resultDoc.GetElementsByTagName("code");

				// Just for shits-n-giggles, make sure it's not empty
				// before we try to get the value.
				if (resultNodes != null)
				{
					// uncomment next line for debugging
					//Console.WriteLine(resultNodes.Item(0).InnerText);
					ibStatementCode = resultNodes.Item(0).InnerText;
				}


				//string statementURL = ConfigurationManager.AppSettings["statement_url"] + ConfigurationManager.AppSettings["code_prefix"] + ibStatementCode
				//+ "&" + ConfigurationManager.AppSettings["token"] + ConfigurationManager.AppSettings["api_version"];
				// uncomment next line for debugging
				//Console.WriteLine(statementURL);

				System.Threading.Thread.Sleep(10000);
				XmlDocument statementReturn = new XmlDocument();
				statementReturn.Load(ibStatementURL + "q=" + ibStatementCode + "&t=" + ibToken);



				// some stuff here about getting the query name, and "date"

				statementReturn.Save(statementStorePath + statementStoreName + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xml");


			}
		}

	}
        }
    }
}
