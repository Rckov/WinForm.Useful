using System;

namespace WinForm.Useful.Bindings
{
   [AttributeUsage(AttributeTargets.Property)]
   public class BindingProperty : Attribute
   {
      public BindingProperty(string property)
      {
         Property = property;
      }

      public string Property { get; set; }
   }
}