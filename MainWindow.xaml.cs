using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Semantic_Analysis
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void firstButton_Click(object sender, RoutedEventArgs e)
        {
            DataSet data = new DataSet();
            data.Get("d://result3.txt");
            if (reviewText.Text == "")
            {
                MessageBox.Show("Введите текст отзыва");
                return;
            }
            Review review = new Review(reviewText.Text);
            Classifier.Classify(review, data);

            if (review.MyTonality)
                tonalityLabel.Content = "положительный";
            else
                tonalityLabel.Content = "отрицательный";
        }

        private void secondButton_Click(object sender, RoutedEventArgs e)
        {
            DataSet data = new DataSet();
            data.Get("d://result4.txt");

            statisticValue.Content = "";
            string url = "http://torg.mail.ru/review/shops/?page=";
            int count;
            try
            {
                count = Convert.ToInt32(countText.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите количество отзывов");
                return;
            }

            Thread t = new Thread((delegate() { Print(data, url, count); }));
            t.Start();
        }

        private void Print(DataSet data, string url, int count)
        {
            List<Review> reviews = new List<Review>();
            ParsingWeb parser = new ParsingWeb();
            int it = 0, hund = 0;

            try
            {
                parser.Parse(count, ref url, ref it, ref hund, ref reviews);
            }
            catch (Exception)
            {
                MessageBox.Show("ошибка mail.ru");
                return;
            }

            this.Dispatcher.Invoke(new Action(() =>
            {
                listReviews.Items.Clear();
                foreach (var rev in reviews)
                {
                    StackPanel panel = new StackPanel();
                    panel.Orientation = Orientation.Horizontal;
                    TextBox label1 = new TextBox();
                    label1.Text = rev.Text;
                    TextBox label2 = new TextBox();

                    Classifier.Classify(rev, data);

                    if (rev.MyTonality)
                        label2.Text = "положительный";
                    else
                        label2.Text = "отрицательный ";

                    label1.Width = 375;
                    label1.TextWrapping = TextWrapping.Wrap;
                    panel.Children.Add(label1);
                    panel.Children.Add(label2);
                    listReviews.Items.Add(panel);
                }

                statisticValue.Content = Statistics.Calculate(reviews);
            }));
        }
    }
}

