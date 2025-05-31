import * as FileSystem from 'expo-file-system';
import { Category } from '@/src/models/Category';
import { Card } from '@/src/models/Card';

export class CategoryRepository {
  private path = `${FileSystem.documentDirectory}categories.json`;

  public async saveCategory(category: string) {
    try {
      const fileExists = await FileSystem.getInfoAsync(this.path);

      if (!fileExists.exists) {
        await FileSystem.writeAsStringAsync(this.path, JSON.stringify([{ name: category }], null, 2));
        return;
      }

      const fileContent = await FileSystem.readAsStringAsync(this.path);
      const savedCategories: Category[] = JSON.parse(fileContent);

      // Usa Set para evitar duplicata
      const categorySet = new Set(savedCategories.map(c => c.name));
      categorySet.add(category);

      const uniqueCategories: Category[] = Array.from(categorySet).map(name => ({ name }));

      await FileSystem.writeAsStringAsync(this.path, JSON.stringify(uniqueCategories, null, 2));
    } catch (error) {
      console.error('saveCategory: ', error);
      if (error instanceof Error) throw new Error(error.message);
      throw new Error('Failed to save category');
    }
  }

  public async getAllCategories(): Promise<Category[]> {
    try {
      const fileExists = await FileSystem.getInfoAsync(this.path);
      if (!fileExists.exists) return [];

      const fileContent = await FileSystem.readAsStringAsync(this.path);
      return JSON.parse(fileContent);
    } catch (error) {
      console.error('getAllCategories: ', error);
      if (error instanceof Error) throw new Error(error.message);
      throw new Error('Failed to fetch categories');
    }
  }

  public async editCategory(originalCategory: string, editedCategory: string) {
    try {
      const fileContent = await FileSystem.readAsStringAsync(this.path);
      const savedCategories: Category[] = JSON.parse(fileContent);

      const updatedNames = savedCategories.map(c => c.name === originalCategory ? editedCategory : c.name);
      const uniqueNames = Array.from(new Set(updatedNames));
      const updatedCategories: Category[] = uniqueNames.map(name => ({ name }));

      await FileSystem.writeAsStringAsync(this.path, JSON.stringify(updatedCategories, null, 2));
    } catch (error) {
      console.error('editCategory: ', error);
      if (error instanceof Error) throw new Error(error.message);
      throw new Error('Failed to edit category');
    }
  }

  public async deleteCategory(categoryToDelete: string) {
    try {
      const fileContent = await FileSystem.readAsStringAsync(this.path);
      const savedCategories: Category[] = JSON.parse(fileContent);

      const updatedCategories = savedCategories
        .filter(c => c.name !== categoryToDelete);

      await FileSystem.writeAsStringAsync(this.path, JSON.stringify(updatedCategories, null, 2));
    } catch (error) {
      console.error('deleteCategory: ', error);
      if (error instanceof Error) throw new Error(error.message);
      throw new Error('Failed to delete category');
    }
  }

  public async importCategories(importedCards: string) {
    try {
      const importedCategoryNames = JSON.parse(importedCards).map((card: Card) => card.category);
      const importedCategorySet = new Set(importedCategoryNames);

      const fileExists = await FileSystem.getInfoAsync(this.path);
      let existingCategories: string[] = [];

      if (fileExists.exists) {
        const fileContent = await FileSystem.readAsStringAsync(this.path);
        const savedCategories: Category[] = JSON.parse(fileContent);
        existingCategories = savedCategories.map(c => c.name);
      }

      const mergedSet = new Set([...existingCategories, ...importedCategorySet]);
      const mergedCategories: Category[] = Array.from(mergedSet as Set<string>).map(name => ({ name }));


      await FileSystem.writeAsStringAsync(this.path, JSON.stringify(mergedCategories, null, 2));
    } catch (error) {
      console.error('importCategories: ', error);
      if (error instanceof Error) throw new Error(error.message);
      throw new Error('Failed to import categories');
    }
  }
}
