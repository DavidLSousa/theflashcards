import { create } from 'zustand';

import { Card } from "@/src/models/Card";
import { Category } from "@/src/models/Category";
import { CardRepository } from "@/src/repositories/cardRepository";
import { CategoryRepository } from "@/src/repositories/categoryRepository";

type CardType = {
  cards: Card[];
  fetchCards: () => Promise<void>;
  categories: Category[];
  fetchCategories: () => Promise<void>;

  addCard: (quest: string, resp: string, category: string) => void;
  editCard: (updatedCard: Partial<Card>) => void;
  removeCard: (id: string) => void;
  toggleAnswer: (id: string) => void;
  importNewCards: (importedCards: string) => Promise<void>;
  copyCardsToClipboard: () => Promise<void>;

}

const cardRepository = new CardRepository();
const categoryRepository = new CategoryRepository();

export const useCard = create<CardType>((set) => ({
  cards: [],
  categories: [],
  fetchCards: async () => {
    const cards = await cardRepository.getAllCards();
    set({ cards });
  },
  fetchCategories: async () => {
    const categories = await categoryRepository.getAllCategories();
    set({ categories });
  },

  addCard: (quest, resp, category) =>
    set((state) => {
      const newCard = new Card(quest, resp, category);
      const newCards = [...state.cards, newCard];

      // Repository
      cardRepository.saveCard(newCard);
      categoryRepository.saveCategory(newCard.category);

      return { cards: newCards }
    }),
  editCard: (updatedCard: Partial<Card>) =>
    set((state) => {
      // Update Cartegory
      const [originalCard] = state.cards.filter((currentCard: Card) => currentCard.id === updatedCard.id);
      categoryRepository.editCategory(originalCard.category, String(updatedCard.category));

      // Update Card
      const updatedCards = state.cards.map((currentCard) =>
        currentCard.id === updatedCard.id
          ? { ...currentCard, ...updatedCard }
          : currentCard);

      // Repository
      cardRepository.editCard(updatedCard);

      return { cards: updatedCards };
    }),
  removeCard: (id) =>
    set((state) => {
      categoryRepository.deleteCategory(id)
      
      const updatedCards = state.cards.filter((card) => card.id !== id);

      // Remove the card from the repository
      cardRepository.removeCard(id);

      return { cards: updatedCards };
    }),
  toggleAnswer: (id) =>
    set((state) => {
      const updatedCards = state.cards.map((card) =>
        card.id === id
          ? { ...card, isAnswerVisible: !card.isAnswerVisible }
          : card);

      return { cards: updatedCards };
    }),
  importNewCards: async (importedCards) => {
    await cardRepository.importCards(importedCards);
    await categoryRepository.importCategories(importedCards);
  },
  copyCardsToClipboard: async () => {
    await cardRepository.copyCardsToClipboard();
  },
}));
