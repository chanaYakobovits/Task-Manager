import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
// import { User } from '../Components/user/user';
import { Chat } from '../Components/chat/chat';
import { Task } from '../Components/task/task';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Chat,Task],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Client');
}
