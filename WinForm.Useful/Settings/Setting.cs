namespace WinForm.Useful.Settings
{
   public static class Setting
   {
      public static object GetValue(string propertyName)
      {
         return ContainsKey(propertyName) ? Properties.Settings.Default[propertyName] : null;
      }

      public static void SetValue(string propertyName, object value)
      {
         if (ContainsKey(propertyName))
         {
            Properties.Settings.Default[propertyName] = value;
         }
         else
         {
            Properties.Settings.Default.Context.Add(propertyName, value);
         }

         Properties.Settings.Default.Save();
      }

      public static T LoadModel<T>(T model) where T : class
      {
         foreach (var item in model.GetType().GetProperties())
         {
            var value = GetValue(item.Name);

            if (value != null)
            {
               item.SetValue(model, value);
            }
         }

         return model;
      }

      public static T SaveModel<T>(T model) where T : class
      {
         foreach (var item in model.GetType().GetProperties())
         {
            SetValue(item.Name, item.GetValue(model));
         }

         return model;
      }

      public static void RemoveProperty(string propertyName)
      {
         Properties.Settings.Default.Context.Remove(propertyName);
      }

      private static bool ContainsKey(string propertyName)
      {
         return Properties.Settings.Default.Context.ContainsKey(propertyName);
      }
   }
}