using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAL;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.BLL
{
    public class CenterManager
    {
	private CenterGateway aCenterGateway = new CenterGateway();
        public void Save(Center aCenter)
        {
            aCenterGateway.Save(aCenter);
        }
        public Center Find(Center aCenter)
        {
            return aCenterGateway.Find(aCenter);
        }      
	public string GenerateRandomNumber(int maxSize)
        {
            char[] chars = new char[62];
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        public void SaveCenterCodeAndPassword(int centerId, string code, string password)
        {
            aCenterGateway.SaveCenterCodeAndPassword(centerId, code, password);
        }
    }
}
