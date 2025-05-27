import * as FileSystem from 'expo-file-system';
import * as Clipboard from 'expo-clipboard';

import { Card } from '@/src/models/Card';

export class CardRepository {
  private path = `${FileSystem.documentDirectory}allCards.json`;

  // public static async delete() {
  //   await FileSystem.deleteAsync(`${FileSystem.documentDirectory}allCards.json`, { idempotent: true });
  // }
  public async saveCard(card: Card) {
    try {
      const created = await this.createFileAndSaveContentIfNotExists(JSON.stringify([card], null, 2));
      if (created) return;

      const fileContent = await FileSystem.readAsStringAsync(this.path);
      const savedCards: Card[] = JSON.parse(fileContent);
      savedCards.push(card);

      await FileSystem.writeAsStringAsync(this.path, JSON.stringify(savedCards, null, 2));

    } catch (error) {
      console.error('saveCards: ', error);
      if (error instanceof Error) throw new Error(error.message);

      throw new Error('Failed to save card');
    }
  }
  public editCard(card: Partial<Card>) { };
  public removeCard(id: string) { };

  public async getAllCards(): Promise<Card[]> {
    try {
      const fileExists = await FileSystem.getInfoAsync(this.path);
      if (!fileExists.exists) {
        return [];
      }
      const fileContent = await FileSystem.readAsStringAsync(this.path);
      return JSON.parse(fileContent);
    } catch (error) {
      console.error('getAllCards: ', error);
      if (error instanceof Error) throw new Error(error.message);

      throw new Error('Failed to fetch cards');
    }
  }

  public async copyCardsToClipboard() {
    try {
      const fileExists = await FileSystem.getInfoAsync(this.path);
      if (!fileExists.exists) {
        throw new Error('No cards to copy');
      }

      const fileContent = await FileSystem.readAsStringAsync(this.path);

      Clipboard.setStringAsync(fileContent);

    } catch (error) {
      console.error('copyCardsToClipboard: ', error);
      if (error instanceof Error) throw new Error(error.message);

      throw new Error('An unknown error occurred');
    }
  };

  public async importCards(importedCards: string) {
    try {
      const created = await this.createFileAndSaveContentIfNotExists(importedCards);
      if (created) return;

      const fileContent = await FileSystem.readAsStringAsync(this.path);
      const savedCards: Card[] = JSON.parse(fileContent);

      const newCards = this.mergeCards(savedCards, importedCards);

      await FileSystem.writeAsStringAsync(this.path, JSON.stringify(newCards, null, 2));

    } catch (error) {
      console.error('importCards: ', error);
      if (error instanceof Error) throw new Error(error.message);

      throw new Error('Failed to import cards');
    }
  };

  private async createFileAndSaveContentIfNotExists(cardsForSave: string) : Promise<boolean | void> {
    const fileExists = await FileSystem.getInfoAsync(this.path);

    if (!fileExists.exists) {
      await FileSystem.writeAsStringAsync(this.path, cardsForSave);
      return true;
    }
  };

  private mergeCards(savedCards: Card[], importedCards: string) {
    const importedCardsParsed: Card[] = JSON.parse(importedCards);
    const mergedCards: Card[] = [...savedCards];

    importedCardsParsed.forEach((importedCard) => {
      const existing = savedCards.find((saved) => saved.id === importedCard.id);

      if (!existing) {
        mergedCards.push(importedCard);
      } else {
        const isSameContent = 
          existing.quest === importedCard.quest 
          && existing.resp === importedCard.resp;

        if (!isSameContent) {
          const newCard = new Card(importedCard.quest, importedCard.resp, importedCard.category);
          mergedCards.push(newCard);
        }
      }
    });
    return mergedCards;
  }

  // private async writeCards<type>(cards: type) {};
}