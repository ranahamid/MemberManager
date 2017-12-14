using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MMSync
{
    public class DbCommands
    {
        public int InsertMember(MMData user)
        {
            Int32 id = 0;
            string insertSQL = @"INSERT INTO [Profiles] (
									 [ExternalId],
									 [Firstname],
									 [Lastname],
									 [Address],
									 [Address2],
									 [Postcode],
									 [City],
									 [Country],
									 [Phone],
									 [Mobile],
									 [Email],
									 [CVRnummer],
									 [BrugerID],
									 [Medlemsstatus],
									 [Foreningsnummer],
									 [Foedselsaar],
									 [HektarDrevet],
									 [AntalAmmekoeer],
									 [AntalAndetKvaeg],
									 [AntalSlagtekvaeg],
									 [AntaMalkekoeer],
									 [AntalSlagtesvin],
									 [AntalSoeer],
									 [AntalAarssoeer],
									 [AntalPelsdyr],
									 [AntalHoens],
									 [AntalKyllinger],
									 [Ecology],
									 [Sektion_SSJ],
									 [Driftform_planteavl],
									 [Driftform_Koed_Koer],
									 [Driftform_Mælk],
									 [Driftform_Svin],
									 [Driftform_Pelsdyr],
									 [Driftform_Aeg_Kylling],
									 [Driftstoerrelse_Planteavl],
									 [Driftstoerrelse_Koed_Koer],
									 [Driftfstoerrelse_Mælk],
									 [Driftstoerrelse_Svin],
									 [Driftstoerrelse_Pelsdyr],
                                     [Driftstoerrelse_Aeg_Kylling]   )
								 VALUES (
									 @ExternalId,
									 @Firstname,
									 @Lastname,
									 @Address,
									 @Address2,
									 @Postcode,
									 @City,
									 @Country,
									 @Phone,
									 @Mobile,
									 @Email,
									 @CVRnummer,
									 @BrugerID,
									 @Medlemsstatus,
									 @Foreningsnummer,
									 @Foedselsaar,
									 @HektarDrevet,
									 @AntalAmmekoeer,
									 @AntalAndetKvaeg,
									 @AntalSlagtekvaeg,
									 @AntaMalkekoeer,
									 @AntalSlagtesvin,
									 @AntalSoeer,
									 @AntalAarssoeer,
									 @AntalPelsdyr,
									 @AntalHoens,
									 @AntalKyllinger,
									 @Ecology,
									 @Sektion_SSJ,
									 @Driftform_planteavl,
									 @Driftform_Koed_Koer,
									 @Driftform_Mælk,
									 @Driftform_Svin,
									 @Driftform_Pelsdyr,
									 @Driftform_Aeg_Kylling,
									 @Driftstoerrelse_Planteavl,
									 @Driftstoerrelse_Koed_Koer,
									 @Driftfstoerrelse_Mælk,
									 @Driftstoerrelse_Svin,
									 @Driftstoerrelse_Pelsdyr,
                                     @Driftstoerrelse_Aeg_Kylling    );
								 SELECT CAST(scope_identity() AS int)";

            using (SqlConnection conn = DbHelper.CreateAndOpenConnection())
            using (SqlCommand insert = new SqlCommand(insertSQL, conn))
            {
                insert.Parameters.Add("@ExternalId", SqlDbType.VarChar, 50).Value = user.ExternalId;
                insert.Parameters.Add("@Firstname", SqlDbType.VarChar, 50).Value = user.Firstname;
                insert.Parameters.Add("@Lastname", SqlDbType.VarChar, 50).Value = user.Lastname;
                insert.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = user.Address;
                insert.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = user.Address2;
                insert.Parameters.Add("@Postcode", SqlDbType.VarChar, 50).Value = user.Postcode;
                insert.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = user.City;
                insert.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = user.Country;
                insert.Parameters.Add("@Phone", SqlDbType.VarChar, 50).Value = user.Phone;
                insert.Parameters.Add("@Mobile", SqlDbType.VarChar, 50).Value = user.Mobile;
                insert.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = user.Email;
                insert.Parameters.Add("@CVRnummer", SqlDbType.VarChar, 50).Value = user.CVRnummer;
                insert.Parameters.Add("@BrugerID", SqlDbType.VarChar, 50).Value = user.BrugerID;
                insert.Parameters.Add("@Medlemsstatus", SqlDbType.VarChar, 50).Value = user.Medlemsstatus;
                insert.Parameters.Add("@Foreningsnummer", SqlDbType.VarChar, 50).Value = user.Foreningsnummer;
                insert.Parameters.Add("@Foedselsaar", SqlDbType.VarChar, 50).Value = user.Foedselsaar;
                insert.Parameters.Add("@HektarDrevet", SqlDbType.VarChar, 50).Value = user.HektarDrevet;
                insert.Parameters.Add("@AntalAmmekoeer", SqlDbType.VarChar, 50).Value = user.AntalAmmekoeer;
                insert.Parameters.Add("@AntalAndetKvaeg", SqlDbType.VarChar, 50).Value = user.AntalAndetKvaeg;
                insert.Parameters.Add("@AntalSlagtekvaeg", SqlDbType.VarChar, 50).Value = user.AntalSlagtekvaeg;
                insert.Parameters.Add("@AntaMalkekoeer", SqlDbType.VarChar, 50).Value = user.AntaMalkekoeer;
                insert.Parameters.Add("@AntalSlagtesvin", SqlDbType.VarChar, 50).Value = user.AntalSlagtesvin;
                insert.Parameters.Add("@AntalSoeer", SqlDbType.VarChar, 50).Value = user.AntalSoeer;
                insert.Parameters.Add("@AntalAarssoeer", SqlDbType.VarChar, 50).Value = user.AntalAarssoeer;
                insert.Parameters.Add("@AntalPelsdyr", SqlDbType.VarChar, 50).Value = user.AntalPelsdyr;
                insert.Parameters.Add("@AntalHoens", SqlDbType.VarChar, 50).Value = user.AntalHoens;
                insert.Parameters.Add("@AntalKyllinger", SqlDbType.VarChar, 50).Value = user.AntalKyllinger;
                insert.Parameters.Add("@Ecology", SqlDbType.VarChar, 50).Value = user.Økologi;
                insert.Parameters.Add("@Sektion_SSJ", SqlDbType.VarChar, 50).Value = user.Sektion_SSJ;
                insert.Parameters.Add("@Driftform_planteavl", SqlDbType.VarChar, 50).Value = user.Driftform_planteavl;
                insert.Parameters.Add("@Driftform_Koed_Koer", SqlDbType.VarChar, 50).Value = user.Driftform_Koed_Koer;
                insert.Parameters.Add("@Driftform_Mælk", SqlDbType.VarChar, 50).Value = user.Driftform_Mælk;
                insert.Parameters.Add("@Driftform_Svin", SqlDbType.VarChar, 50).Value = user.Driftform_Svin;
                insert.Parameters.Add("@Driftform_Pelsdyr", SqlDbType.VarChar, 50).Value = user.Driftform_Pelsdyr;
                insert.Parameters.Add("@Driftform_Aeg_Kylling", SqlDbType.VarChar, 50).Value = user.Driftform_Aeg_Kylling;
                insert.Parameters.Add("@Driftstoerrelse_Planteavl", SqlDbType.VarChar, 50).Value = user.Driftstoerrelse_Planteavl;
                insert.Parameters.Add("@Driftstoerrelse_Koed_Koer", SqlDbType.VarChar, 50).Value = user.Driftstoerrelse_Koed_Koer;
                insert.Parameters.Add("@Driftfstoerrelse_Mælk", SqlDbType.VarChar, 50).Value = user.Driftfstoerrelse_Mælk;
                insert.Parameters.Add("@Driftstoerrelse_Svin", SqlDbType.VarChar, 50).Value = user.Driftstoerrelse_Svin;
                insert.Parameters.Add("@Driftstoerrelse_Pelsdyr", SqlDbType.VarChar, 50).Value = user.Driftstoerrelse_Pelsdyr;
                insert.Parameters.Add("@Driftstoerrelse_Aeg_Kylling", SqlDbType.VarChar, 50).Value = user.Driftstoerrelse_Aeg_Kylling;

                id = (Int32)insert.ExecuteScalar();
            }
            return (int)id;
        }
    }
}
