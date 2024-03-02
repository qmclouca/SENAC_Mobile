namespace SENAC_TEST
{
    public partial class MainPage : ContentPage
    {
        bool isPlayerOneTurn = true;
        string[,] tabuleiro = new string[3, 3];

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.Text == null)
            {
                button.Text = isPlayerOneTurn ? "X" : "O";
                isPlayerOneTurn = !isPlayerOneTurn;
            }
        }

        private string VerificarVencedor()
        {
            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[i, 0] == tabuleiro[i, 1] && tabuleiro[i, 1] == tabuleiro[i, 2])
                {
                    return tabuleiro[i, 0] + " venceu!";
                }
                if (tabuleiro[0, i] == tabuleiro[1, i] && tabuleiro[1, i] == tabuleiro[2, i])
                {
                    return tabuleiro[0, i] + " venceu!";
                }
            }
            if (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2])
            {
                return tabuleiro[0, 0] + " venceu!";
            }
            if (tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0])
            {
                return tabuleiro[0, 2] + " venceu!";
            }

            bool empate = true;
            for (int i = 0; i<3; i++) 
            {
                for (int j = 0; i<3; i++)
                {
                    if (tabuleiro[i,j] == null)
                    {
                        empate = false;
                    }
                }
            }

            if(empate)
            {
                return "Empate!";
            }
            return "Jogo Continua!";
        }
    }
}
