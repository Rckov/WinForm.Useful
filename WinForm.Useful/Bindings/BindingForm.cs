using System.Windows.Forms;

namespace WinForm.Useful.Bindings
{
   public class BindingForm : Form
   {
      private BindingSource _binding;

      public object Context
      {
         set
         {
            _binding = _binding ?? new BindingSource(value, this);
            _binding.InitializeComponent();
         }
      }
   }
}