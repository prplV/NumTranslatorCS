using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NumTranslatorCS
{
  internal class numTranslator
  {
    // 0-9
    private Dictionary<int, string> digits;
    // 10, 20, 30 ...
    private Dictionary<int, string> numbers;
    // 11-19
    private Dictionary<int, string> excepts;
    // special word
    private string specialWords;
    // 100
    private string hundred;
    // string of splitted numbers
    private string[] numbersSplitted;
    // output numbers (to sum)
    private List<int> finalNumber;
    // working Form
    private Form thisForm;
    // status List to check find results
    List<char> statusList;

    public numTranslator(string userQuery, Form thisForm)
    {
      // set a memmory to 0-9 dict with digits and adding needed info
      digits = new Dictionary<int, string>();
      digits.Add(1, "ein");
      digits.Add(2, "zwei");
      digits.Add(3, "drei");
      digits.Add(4, "vier");
      digits.Add(5, "fünf");
      digits.Add(6, "sechs");
      digits.Add(7, "sieben");
      digits.Add(8, "acht");
      digits.Add(9, "neun");
      digits.Add(0, "null");

      // set a memmory to 10, 20, 30 ... dict with digits and adding needed info
      numbers = new Dictionary<int, string>();
      numbers.Add(10, "zehn");
      numbers.Add(20, "zwanzig");
      numbers.Add(30, "dreißig");
      numbers.Add(40, "vierzig");
      numbers.Add(50, "fünfzig");
      numbers.Add(60, "sechzig");
      numbers.Add(70, "siebzig");
      numbers.Add(80, "achtzig");
      numbers.Add(90, "neunzig");

      // set a memmory to 11-19 dict with digits and adding needed info
      excepts = new Dictionary<int, string>();
      excepts.Add(11, "elf");
      excepts.Add(12, "zwölf");
      excepts.Add(13, "dreizehn");
      excepts.Add(14, "vierzehn");
      excepts.Add(15, "fünfzehn");
      excepts.Add(16, "sechzehn");
      excepts.Add(17, "siebzehn");
      excepts.Add(18, "achtzehn");
      excepts.Add(19, "neunzehn");

      // set a values to variables for '100' and special word
      specialWords = "und";
      hundred = "hundert";

      // split all words
      numbersSplitted = userQuery.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

      // set a memmory to final sum numbers List
      finalNumber = new List<int>();

      // setting up a Form clone inside the class
      this.thisForm = thisForm;

      // statusList
      statusList = new List<char>();

      // algorithm start
      checkLength();
    }
    private void checkLength()
    {
      if (numbersSplitted.Length == 1)
      {
          int res = globalFind(numbersSplitted[0]);
          if (res == -1)
          {
            errorHandler.errorSyntax(numbersSplitted[0]);
            return;
          }
          else if (statusList[0] == 's')
        {
          errorHandler.errorSyntaxOrder(numbersSplitted[0]);
          return;
        }
          else{
            finalNumber.Add(res);
          }
      }
      else if (numbersSplitted.Length == 2)
      {
        foreach (string temp in numbersSplitted)
        {
          int res = globalFind(temp);
          if (res == -1)
          {
            errorHandler.errorSyntax(temp);
            return;
          }
          else
          {
            finalNumber.Add(res);
          }
        }
      }
      else if (numbersSplitted.Length == 3)
      {
        foreach (string temp in numbersSplitted)
        {
          int res = globalFind(temp);
          if (res == -1)
          {
            errorHandler.errorSyntax(temp);
            return;
          }
          else
          {
            finalNumber.Add(res);
          }
        }
      }
      
      else if (numbersSplitted.Length == 4)
      {
        foreach (string temp in numbersSplitted)
        {
          int res = globalFind(temp);
          if (res == -1)
          {
            errorHandler.errorSyntax(temp);
            return;
          }
          else
          {
            finalNumber.Add(res);
          }
        }
      }

      else if (numbersSplitted.Length == 5)
      {
        foreach (string temp in numbersSplitted)
        {
          int res = globalFind(temp);
          if (res == -1)
          {
            errorHandler.errorSyntax(temp);
            return;
          }
          else
          {
            finalNumber.Add(res);
          }
        }
      }
      else
      {
        errorHandler.errorGlobalTransLen();
        return;
      }

      if (finalNumber.Count != statusList.Count)
      {
        errorHandler.errorGlobalListLens();
        return;
      }

      //VERIFICATION 

      int tempIndex = 0;
      foreach (char wit in statusList)
      {
        ++tempIndex;
        if (statusList.Count == tempIndex)
        {
          if (!Verification(wit))
          {
            return;
          }
        }
        else
        {
          if (!Verification(wit, statusList[tempIndex], numbersSplitted[tempIndex-1], numbersSplitted[tempIndex]))
          {
            return;
          }
        }
      }

      //VERIFICATION



        // out of a class
      int output = 0;
      if ((finalNumber.Count >= 2) && (numbersSplitted[1] == hundred))
      {
        for (int i = 0; i < finalNumber.Count; i++)
        {
          if (i == 1)
          {
            output *= finalNumber[i];
          }
          else
          {
            output += finalNumber[i];
          }
        }
      } else
      {
        foreach (int num in finalNumber)
        {
          output += num;
        }
      }
      mainForm.getOutput(output);
    }

    private int globalFind(string witness)
    {
      if (witness == hundred)
      {
        statusList.Add('h');
        return 100;
      }
      if (witness == specialWords)
      {
        statusList.Add('s');
        return 0;
      }

      int res = findDigit(witness);
      if (res == -1)
      {
        res = findElevenType(witness);
        if (res == -1)
        {
          res = findNumber(witness);
          if (res == -1)
          {
            //errorHandler.errorSyntax(witness);
            return -1;
          }
          else
          {
            return res;
          } 
        }
        else {
          return res;
        }
      }
      else
      {
        return res;
      }
    }
    private int findDigit(string digit)
    {
      foreach (KeyValuePair<int, string> en in digits)
      {
        if (en.Value == digit)
        {
          statusList.Add('d');
          return en.Key;
        }
      }
      return -1;
    }
    private int findNumber(string number)
    {
      foreach (KeyValuePair<int, string> en in numbers)
      {
        if (en.Value == number)
        {
          statusList.Add('n');
          return en.Key;
        }
      }
      return -1;
    }
    private int findElevenType(string eleventype)
    {
      foreach (KeyValuePair<int, string> en in excepts)
      {
        if (en.Value == eleventype)
        {
          statusList.Add('e');
          return en.Key;
        }
      }
      return -1;
    }
    private bool Verification(char witness)
    {
      if ((witness == 'd') || (witness == 'n') || (witness == 'h') || (witness == 'e'))
      {
        return true;
      }
      errorHandler.customError("Число не может оканчиваться словом und");
      return false;
    }
    private bool Verification(char witness, char nextWitness, string first, string second)
    {
      if (witness == 'd')
      {
        if ((nextWitness != 'h') && (nextWitness != 's'))
        {
          errorHandler.MatchingTypesError_After(witness, nextWitness, first, second);
          return false;
        }
        return true;
      }
      else if (witness == 'h')
      {
        if ((nextWitness != 'd') && (nextWitness != 'e')) // && (nextWitness != 's'))
        {
          errorHandler.MatchingTypesError_After(witness, nextWitness, first, second);
          return false;
        }
        return true;
      }
      else if (witness == 's')
      {
        if (nextWitness != 'n')
        {
          errorHandler.MatchingTypesError_After(witness, nextWitness, first, second);
          return false;
        }
        return true;
      }
      else
      {
        errorHandler.MatchingTypesError_After(witness, nextWitness, first, second);
        return false;
      }
    }
  }
}
