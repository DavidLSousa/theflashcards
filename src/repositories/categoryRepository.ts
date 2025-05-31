import * as FileSystem from 'expo-file-system';

import { Category } from '@/src/models/Category';

export class CategoryRepository {
  private path = `${FileSystem.documentDirectory}categories.json`;

  public async saveCategory(category: string) {
    try {
      const fileExists = await FileSystem.getInfoAsync(this.path);

      if (!fileExists.exists) {
        await FileSystem.writeAsStringAsync(this.path, JSON.stringify([category], null, 2));
        return
      }

      const fileContent = await FileSystem.readAsStringAsync(this.path);
      const savedCategories: Category[] = JSON.parse(fileContent);
      savedCategories.push({ name: category });

      await FileSystem.writeAsStringAsync(this.path, JSON.stringify(savedCategories, null, 2));

    } catch (error) {
      console.error('saveCategory: ', error);
      if (error instanceof Error) throw new Error(error.message);

      throw new Error('Failed to save card');
    }
  }

  public async getAllCategories() {
    try {
      const fileContent = await FileSystem.readAsStringAsync(this.path);
      return JSON.parse(fileContent);
    } catch (error) {
      console.error('getAllCategories: ', error);
      if (error instanceof Error) throw new Error(error.message);

      throw new Error('Failed to fetch Categories');
    }
  }

  public async editCategory(originalCategory: string, editedCategory: string) {
    try {
      const fileContent = await FileSystem.readAsStringAsync(this.path);
      const savedCategories: Category[] = JSON.parse(fileContent);

      const newCategories = savedCategories.map((category) => {
        if (category.name === originalCategory) {
          category.name = editedCategory;
        }
        return category;
      });
      
      await FileSystem.writeAsStringAsync(this.path, JSON.stringify(newCategories, null, 2));

    } catch (error) {
      console.error('editCategory: ', error);
      if (error instanceof Error) throw new Error(error.message);

      throw new Error('Failed to edit category');
    }
  }
  
  public async deleteCategory() {}

}