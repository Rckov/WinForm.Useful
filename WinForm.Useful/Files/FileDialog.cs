using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinForm.Useful.Files
{
   public class FileDialog
   {
      public static string SaveDialog(string filter = null, SaveFileDialog saveFileDialog = null)
      {
         using (var dialog = saveFileDialog ?? new SaveFileDialog())
         {
            dialog.Filter = filter;
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : string.Empty;
         }
      }

      public static string OpenDialog(string filter = null, OpenFileDialog openFileDialog = null)
      {
         using (var dialog = openFileDialog ?? new OpenFileDialog())
         {
            dialog.Filter = filter;
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : string.Empty;
         }
      }

      public static IEnumerable<string> OpenDialogMultiselect(string filter = null, OpenFileDialog openFileDialog = null)
      {
         using (var dialog = openFileDialog ?? new OpenFileDialog())
         {
            dialog.Filter = filter;
            dialog.Multiselect = true;
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileNames : Enumerable.Empty<string>();
         }
      }
   }
}