using System.Collections.Generic;
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
    public static void globalErrorMessageHandler(string[] numbersSplitted, List<char> statusList)
    {
      if (numbersSplitted.Length == 1)
      {
        
      } else if (numbersSplitted.Length == 2)
      {

      } else if (numbersSplitted.Length == 3)
      {

      } else if (numbersSplitted.Length == 4)
      {

      } else if (numbersSplitted.Length == 5)
      {
        
      }
    }
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

    // infos 
    public static void infoNoNeedToClearAll()
    {
      MessageBox.Show(mainForm, "Все пусто, очистка не нужна", "Все поля пусты", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

  }
}
