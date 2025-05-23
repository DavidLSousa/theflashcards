import { TestResult } from './TestResult';

export class Card {
  id: string;
  quest: string;
  resp: string;
  category: string;
  isAnswerVisible: boolean;
  testResult: TestResult;

  constructor(
    id: string = crypto.randomUUID(),
    quest: string = '',
    resp: string = '',
    category: string = '',
    isAnswerVisible: boolean = false
  ) {
    this.id = id;
    this.quest = quest;
    this.resp = resp;
    this.category = category;
    this.isAnswerVisible = isAnswerVisible;

    this.testResult = new TestResult(this.id);
  }
}
