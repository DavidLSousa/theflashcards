import { TestResult } from './TestResult';
import uuid from 'react-native-uuid';

export class Card {
  id: string;
  quest: string;
  resp: string;
  category: string;
  isAnswerVisible: boolean;
  testResult: TestResult;

  constructor(
    quest: string,
    resp: string,
    category: string,
  ) {
    this.id = uuid.v4();
    this.quest = quest;
    this.resp = resp;
    this.category = category;
    this.isAnswerVisible = false;

    this.testResult = new TestResult(this.id);
  }
}
