using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SweeftAccelerationConsole
{
    public class AppFunc
    {

        // -------------------------------------------------------------------- IS PALINDROME FUNCTION -------------------------------------------------///////////
        // This function is case sensitive
        // We could change that by getting string into uppercase or lowercase 
        public bool isPalindrome(string txt)
        {
            // Text should not be null nor empty 
            if (txt == null || txt.Length == 0) return false;

            // For even length
            if(txt.Length % 2 == 0)
            {
                return txt.Substring(0, txt.Length / 2) == ExternalFunctions.ReverseString(txt.Substring(txt.Length / 2 ));
            }
            // For odd length
            else
            {
                return txt.Substring(0, (txt.Length - 1) / 2) == ExternalFunctions.ReverseString(txt.Substring((txt.Length + 1) / 2));
            }

        }

        // -------------------------------------------------------------------- MIN SPLIT FUNCTION -----------------------------------------------------///////////
        // Takes amount in cents 
        // Could improve*
        public int minSplit(int amountCents)
        {
            int coinRet = 0;
            int ReminderAmt = amountCents;
            int[] coinArray = { 50, 20, 10, 5, 1 };
            int i = 0;

            while (true)
            {
                coinRet += (ReminderAmt / coinArray[i]);
                ReminderAmt = (amountCents % coinArray[i]);
                i++;
                if (i == coinArray.Length)
                    break;
            }

            return coinRet;
        }

        // ------------------------------------------------------------- DOES NOT CONTAIN FUNCTION -----------------------------------------------------///////////

        public int notContains(int[] intArray)
        {
            int i = 0;

            while (true)
            {
                i++;
                var a = from x in intArray
                        where x == i
                        select (int)x;
                if (a.Count() == 0)
                    break;
            }
            return i;
        }

        // ------------------------------------------------------------- IS PROPERLY FUNCTION -----------------------------------------------------------///////////

        public bool isProperly(string str)
        {
            string strOp = str;
            while (true)
            {
                int openFirstPosition, closeFirstPosition;
                openFirstPosition = Strings.InStr(strOp, "(");
                closeFirstPosition = Strings.InStr(strOp, ")");
                if (openFirstPosition != 0)
                {
                    if (closeFirstPosition > openFirstPosition)
                    {
                        strOp = ExternalFunctions.RemoveCharacterFirstOccurrence(strOp, "(");
                        strOp = ExternalFunctions.RemoveCharacterFirstOccurrence(strOp, ")");
                    }
                    else
                        return false;
                }
                else
                {
                    if (closeFirstPosition != 0)
                        return false;
                    else
                        return true;
                }
            }
        }


    }

    public static class ExternalFunctions
    {
        public static string ReverseString(string st)
        {
            char[] charArray = st.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        
        public static string RemoveCharacterFirstOccurrence(string str, string characterToRemvoe)
        {
            return str.Substring(0, Strings.InStr(str, characterToRemvoe) - 1) + str.Substring(Strings.InStr(str, characterToRemvoe));
        }
    
    
    }
    

   
}
