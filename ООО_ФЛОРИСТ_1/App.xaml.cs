using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ООО_ФЛОРИСТ_1.Models;

namespace ООО_ФЛОРИСТ_1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static floristContext context { get; } = new floristContext();
    }
}
