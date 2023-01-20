using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WinForm.Useful.Bindings
{
   public class BindingSource
   {
      private readonly object _context;
      private readonly BindingForm _bindingForm;

      public BindingSource(object context, BindingForm bindingForm)
      {
         _context = context;
         _bindingForm = bindingForm;
      }

      public void InitializeComponent()
      {
         var properties = _context.GetType().GetProperties();

         foreach (Control control in GetAllControls(_bindingForm))
         {
            var property = properties.FirstOrDefault(prop => prop.Name == control.Name);

            if (property != null)
            {
               CreateBinding(control, property);
            }
         }
      }

      private void CreateBinding(Control control, PropertyInfo propertyInfo)
      {
         var controlPropertyName = propertyInfo.GetCustomAttribute<BindingProperty>()?.Property;

         if (string.IsNullOrWhiteSpace(controlPropertyName))
         {
            return;
         }

         _ = control.DataBindings.Add(controlPropertyName, _context, propertyInfo.Name);
      }

      private IEnumerable<Control> GetAllControls(Control parent)
      {
         var controls = new List<Control>();

         foreach (Control child in parent.Controls)
         {
            controls.AddRange(GetAllControls(child));
         }

         controls.Add(parent);

         return controls;
      }
   }
}