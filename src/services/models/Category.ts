export class Category {
  isChecked: boolean;
  name: string;

  constructor(name: string = '', isChecked: boolean = false) {
    this.name = name;
    this.isChecked = isChecked;
  }
}
