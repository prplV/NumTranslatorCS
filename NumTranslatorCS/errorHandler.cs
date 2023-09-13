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
      MessageBox.Show(mainForm, "Глобальная ошибка разности длин списка статуса и списка слов", "Глобальная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void errorSyntax(string witness)
    {
      MessageBox.Show(mainForm, $"Ошибка в слове {witness}", "Синтаксическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void errorSyntaxOrder(string received, string expected, int position )
    {
      MessageBox.Show(mainForm, $"Неправильный порядок числительных в исходном числе.\nОжидалось - {expected}, получено - {received}.\nНомер слова - {++position}", "Ошибка порядка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    // infos 
    public static void infoNoNeedToClearAll()
    {
      MessageBox.Show(mainForm, "Все пусто, очистка не нужна", "Все поля пусты", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

  }
}
