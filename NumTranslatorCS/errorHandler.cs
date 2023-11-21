using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace NumTranslatorCS
{
  internal class errorHandler
  {
    private string[] statusString;
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
      MessageBox.Show(mainForm, "Максимальное число подлежащее трансляции - 999, введенное число больше, либо формат ввода неверен", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static void errorGlobalListLens()
    {
      MessageBox.Show(mainForm, "Глобальная ошибка разности контольных сумм списка статуса и списка слов", "Глобальная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
      MessageBox.Show(mainForm, $"{received} не может быть транслировано! Это не число", "Неправильный формат ввода числа", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
          f = "единицы";
          break;
        case 'n':
          f = "десятки";
          break;
        case 'e':
          f = "числа 11-19";
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
          s = "Единица";
          break;
        case 'n':
          s = "Десятка";
          break;
        case 'e':
          s = "Число 11-19";
          break;
        case 'h':
          s = "Слово для обозначения сотен HUNDERT";
          break;
        case 's':
          s = "Служебное слово UND";
          break;
        default:
          MessageBox.Show(mainForm, $"Critical exception was called while parsing the 'second' type-char", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          break;
      };
      MessageBox.Show(mainForm, $"{s} не может стоять после {f} -> ({er1} {er2})!", "Неправильный формат ввода числа", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return;
    }

    // infos 
    public static void infoNoNeedToClearAll()
    {
      MessageBox.Show(mainForm, "Все пусто, очистка не нужна", "Все поля пусты", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

  }
}
