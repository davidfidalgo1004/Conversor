using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;


namespace Conversor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Metodos metodos;
        public MainWindow()
        {
            InitializeComponent();
            metodos = new Metodos();    
        }

        private void PropProg_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Programador: David Fidalgo\nAno: 2024", "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(tbValorConverter.Text=="Introduza o valor")
            {
                tbValorConverter.Text="";
            }
        }

        private void cbTipoConversao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTipoConversao.SelectedItem is ComboBoxItem selectedItem)
            {
                // Acessar o texto da opção selecionada
                string selectedText = selectedItem.Content.ToString();
                cbDE.Items.Clear();
                cbPARA.Items.Clear();
                if (selectedText == "Tempo")
                {

                    cbDE.Items.Add(new ComboBoxItem { Content = "Anos" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "Meses" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "Dias" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "Horas" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "Minutos" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "Segundos" });

                    cbPARA.Items.Add(new ComboBoxItem { Content = "Anos" });
                    cbPARA.Items.Add(new ComboBoxItem { Content = "Meses" });
                    cbPARA.Items.Add(new ComboBoxItem { Content = "Dias" });
                    cbPARA.Items.Add(new ComboBoxItem { Content = "Horas" });
                    cbPARA.Items.Add(new ComboBoxItem { Content = "Minutos" });
                    cbPARA.Items.Add(new ComboBoxItem { Content = "Segundos" });
                }

                if (selectedText == "Moeda")
                {

                    cbDE.Items.Add(new ComboBoxItem { Content = "EUR" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "GBP" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "USD" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "BRL" });

                    cbPARA.Items.Add(new ComboBoxItem { Content = "EUR" });
                    cbPARA.Items.Add(new ComboBoxItem { Content = "GBP" });
                    cbPARA.Items.Add(new ComboBoxItem { Content = "USD" });
                    cbPARA.Items.Add(new ComboBoxItem { Content = "BRL" });
                }

                if (selectedText == "Energia")
                {

                    cbDE.Items.Add(new ComboBoxItem { Content = "Joules" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "Calorias" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "KiloWatts hora" });

                }
                if (selectedText == "Comprimentos/Distâncias")
                {

                    cbDE.Items.Add(new ComboBoxItem { Content = "Milha" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "Metros" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "Polegadas" });
                    cbDE.Items.Add(new ComboBoxItem { Content = "Centimetros" });

                }
            }
        }

        private void cbPARA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPARA.SelectedItem is ComboBoxItem selectedItem)
            {
                textConvertido.Text=selectedItem.Content.ToString();
            }
        }

        private void cbDE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbPARA.SelectedIndex = -1;
            tbValorConverter.Text = "Introduza o valor";
            tbValorConvertido.Text = "";

            if (cbTipoConversao.SelectedItem is ComboBoxItem selectedItem && cbDE.SelectedItem is ComboBoxItem selectedItem1)
            {
                string itemselecionado = selectedItem.Content.ToString();

                if (itemselecionado == "Energia")
                {
                    cbPARA.Items.Clear();
                    itemselecionado = selectedItem1.Content.ToString();
                    
                    if (itemselecionado == "KiloWatts hora" || itemselecionado == "Calorias")
                    {
                        cbPARA.Items.Add(new ComboBoxItem { Content = "Joules" });
                    }
                    else
                    {
                        cbPARA.Items.Add(new ComboBoxItem { Content = "Joules" });
                        cbPARA.Items.Add(new ComboBoxItem { Content = "KiloWatts hora" });
                        cbPARA.Items.Add(new ComboBoxItem { Content = "Calorias" });
                    }

                }
                if (itemselecionado == "Comprimentos/Distâncias")
                {
                    cbPARA.Items.Clear();
                    itemselecionado = selectedItem1.Content.ToString();

                    if (itemselecionado == "Polegadas")
                    {
                        cbPARA.Items.Add(new ComboBoxItem { Content = "Centimentros" });
                    }
                    else
                    {
                        if (itemselecionado == "Milha")
                        {
                            cbPARA.Items.Add(new ComboBoxItem { Content = "Metros" });
                        }
                        else
                        {
                            cbPARA.Items.Add(new ComboBoxItem { Content = "Milha" });
                            cbPARA.Items.Add(new ComboBoxItem { Content = "Metros" });
                            cbPARA.Items.Add(new ComboBoxItem { Content = "Polegadas" });
                            cbPARA.Items.Add(new ComboBoxItem { Content = "Centimetros" });
                        }
                    }

                }
                itemselecionado = selectedItem1.Content.ToString();
                textConverter.Text = itemselecionado;
            }
            
        }

        private async void tbValorConverter_KeyDown(object sender, KeyEventArgs e)
        {
            tbErroConvertido.Text = "";
            
            if (e.Key == Key.Enter)
            {

                if (cbTipoConversao.SelectedItem is ComboBoxItem selectedItemConversao && cbDE.SelectedItem is ComboBoxItem selectedItemOp1 && cbPARA.SelectedItem is ComboBoxItem selectedItemOp2)
                {
                    if (IsValidNumber(tbValorConverter.Text))
                    {
                        string Optipo = selectedItemConversao.Content.ToString();
                        string Op1 = selectedItemOp1.Content.ToString();
                        string Op2 = selectedItemOp2.Content.ToString();
                        float valor = 0;
                        string valorcorrigido = tbValorConverter.Text.Replace('.', ',');
                        switch (Optipo)
                        {
                            case "Moeda":
                                try
                                {
                                    valor = await metodos.ConvertMoeda(Op1, Op2, float.Parse(valorcorrigido));
                                    tbValorConvertido.Text = valor.ToString();

                                }
                                catch (Exception ex)
                                {
                                    valor = metodos.ConvertMoedaGeneric(Op1, Op2, float.Parse(valorcorrigido));
                                    tbErroConvertido.Text = "Erro:\nNão foi possível converter com os valores atuais\nConvertido com valores genéricos!";
                                    tbValorConvertido.Text = valor.ToString();
                                }
                                break;
                            case "Energia":
                                valor = metodos.ReceiveOptionsEnergia(Op1, Op2, float.Parse(valorcorrigido));
                                tbValorConvertido.Text = valor.ToString();
                                break;
                            case "Tempo":
                                valor = metodos.ReceiveOptionsTempo(Op1, Op2, float.Parse(tbValorConverter.Text));
                                tbValorConvertido.Text = valor.ToString();
                                break;
                            case "Comprimentos/Distâncias":
                                valor = metodos.ReceiveOptionsComprimentos(Op1, Op2, float.Parse(tbValorConverter.Text));
                                tbValorConvertido.Text = valor.ToString();
                                break;
                            default:
                                break;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Introduza um numero válido!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                        tbValorConverter.Text = "";
                        tbValorConvertido.Text = "";
                    }
                }
            }
        }
        static bool IsValidNumber(string verifica)
        {
            string ExpReg = @"^\d+([.,]\d+)?$"; //Expressão Regular
            return Regex.IsMatch(verifica, ExpReg);
        }
    }
}