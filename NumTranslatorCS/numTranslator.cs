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
      //1 10 11 100
      if (numbersSplitted.Length == 1)
      {
          int res = globalFind(numbersSplitted[0]);
          if (res == -1)
          {
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
      // 2.00 3.00 ...
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
          // verification
          /*if (statusList[0] == 'd')
          {
            if (statusList[1] != 'h')
            {
              errorHandler.errorSyntaxOrder($"единиц ({numbersSplitted[0]})", numbersSplitted[1]);
              return;
            }
          } else if (statusList[0] == 'h')
          {
            if (statusList[1] == 'd')
            {
              if ((numbersSplitted[1] != "ein") && (numbersSplitted[1] != "zwei"))
              {
                errorHandler.errorSyntaxOrder($"{numbersSplitted[0]}", $"Единица {numbersSplitted[1]}");
                return;
              }
            }
            else
            {
              errorHandler.errorSyntaxOrder($"{numbersSplitted[0]}", numbersSplitted[1]);
              return;
            }
          }*/
      }
      // 2.1 2.11 2.0.1
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

        // verification
        /*if (statusList[0] != 'd')
        {
          errorHandler.errorSyntaxOrderMessage($"Трехсоставное слово не может начинаться с {numbersSplitted[0]}");
          return;
        }
        else
        {
          if ((statusList[1] != 's')&&(statusList[1] != 'h'))
          {
            if ((statusList[1] != 's')&&(statusList[2] == 'n'))
            {
              errorHandler.errorSyntaxOrder($"десятками ({numbersSplitted[2]})", $"{numbersSplitted[1]}", 1);
              return;
            } else if ((statusList[1] != 'h'))
            {
              errorHandler.errorSyntaxOrder($"единиц ({numbersSplitted[0]})", numbersSplitted[1]);
              return;
            }
            //errorHandler.errorSyntaxOrder(numbersSplitted[1], "hundert или und", 1);
            //return;
          }
          else
          {
            if (statusList[1] == 's')
            {
              if (statusList[2] != 'n')
              {
                errorHandler.errorSyntaxOrder($"специального слова ({numbersSplitted[1]})", numbersSplitted[2]);
                return;
              }
            } else if (statusList[1] == 'h')
            {
              if ((statusList[2] != 'd') && (statusList[2] != 'e') && (statusList[2] != 'n'))
              {
                errorHandler.errorSyntaxOrder($"{numbersSplitted[1]}", numbersSplitted[2]);
                return;
              }
            }
          }
        }*/
      }
      // 210 и 220 (zwei hundert und zwanzig)
      
      else if (numbersSplitted.Length == 4)
      {
        errorHandler.customError("В немецком языке нет числительных, в составе которых четыре слова");
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

        //verification
        /*if (statusList[0] != 'd')
        {
          errorHandler.errorSyntaxOrderMessage($"Число не может начинаться со слова {numbersSplitted[0]}");
          return;
        }
        else
        {
          if (statusList[1] != 'h')
          {
            if (statusList[1] == 's')
            {
              errorHandler.errorSyntaxOrder($"{numbersSplitted[2]}", $"{numbersSplitted[1]}", 1);
              return;
            }
            else
            {
              errorHandler.errorSyntaxOrder($"{numbersSplitted[0]}", $"{numbersSplitted[1]}");
              return;
            }
          }
          else
          {
            if (statusList[2] != 'd')
            {
              errorHandler.errorSyntaxOrder($"{numbersSplitted[1]}", $"{numbersSplitted[2]}");
              return;
            }
            else
            {
                errorHandler.errorSyntaxOrder($"{numbersSplitted[2]}", $"{numbersSplitted[3]}");
                return;
            }
          }
        }*/
      }

      //234
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


        //verification 
        /*if (statusList[0] != 'd')
        {
          errorHandler.errorSyntaxOrderMessage($"Пятисоставное число не может начинаться словом {numbersSplitted[0]}");
          return;
        }
        else
        {
          if (statusList[1] != 'h')
          {
            errorHandler.errorSyntaxOrder($"{numbersSplitted[0]}", $"{numbersSplitted[1]}");
            return;
          }
          else
          {
            if (statusList[2] != 'd')
            {
              errorHandler.errorSyntaxOrder($"{numbersSplitted[1]}", $"{numbersSplitted[2]}");
              return;
            }
            else
            {
              if (statusList[3] != 's')
              {
                errorHandler.errorSyntaxOrder($"{numbersSplitted[2]}", $"{numbersSplitted[3]}");
                return;
              }
              else
              {
                if (statusList[4] != 'n')
                {
                  errorHandler.errorSyntaxOrder($"{numbersSplitted[3]}", $"{numbersSplitted[4]}");
                  return;
                }
              }
            }
          }
        }*/
      }
      // error len 
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
            errorHandler.errorSyntax(witness);
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
  }
}
