namespace Tugas_3
{
    public partial class Form1 : Form
    {
        int totalLoop = 1;
        Random rnd = new Random();

        // Pool berdasarkan rarity
        Dictionary<string, string[]> rarityPool = new Dictionary<string, string[]>
        {
            { "Legendary", new[] { "LATIFI" } },
            { "Epic", new[] { "LEWIS", "VETTEL" } },
            { "Rare", new[] { "MAX", "LECLERC" } },
            { "Common", new[] { "GASLY", "PEREZ", "RUSSEL", "SAINZ", "STROLL" } }
        };

        public Form1()
        {
            InitializeComponent();
            lblTotalLoop.Text = $"{totalLoop}";

        }

        private void btnGacha_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();

            for (int i = 0; i < totalLoop; i++)
            {
                string rarity = GetRarity();
                string[] pool = rarityPool[rarity];
                string selectedCard = pool[rnd.Next(pool.Length)];

                Image cardImage = (Image)Properties.Resources.ResourceManager.GetObject(selectedCard);
                if (cardImage != null)
                {
                    pictureBox.Image = cardImage;
                    listBox.Items.Add($"Draw {i + 1}: {selectedCard} ({rarity})");
                }
                else
                {
                    listBox.Items.Add($"Draw {i + 1}: [Gambar '{selectedCard}' tidak ditemukan]");
                }

                // Delay animasi
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }
        }

        private string GetRarity()
        {
            double roll = rnd.NextDouble(); // 0.0 – 1.0

            if (roll < 0.005) return "Legendary";       
            else if (roll < 0.10) return "Epic";
            else if (roll < 0.25) return "Rare";       
            else return "Common";                    
        }

        private void btnPlus1_Click(object sender, EventArgs e)
        {
            totalLoop++;
            lblTotalLoop.Text = $"{totalLoop}";
        }

        private void btnPlus10_Click(object sender, EventArgs e)
        {
            totalLoop += 10;
            lblTotalLoop.Text = $"{totalLoop}";
        }

        private void btnMinus1_Click(object sender, EventArgs e)
        {
            if (totalLoop > 1) totalLoop--;
            lblTotalLoop.Text = $"{totalLoop}";
        }

        private void btnMinus10_Click(object sender, EventArgs e)
        {
            if (totalLoop > 10) totalLoop -= 10;
            else totalLoop = 1;
            lblTotalLoop.Text = $"{totalLoop}";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            pictureBox.Image = null;
        }
    }
}
