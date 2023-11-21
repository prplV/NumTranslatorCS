using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace NumTranslatorCS
{
  internal class errorHandler
  {
    private static Form mainForm;
    public static void getFormObj(Form form)
    {
      mainForm = form;
    }
    // errors
    public static void errorEmptyTransField()
    {
      MessageBox.Show(mainForm, "Поле для записи транскрипции числа не заполнено", "Поле пустое", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static void errorGlobalTransLen()
    {
      MessageBox.Show(mainForm, "Максимальное число подлежащее трансляции - 999, введенное число больше", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static void errorGlobalListLens()
    {
      MessageBox.Show(mainForm, "Глобальная ошибка разности контрольных сумм списка статуса и списка слов", "Глобальная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void errorSyntax(string witness)
    {
      MessageBox.Show(mainForm, $"Ошибка в слове {witness}", "Синтаксическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static void errorSyntaxOrder(string received, string expected)
    {
      MessageBox.Show(mainForm, $"{expected} не может стоять после {received}!", "Неправильный формат ввода числа", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void errorSyntaxOrder(string received, string expected, int position )
    {
      MessageBox.Show(mainForm, $"{expected} не может стоять перед {received}!", "Неправильный формат ввода числа", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static void errorSyntaxOrder(string received)
    {
      MessageBox.Show(mainForm, $"Число не может начинаться с {received.ToUpper()}!", "Неправильный формат ввода числа", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static void errorSyntaxOrderMessage(string received)
    {
      MessageBox.Show(mainForm, $"{received}", "Неправильный формат ввода числа", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static void customError(string message)
    {
      MessageBox.Show(mainForm, $"{message}", "Неправильный формат ввода числа", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static void MatchingTypesError_After(char first, char second, string er1, string er2)
    {
      string f = null;
      string s = null;
      switch (first)
      {
        case 'd':
          f = "единиц";
          break;
        case 'n':
          f = "десяток";
          break;
        case 'e':
          f = "чисел 11-19";
          break;
        case 'h':
          f = "слова для обозначения сотен HUNDERT";
          break;
        case 's':
          f = "служебного слова UND";
          break;
        default:
          MessageBox.Show(mainForm, $"Critical exception was called while parsing the 'first' type-char", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          break;
      };
      switch (second)
      {
        case 'd':
          s = "Единицы не могут";
          break;
        case 'n':
          s = "Десятки не могут";
          break;
        case 'e':
          s = "Числа 11-19 не могут";
          break;
        case 'h':
          s = "Слово для обозначения сотен HUNDERT не может";
          break;
        case 's':
          s = "Служебное слово UND не может";
          break;
        default:
          MessageBox.Show(mainForm, $"Critical exception was called while parsing the 'second' type-char", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          break;
      };
      //MessageBox.Show(mainForm, $"{s} не может стоять после {f} -> ({er1} {er2})!", "Неправильный формат ввода числа", MessageBoxButtons.OK, MessageBoxIcon.Error);
      MessageBox.Show(mainForm, $"{s} стоять после {f}!", "Неправильный формат ввода числа", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }
    public static void TwoHundertUsage()
    {
      MessageBox.Show(mainForm, "Слово для обозначения сотен HUNDERT не может быть использовано в числительном более одного раза", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    // infos 
    public static void infoNoNeedToClearAll()
    {
      MessageBox.Show(mainForm, "Очистка не нужна", "Все поля пусты", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

  }
}
