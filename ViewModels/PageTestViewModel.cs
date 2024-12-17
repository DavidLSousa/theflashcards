using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using theflashcards.Model;
using theflashcards.Services;

namespace theflashcards.ViewModels;

public partial class PageTestViewModel : ObservableObject
{
    private List<string> _categoriesList;

    [ObservableProperty]
    private ObservableCollection<Card> _cardsForTest;

    public List<string> CategoriesList
    {
        get => _categoriesList;
        set
        {
            _categoriesList = value;
            ShowCards();
        }
    }

    private CardsServices cardServices = new();

    public PageTestViewModel()
    {
        CardsForTest = new ObservableCollection<Card>();
    }

    [RelayCommand]
    private async Task ShowCards()
    {
        try
        {
            var cardsForTest = new List<Card>();
            var filePathAllCards = cardServices.GetfilePathFor("allCards");
            var cards = await cardServices.GetDeserializedFile<List<Card>>(filePathAllCards);

            foreach (var card in cards)
            {
                if (CategoriesList.Contains(card.Category))
                {
                    card.IsAnswerVisible = false;
                    cardsForTest.Add(card);
                }
            }

            CardsForTest = new ObservableCollection<Card>(cardsForTest);
        }
        catch (Exception ex)
        {
            await Toast.Make("Erro ao mostrar cards").Show();
        }
    }

    [RelayCommand]
    private async Task ToggleAnswerVisibility(Card card)
    {
        var filePathAllCards = cardServices.GetfilePathFor("allCards");
        var allCards = await cardServices.GetDeserializedFile<List<Card>>(filePathAllCards);

        foreach (var currentCard in allCards)
        {
            if (currentCard.Id == card.Id)
                currentCard.IsAnswerVisible = !currentCard.IsAnswerVisible;
        }

        cardServices.SaveSerializedFile(filePathAllCards, allCards);

        var cardsForTest = new List<Card>();
        foreach (var currentCard in allCards)
        {
            if (CategoriesList.Contains(currentCard.Category))
                cardsForTest.Add(currentCard);
        }

        CardsForTest = new ObservableCollection<Card>(cardsForTest);
    }

    [RelayCommand]
    private void SelectAnswer((Card card, bool isCorrect) parameters)
    {
        var (card, isCorrect) = parameters;

        if (card == null)
            return;

        try
        {
            if (!card.Answer.ContainsKey(card.Id))
            {
                // Inicializa o dicionário apenas uma vez.
                card.Answer[card.Id] = (0, 0);
            }

            var currentAnswer = card.Answer[card.Id];
            card.Answer[card.Id] = isCorrect
                ? (currentAnswer.correct + 1, currentAnswer.wrong)
                : (currentAnswer.correct, currentAnswer.wrong + 1);
        }
        catch (Exception ex)
        {
            // Log ou exibir mensagem para debugging.
            System.Diagnostics.Debug.WriteLine($"Erro ao selecionar resposta: {ex.Message}");
        }
    }


    [RelayCommand]
    private void SelectDifficulty((Card card, string difficulty) parameters)
    {
        var (card, difficulty) = parameters;

        if (card != null)
        {
            if (!card.Difficulty.ContainsKey(card.Id))
            {
                card.Difficulty[card.Id] = (0, 0, 0);
            }

            var currentDifficulty = card.Difficulty[card.Id];

            card.Difficulty[card.Id] = difficulty switch
            {
                "Easy" => (currentDifficulty.facil + 1, currentDifficulty.medio, currentDifficulty.dificil),
                "Medium" => (currentDifficulty.facil, currentDifficulty.medio + 1, currentDifficulty.dificil),
                "Hard" => (currentDifficulty.facil, currentDifficulty.medio, currentDifficulty.dificil + 1),
                _ => currentDifficulty
            };
        }
    }
}
