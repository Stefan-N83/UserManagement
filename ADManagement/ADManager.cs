/*
 * 
 * Quelle: https://www.codeproject.com/Articles/18102/Howto-Almost-Everything-In-Active-Directory-via-C
 * 
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace ADManagement
{
    [SupportedOSPlatform("windows")]
    public static class ADManager
    {
        /// <summary>
        /// Rename an object and specify the domain controller and credentials directly
        /// </summary>
        /// <param name="server"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="objectDn"></param>
        /// <param name="newName"></param>
        public static void Rename(string server,
            string userName, string password, string objectDn, string newName)
        {
            DirectoryEntry child = new("LDAP://" + server + "/" +
                objectDn, userName, password);
            child.Rename("CN=" + newName);
        }
        
        /// <summary>
        /// Translate the Friendly Domain Name to Fully Qualified Domain
        /// </summary>
        /// <param name="friendlyDomainName"></param>
        /// <returns></returns>
        public static string FriendlyDomainToLdapDomain(string friendlyDomainName)
        {
            string? ldapPath = null;
            try
            {
                DirectoryContext objContext = new DirectoryContext(
                    DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.Name;
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }
            return ldapPath;
        }


    }
}
