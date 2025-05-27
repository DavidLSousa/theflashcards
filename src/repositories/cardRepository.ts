import * as FileSystem from 'expo-file-system';
import * as Clipboard from 'expo-clipboard';

import { Card } from '@/src/models/Card';

export class CardRepository {
  private path = `${FileSystem.documentDirectory}allCards.json`;

  public async saveCard(card: Card) {
    try {
      const fileExists = await FileSystem.getInfoAsync(this.path);
      if (!fileExists.exists) {
        await FileSystem.writeAsStringAsync(this.path, JSON.stringify([card], null, 2));
        return;
      }

      const fileContent = await FileSystem.readAsStringAsync(this.path);
      const savedCards: Card[] = JSON.parse(fileContent);
      savedCards.push(card);
      await FileSystem.writeAsStringAsync(this.path, JSON.stringify(savedCards, null, 2));
    } catch (error) {
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
      if (error instanceof Error) throw new Error(error.message);
      
      throw new Error('An unknown error occurred');
    }
  };
}