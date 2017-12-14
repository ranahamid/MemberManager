using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using NLog;
namespace Services.MMSync
{
    public class MMSyncronize
    {
        private List<MMData> members = null;
        private List<string> wrongLines = null;
        public MMSyncronize()
        {
            wrongLines = new List<string>();
            members = new List<MMData>();
        }
        /// <summary>
        /// Do needed stepts to import/sync Memebers
        /// </summary>
        /// <returns></returns>
        public bool Process()
        {
            Console.WriteLine(DateTime.Now.Ticks);

            bool bc = StepReadCsvFile();
            Console.WriteLine(DateTime.Now.Ticks);

            bc = StepProcessMembers();
            Console.WriteLine(DateTime.Now.Ticks);
            return true;
        }

        public bool StepReadCsvFile()
        {
            char[] delimiters = new char[] { ';' };

            using (TextFieldParser parser = new TextFieldParser(@"d:\Projects\Jp\MM\LF_medlemmer_20171207_segmentering_version0.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                bool skip_header = true;
                while (!parser.EndOfData)
                {
                    /*//Process row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        //TODO: Process field
                    }*/
                    string line = parser.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (skip_header)
                    {
                        skip_header = false;
                        continue;
                    }
                    string[] parts = line.Split(delimiters);
                    //todo process....
                    Console.WriteLine(string.Format("[{0}, [{1}]", DateTime.Now.Ticks, parts[0]));
                    MMData user = CreateFromRow(parts);
                    if (user == null)
                    {
                        Console.WriteLine(string.Format("wrongLines [{0}]", string.Join("", parts)));
                        wrongLines.Add(string.Join("", parts));
                    }
                    else
                        members.Add(user);
                }
            }
            return true;
        }
        public bool StepProcessMembers()
        {
            DbCommands db = new DbCommands();
            foreach(MMData user in members)
            {
                db.InsertMember(user);
            }
            return true;
        }
        private MMData CreateFromRow(string[] row)
        {
            MMData user = new MMData();
            try {
                user.ExternalId = row[(int)MMEnums.ExternalId];
                user.Firstname = row[(int)MMEnums.Firstname];
                user.Lastname = row[(int)MMEnums.Lastname];
                user.Address = row[(int)MMEnums.Address];
                user.Address2 = row[(int)MMEnums.Address2];
                user.Postcode = row[(int)MMEnums.Postcode];
                user.City = row[(int)MMEnums.City];
                user.Country = row[(int)MMEnums.Country];
                user.Phone = row[(int)MMEnums.Phone];
                user.Mobile = row[(int)MMEnums.Mobile];
                user.Email = row[(int)MMEnums.Email];
                user.CVRnummer = row[(int)MMEnums.CVRnummer];
                user.BrugerID = row[(int)MMEnums.BrugerID];
                user.Medlemsstatus = row[(int)MMEnums.Medlemsstatus];
                user.Foreningsnummer = row[(int)MMEnums.Foreningsnummer];
                user.Foedselsaar = row[(int)MMEnums.Foedselsaar];
                user.HektarDrevet = row[(int)MMEnums.HektarDrevet];
                user.AntalAmmekoeer = row[(int)MMEnums.AntalAmmekoeer];
                user.AntalAndetKvaeg = row[(int)MMEnums.AntalAndetKvaeg];
                user.AntalSlagtekvaeg = row[(int)MMEnums.AntalSlagtekvaeg];
                user.AntaMalkekoeer = row[(int)MMEnums.AntaMalkekoeer];
                user.AntalSlagtesvin = row[(int)MMEnums.AntalSlagtesvin];
                user.AntalSoeer = row[(int)MMEnums.AntalSoeer];
                user.AntalAarssoeer = row[(int)MMEnums.AntalAarssoeer];
                user.AntalPelsdyr = row[(int)MMEnums.AntalPelsdyr];
                user.AntalHoens = row[(int)MMEnums.AntalHoens];
                user.AntalKyllinger = row[(int)MMEnums.AntalKyllinger];
                user.Økologi = row[(int)MMEnums.Økologi];
                user.Sektion_SSJ = row[(int)MMEnums.Sektion_SSJ];
                user.Driftform_planteavl = row[(int)MMEnums.Driftform_planteavl];
                user.Driftform_Koed_Koer = row[(int)MMEnums.Driftform_Koed_Koer];
                user.Driftform_Mælk = row[(int)MMEnums.Driftform_Mælk];
                user.Driftform_Svin = row[(int)MMEnums.Driftform_Svin];
                user.Driftform_Pelsdyr = row[(int)MMEnums.Driftform_Pelsdyr];
                user.Driftform_Aeg_Kylling = row[(int)MMEnums.Driftform_Aeg_Kylling];
                user.Driftstoerrelse_Planteavl = row[(int)MMEnums.Driftstoerrelse_Planteavl];
                user.Driftstoerrelse_Koed_Koer = row[(int)MMEnums.Driftstoerrelse_Koed_Koer];
                user.Driftfstoerrelse_Mælk = row[(int)MMEnums.Driftfstoerrelse_Mælk];
                user.Driftstoerrelse_Svin = row[(int)MMEnums.Driftstoerrelse_Svin];
                user.Driftstoerrelse_Pelsdyr = row[(int)MMEnums.Driftstoerrelse_Pelsdyr];
                user.Driftstoerrelse_Aeg_Kylling = row[(int)MMEnums.Driftstoerrelse_Aeg_Kylling];
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("CreateFromRow {0}", ex.Message));
            }
            return user;
        }
    }
}
