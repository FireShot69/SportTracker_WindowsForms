using System;
using System.Drawing;
using System.Windows.Forms;

namespace SportTracker_WindowsForms
{
    public partial class Form1 : Form
    {
        private SportService service = new SportService();

        private TextBox txtName;
        private TextBox txtSport;
        private TextBox txtDuration;
        private TextBox txtNotes;

        private ListBox listAthletes;
        private ListBox listTrainings;

        private Button btnAddAthlete;
        private Button btnAddTraining;
        private Button btnDelete;
        private Button btnStats;

        public Form1()
        {
            InitUI();
            RefreshUI();
        }

        private void InitUI()
        {
            this.Text = "Sport Tracker";
            this.Size = new Size(950, 550);

            // ввод
            txtName = CreateBox("Имя", 20, 20);
            txtSport = CreateBox("Вид спорта", 20, 60);
            txtDuration = CreateBox("Длительность (мин)", 20, 120);
            txtNotes = CreateBox("Заметки", 20, 160);

            // кнопки
            btnAddAthlete = new Button { Text = "Добавить спортсмена", Location = new Point(200, 20), Width = 180 };
            btnAddTraining = new Button { Text = "Добавить тренировку", Location = new Point(200, 60), Width = 180 };
            btnDelete = new Button { Text = "Удалить", Location = new Point(200, 120), Width = 180 };
            btnStats = new Button { Text = "Статистика", Location = new Point(200, 160), Width = 180 };

            btnAddAthlete.Click += AddAthlete;
            btnAddTraining.Click += AddTraining;
            btnDelete.Click += Delete;
            btnStats.Click += Stats;

            // лист
            listAthletes = new ListBox { Location = new Point(420, 20), Size = new Size(480, 220) };
            listTrainings = new ListBox { Location = new Point(420, 260), Size = new Size(480, 220) };

            Controls.Add(txtName);
            Controls.Add(txtSport);
            Controls.Add(txtDuration);
            Controls.Add(txtNotes);

            Controls.Add(btnAddAthlete);
            Controls.Add(btnAddTraining);
            Controls.Add(btnDelete);
            Controls.Add(btnStats);

            Controls.Add(listAthletes);
            Controls.Add(listTrainings);
        }

        // ================= ввод =================
        private TextBox CreateBox(string text, int x, int y)
        {
            var tb = new TextBox
            {
                Location = new Point(x, y),
                Width = 150,
                Text = text,
                ForeColor = Color.Gray
            };

            tb.Enter += (s, e) =>
            {
                if (tb.Text == text)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };

            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = text;
                    tb.ForeColor = Color.Gray;
                }
            };

            return tb;
        }

        // ================= добавить атлета =================
        private void AddAthlete(object sender, EventArgs e)
        {
            service.AddAthlete(txtName.Text, txtSport.Text);

            txtName.Text = "Имя";
            txtSport.Text = "Вид спорта";

            RefreshUI();
        }

        // ================= добавить тренировку =================
        private void AddTraining(object sender, EventArgs e)
        {
            var athlete = listAthletes.SelectedItem as Athlete;

            if (athlete == null)
            {
                MessageBox.Show("Выберите спортсмена!");
                return;
            }

            if (!int.TryParse(txtDuration.Text, out int duration))
            {
                MessageBox.Show("Введите число!");
                return;
            }

            service.AddTraining(athlete.Id, duration, txtNotes.Text);

            txtDuration.Text = "Длительность (мин)";
            txtNotes.Text = "Заметки";

            RefreshUI();
        }

        // ================= удалить =================
        private void Delete(object sender, EventArgs e)
        {
            if (listAthletes.SelectedItem is Athlete athlete)
            {
                service.RemoveAthlete(athlete.Id);
            }

            if (listTrainings.SelectedItem is Training training)
            {
                service.RemoveTraining(training.Id);
            }

            RefreshUI();
        }

        // ================= статистика =================
        private void Stats(object sender, EventArgs e)
        {
            MessageBox.Show(service.GetStats());
        }

        // ================= рефреш =================
        private void RefreshUI()
        {
            listAthletes.Items.Clear();
            listTrainings.Items.Clear();

            foreach (var a in service.GetAthletes())
                listAthletes.Items.Add(a);

            foreach (var t in service.GetTrainings())
                listTrainings.Items.Add(t);
        }
    }
}