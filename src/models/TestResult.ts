export class TestResult {
  id: string;
  answer: Record<string, number>;
  difficulty: Record<string, number>;

  constructor(id: string) {
    this.id = id;
    this.answer = {
      correct: 0,
      wrong: 0
    };
    this.difficulty = {
      easy: 0,
      medium: 0,
      difficult: 0
    };
  }
}
