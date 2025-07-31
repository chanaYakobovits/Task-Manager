import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { NgFor, NgClass } from '@angular/common';
import { ChatService } from '../../app/Service/services/chat';


@Component({
  selector: 'app-chat',
  imports: [CommonModule, NgFor, NgClass,FormsModule,HttpClientModule],
  templateUrl: './chat.html',
  styleUrl: './chat.css'
})
export class Chat {
  userInput = '';
  messages: { text: string; fromUser: boolean }[] = [];
  isTyping = false;

  constructor(private chatService: ChatService) {}

  ngOnInit() {
    this.messages.push({ text: 'היי, אני דני 🤖. רוצה לספר לי איזו משימה יש לך?', fromUser: false });
  }

  sendMessage() {
    const msg = this.userInput.trim();
    if (!msg) return;
  
    // אתחול שיחה מחדש במקרה שהמשתמש רוצה להתחיל משימה חדשה
    if (msg === 'צור משימה חדשה' || msg === 'התחל מחדש') {
      this.messages = [];
      this.chatService.reset();
      this.messages.push({ text: 'היי, אני דני 🤖. רוצה לספר לי איזו משימה יש לך?', fromUser: false });
      this.userInput = '';
      return;
    }
  
    this.messages.push({ text: msg, fromUser: true });
    this.userInput = '';
    this.isTyping = true;
  
    setTimeout(() => {
      const result = this.chatService.processMessage(msg);
  
      this.messages.push({ text: result.response, fromUser: false });
  
      if (result.done) {
        this.messages.push({ text: 'מצוין! המשימה נוספה בהצלחה. יום טוב! [צור משימה חדשה]', fromUser: false });
        this.chatService.reset();
      }
  
      this.isTyping = false;
    }, 1000);
  }
  
  }
  

