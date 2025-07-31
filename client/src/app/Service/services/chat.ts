import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

interface TaskData {
  title?: string;         // שם המשימה
  description?: string;   // תיאור
  dueDate?: Date;         // תאריך יעד
}

@Injectable({
  providedIn: 'root',
})
export class ChatService {
  private task: TaskData = {};
  private stage = 0; // 0 - שם, 1 - תיאור, 2 - תאריך

  constructor(private http: HttpClient) {}

  reset() {
    this.task = {};
    this.stage = 0;
  }

  getTask() {
    return this.task;
  }

  /**
   * מקבלת הודעה ממשתמש ומחזירה תגובה של הבוט וסטטוס האם המשימה מוכנה.
   */
  processMessage(msg: string): { response: string, done: boolean } {
    msg = msg.trim();
  
    // שלב 0 - שם המשימה
    if (this.stage === 0) {
      if (msg.length < 2) {
        return { response: 'אני לא בטוח שזו שם משימה תקין. נסה לכתוב שוב.', done: false };
      }
      this.task.title = msg;
      this.stage = 1;
      return { response: 'מה הסיבה למשימה הזאת?', done: false };
    }
  
    // שלב 1 - תיאור המשימה
    if (this.stage === 1) {
      if (msg.length < 3) {
        return { response: 'אני לא בטוח שהבנתי את התיאור. אפשר לנסות שוב?', done: false };
      }
      this.task.description = msg;
      this.stage = 2;
      return { response: 'ולמתי זה?', done: false };
    }
  
    // שלב 2 - תאריך יעד
    if (this.stage === 2) {
      const parsedDate = this.parseDate(msg);
      if (!parsedDate) {
        return { response: 'אני לא מזהה את התאריך, אפשר לכתוב תאריך כמו "ביום רביעי הבא" או "בעוד שלושה ימים"?', done: false };
      }
      this.task.dueDate = parsedDate;
      return { response: this.finishMessage(), done: true };
    }
  
    return { response: 'משהו השתבש...', done: false };
  }
  
  private finishMessage(): string {
    return `מצוין! יוצרת את המשימה:
• שם: ${this.task.title}
• תיאור: ${this.task.description}
• תאריך: ${this.task.dueDate?.toLocaleDateString('he-IL')}`;
  }

  submitTask() {
    // לדוגמה שליחה לשרת - תעדכן בהתאם
    return this.http.post('/api/tasks', this.task);
  }

  private isValidInput(msg: string): boolean {
    if (!msg) return false;

    // אפשר להוסיף כאן עוד תנאים למניעת תשובות לא רצויות
    const forbiddenWords = ['לא יודע', 'אולי', '...', 'לא'];

    return !forbiddenWords.some((w) => msg.toLowerCase().includes(w));
  }

  private parseDate(text: string): Date | undefined {
    const now = new Date();
    const lowered = text.toLowerCase();
  
    if (lowered.includes('היום')) {
      return now;
    }
  
    if (lowered.includes('מחר')) {
      const tomorrow = new Date(now);
      tomorrow.setDate(now.getDate() + 1);
      return tomorrow;
    }
  
    // מיפוי ימי השבוע לעברית
    const days = ['ראשון', 'שני', 'שלישי', 'רביעי', 'חמישי', 'שישי', 'שבת'];
  
    for (let i = 0; i < days.length; i++) {
      if (lowered.includes(days[i])) {
        let targetDate = new Date(now);
        const currentDay = targetDate.getDay() || 7; // יום ראשון=0 => 7
        let diff = i + 1 - currentDay;
        if (diff <= 0) diff += 7;
        targetDate.setDate(targetDate.getDate() + diff);
        return targetDate;
      }
    }
  
    // בדיקה לתאריך מדויק dd.mm.yyyy או dd/mm/yyyy
    const exactDateMatch = lowered.match(/(\d{1,2})[./](\d{1,2})(?:[./](\d{4}))?/);
    if (exactDateMatch) {
      const day = Number(exactDateMatch[1]);
      const month = Number(exactDateMatch[2]) - 1;
      const year = exactDateMatch[3] ? Number(exactDateMatch[3]) : now.getFullYear();
      return new Date(year, month, day);
    }
  
    // ביטוי "בעוד X ימים"
    const daysFromNowMatch = lowered.match(/בעוד\s+(\d+)\s+יום/);
    if (daysFromNowMatch) {
      const daysToAdd = Number(daysFromNowMatch[1]);
      const date = new Date(now);
      date.setDate(date.getDate() + daysToAdd);
      return date;
    }
  
    return undefined;
  }
  
}
