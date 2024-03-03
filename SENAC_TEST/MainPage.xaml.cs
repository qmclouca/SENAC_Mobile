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
                AtualizarTabuleiro(button, button.Text);


                string resultadoInteracao = VerificarVencedor();
                if (resultadoInteracao != "Jogo Continua!")
                {
                    DisplayAlert("Fim de Jogo", resultadoInteracao, "OK");
                    ReiniciarJogo(); 
                }

                isPlayerOneTurn = !isPlayerOneTurn;
            }
        }

        private void AtualizarTabuleiro(Button button, string valor)
        {
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            tabuleiro[row, column] = valor;
        }

        private void ReiniciarJogo()
        {
            isPlayerOneTurn = true;
            tabuleiro = new string[3, 3];
            foreach (var child in TabuleiroJogo.Children)
            {
                if (child is Button button)
                {
                    button.Text = null;
                }
            }
        }

        private string VerificarVencedor()
        {
            // Verifica linhas e colunas.
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(tabuleiro[i, 0]) &&
                    tabuleiro[i, 0] == tabuleiro[i, 1] &&
                    tabuleiro[i, 1] == tabuleiro[i, 2])
                {
                    return $"{tabuleiro[i, 0]} venceu!";
                }
                if (!string.IsNullOrEmpty(tabuleiro[0, i]) &&
                    tabuleiro[0, i] == tabuleiro[1, i] &&
                    tabuleiro[1, i] == tabuleiro[2, i])
                {
                    return $"{tabuleiro[0, i]} venceu!";
                }
            }

            // Verifica diagonais.
            if (!string.IsNullOrEmpty(tabuleiro[0, 0]) &&
                tabuleiro[0, 0] == tabuleiro[1, 1] &&
                tabuleiro[1, 1] == tabuleiro[2, 2])
            {
                return $"{tabuleiro[0, 0]} venceu!";
            }
            if (!string.IsNullOrEmpty(tabuleiro[0, 2]) &&
                tabuleiro[0, 2] == tabuleiro[1, 1] &&
                tabuleiro[1, 1] == tabuleiro[2, 0])
            {
                return $"{tabuleiro[0, 2]} venceu!";
            }

            // Verifica empate.
            bool empate = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrEmpty(tabuleiro[i, j]))
                    {
                        empate = false;
                    }
                }
            }

            if (empate)
            {
                return "Empate!";
            }
            return "Jogo Continua!";
        }
    }
}
