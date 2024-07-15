using theflashcards.Model;

namespace theflashcards.pages;

public partial class NewCard : ContentPage
{
	public NewCard()
	{
		InitializeComponent();
	}
    public void SaveCard(object sender, EventArgs e) {
		
		Cards newCard = new Cards();

		newCard.Quest = Quest.Text;
		newCard.Resp = Resp.Text;
		newCard.Category = Category.Text;

		// Salvar nos arquivos de em um diretorio de acordo com a categoria criada
    } 

}