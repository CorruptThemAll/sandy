using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace graphtool;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        int[] array = { 1, 2, 3, 4, 5 };
        if (!File.Exists("test.json"))
            File.WriteAllText("test.json", JsonConvert.SerializeObject(array));

        Debug.WriteLine(LoadData.ImportData<int[]>("test.json").First());
    }
}